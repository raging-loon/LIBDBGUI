using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        public const int DATE_PUBLISHED     = 4;
        public const int GENRE              = 5;
        public const int TOTAL_COPIES       = 6;
        public const int COPIES_OUT         = 7;

    }


    internal class BookManager
    {
        private DataGridView m_bookTable;
        private ProgressBar m_bookLoadBar;

        private bool m_tableIsPopulated;
        public int m_loadLimit { get; set; }

        public BookManager(DataGridView bookTable, ProgressBar bookLoadBar)
        {
            m_bookTable = bookTable;
            m_bookLoadBar = bookLoadBar;
            m_tableIsPopulated = false;
            m_loadLimit = 500;
        }


        public void LoadTable(MySqlConnection conn)
        {
            if (m_tableIsPopulated)
                return;

            m_bookLoadBar.Visible = true;
            m_bookTable.Rows.Clear();
            
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM books LIMIT {m_loadLimit};";

            m_bookLoadBar.Increment(50);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                object[] newRow =
                {
                    reader.GetInt32     (BookTabs.ID),
                    reader.GetString    (BookTabs.ISBN),
                    reader.GetString    (BookTabs.NAME),
                    reader.GetString    (BookTabs.AUTHOR),
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
            m_bookLoadBar.Visible = false;
            m_bookLoadBar.Update();
            m_bookLoadBar.Value = 0;
            m_tableIsPopulated = true;


        }


    }
}
