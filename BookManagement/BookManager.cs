using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace LIBDBGUI.BookManagement
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

            
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM books LIMIT {m_loadLimit};";

            MySqlDataReader reader = cmd.ExecuteReader();

            DisplayQueryResults(reader);

            reader.Close();
            //m_bookTable.Update();
            m_tableIsPopulated = true;
        }

        private void DisplayQueryResults(MySqlDataReader reader)
        {
            Debug.Assert(!reader.IsClosed);
            m_bookTable.Rows.Clear();
            
            while (reader.Read())
            {

                object[] newRow =
                  {
                    reader.GetInt32     (BookTabs.ID),
                    reader.GetString    (BookTabs.ISBN),
                    reader.GetString    (BookTabs.NAME),
                    reader.GetString    (BookTabs.AUTHOR),
                    reader.GetString    (BookTabs.GENRE),
                    reader.GetDateTime  (BookTabs.DATE_PUBLISHED),
                    reader.GetInt32     (BookTabs.TOTAL_COPIES),
                    reader.GetInt32     (BookTabs.COPIES_OUT)
                };
                int newIdx = m_bookTable.Rows.Add(newRow);
                m_bookTable.Rows[newIdx].ReadOnly = true;
            }
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
                // refresh if failed to restore the original value
                LoadTable(conn, true);
            }
        }

        /************************/
        /*** Search Functions ***/
        /************************/

        // TODO: Refactor to get rid of code duplication
        public void SearchByTitle(MySqlConnection conn, string title)
        {
            MySqlDataReader res = Utils.executeQuery(conn,
                $"SELECT * FROM books WHERE book_name REGEXP '^{title}$';"
            );

            DisplayQueryResults(res);
            res.Close();
        }

        public void SearchByISBN(MySqlConnection conn, string isbn)
        {
            MySqlDataReader res = Utils.executeQuery(conn,
                $"SELECT * from books where book_isbn REGEXP '^{isbn}$';"
            );

            DisplayQueryResults(res);
            res.Close();
        }

        public void SearchByAuthor(MySqlConnection conn, string author)
        {
            MySqlDataReader res = Utils.executeQuery(conn,
                $"SELECT * from books where book_author REGEXP '^{author}$';"
            );

            DisplayQueryResults(res);
            res.Close();
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
                if (!Utils.IsValidISBN(input))
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

    

        private bool IsValidDate(string date)
        {
            string[] formats =
            {
                "MM.dd.yyyy",
                "MM/dd/yyyy",
                "MM-dd-yyyy",
                "dd.MM.yyyy",
                "dd/MM/yyyy",
                "dd-MM-yyyy"
            };


            DateTime outvar;
            return DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out outvar);
        }
      

    }

}
