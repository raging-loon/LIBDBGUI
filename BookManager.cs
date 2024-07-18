using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace LIBDBGUI
{

    /// <summary>
    /// Holds indexes of data found in the "books" table in the DB.
    /// More type-safe than an Enum
    /// </summary>
    internal class BookTabs
    {

        public const int ID                 = 0;
        public const int ISBN               = 1;
        public const int NAME               = 2;
        public const int AUTHOR             = 3;
        public const int GENRE              = 4;
        public const int DATE_PUBLISHED     = 5;
        public const int TOTAL_COPIES       = 6;
        public const int COPIES_OUT         = 7;

    }


    internal class BookManager
    {
        private DataGridView m_bookTable;

        /// <summary>
        /// Prevents the table from being reloaded every time the user 
        /// clicks on the tab.
        /// </summary>
        private bool m_tableIsPopulated;

        private CellEditState m_cellEditState;

        public int m_loadLimit { get; set; }

        public BookManager(DataGridView bookTable)
        {
            m_bookTable = bookTable;
            m_tableIsPopulated = false;
            m_loadLimit = 1000;

        }

        /// <summary>
        /// Load/Update m_bookTable
        /// 
        /// Will only load if m_tableIsPopulated is false or forceUpdate is true
        /// </summary>
        public void LoadTable(MySqlConnection conn, bool forceUpdate = false)
        {
            if (!forceUpdate && m_tableIsPopulated)
                return;

            m_bookTable.Rows.Clear();
            
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM books LIMIT {m_loadLimit};";

            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                object[] newRow =
                {
                    reader.GetInt32     (BookTabs.ID),
                    reader.GetString    (BookTabs.ISBN),
                    reader.GetString    (BookTabs.NAME),
                    reader.GetString    (BookTabs.AUTHOR),

                    // TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO 
                    // FIX THE DATABASE. DATE_PUBLISHED AND GENRE NEED TO BE SWITCHED
                    // TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO TODO 

                    reader.GetString    (BookTabs.GENRE),
                    reader.GetDateTime  (BookTabs.DATE_PUBLISHED).ToShortDateString(),
                    reader.GetInt32     (BookTabs.TOTAL_COPIES),
                    reader.GetInt32     (BookTabs.COPIES_OUT)
                };

                int nrIdx = m_bookTable.Rows.Add(newRow);
                // mark the new row as read-only
                m_bookTable.Rows[nrIdx].ReadOnly = true;

            }

            reader.Close();
            //m_bookTable.Update();
            m_tableIsPopulated = true;


        }
        /// <summary>
        /// If the Cell to edit is NOT the ID tab,
        /// add the value to the cell edit state and mark the cell
        /// as editable
        /// </summary>
        public void BeginCellEdit(int rowIndex, int columnIndex)
        {
            // Don't let the user edit the primary key
            if (columnIndex == BookTabs.ID)
                return;

            DataGridViewCell selectedCell = m_bookTable[columnIndex, rowIndex];
            selectedCell.ReadOnly = false;
            m_bookTable.CurrentCell = selectedCell; 
            m_bookTable.BeginEdit(true);

            m_cellEditState = new CellEditState(selectedCell);

        }

        /// <summary>
        /// Update the "books" table
        /// Will validate ISBN and DATE inputs
        /// 
        /// Will auto-refresh the table whether the update
        /// failed or not
        /// 
        /// </summary>
        public void EndCellEdit(MySqlConnection conn, int rowIndex, int columnIndex)
        {
            if (m_cellEditState == null)
                return;


            DataGridViewCell selectedCell = m_bookTable[columnIndex, rowIndex];

            if (!m_cellEditState.Changed(selectedCell))
                return;

            string value = selectedCell.Value.ToString();

            // ValidateInput shows an error message for us
            if (!ValidateInput(value, columnIndex))
            {
                LoadTable(conn, true);
                return;
            }
           
            value = FormatValue(value, columnIndex);

            string fieldName = selectedCell.OwningColumn.Name;
            int bookID = (int)m_bookTable[BookTabs.ID, rowIndex].Value;
            
            DatabaseTableUpdate update = new DatabaseTableUpdate(
                fieldName, "books", value, "book_id", bookID
            );

            if(!update.update(conn))
            {
                Utils.ShowError("Failed to update table", "Table update error");
            }

            LoadTable(conn, true);
        }

        /// <summary>
        /// Validate ISBN and DATE inputs
        /// </summary>
        /// <param name="input">string</param>
        /// <param name="type">type, will only be validated if Type is ISBN or DATE</param>
        /// <returns></returns>
        private bool ValidateInput(string input, int type)
        {
            if (type == BookTabs.ISBN)
            {
                if (!IsValidISBN(input))
                {
                    Utils.ShowError(
                        $"'{input}' is not a valid ISBN",
                        "Invalid Value"
                    );
                    return false;
                }
            }
            else if (type == BookTabs.DATE_PUBLISHED)
            {
                if (!IsValidDate(input))
                {
                    Utils.ShowError(
                        $"'{input}' is not a valid Date.",
                        "Invalid Date"
                    );
                    return false;
                }
            }
            

            return true;
        }

        /// <summary>
        /// Add quotes around strings and the 'STR_TO_DATE' function around DATEs
        /// </summary>
        /// <returns>Formatted value</returns>
        private string FormatValue(string value, int type)
        {
            switch (type)
            {
                case BookTabs.ISBN:
                case BookTabs.NAME:
                case BookTabs.AUTHOR:
                case BookTabs.GENRE:
                    return $"'{value}'";
                case BookTabs.DATE_PUBLISHED:
                    char delim = value[value.Length - 5];
                    return $"STR_TO_DATE('{value}','%m{delim}%d{delim}%Y')";
                default:
                    return value;
            }
        }

        private bool IsValidISBN(string isbn)
        {
            return Regex.IsMatch(isbn, "^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$") ||
                   Regex.IsMatch(isbn, "^([0-9]{9})\\-(\\w|\\d)$");
        }
    
        private bool IsValidDate(string date)
        {
            // Try the regex
            if(Regex.IsMatch(date, "^\\d{1,2}(\\/|\\-|\\.)\\d{1,2}(\\/|\\-|\\.)\\d{4}$"))
            {
                // OK Now make sure the months and dates are valid.
                char delim = date[date.Length - 5];
                string[] dateParts = date.Split(delim);
                if (dateParts.Length != 3)
                    return false;
                
                int m = int.Parse(dateParts[0]);
                int d = int.Parse(dateParts[1]);
                int y = int.Parse(dateParts[2]);

                if(m <= 0 || m > 12)
                    return false;
                
                if (d <= 0)
                    return false;
                
                int upperDayLimit = 30;
                // if its Feb
                if(m == 2)
                {
                    // If its a leap year
                    if (y % 4 == 0 && (y % 100 != 0 || y % 400 == 0))
                        upperDayLimit = 29;
                    else
                        upperDayLimit = 28;
                }
                else
                {
                    // why 
                    // if the month has 31 days
                    if (m == 1 || m == 3  || m == 5 || m == 7 || 
                        m == 8 || m == 10 || m == 12)
                        upperDayLimit = 31;
                }


                if(d > upperDayLimit) 
                    return false;

                return true;
            }

            return false;

        }

    }

}
