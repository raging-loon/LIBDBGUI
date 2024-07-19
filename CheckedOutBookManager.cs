using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    internal class CheckedOutBookManager
    {
        private DataGridView m_cobTable;
        private string BaseQuery;
        
        private bool TableLoaded { get; set; }
        
        public CheckedOutBookManager(DataGridView cobTable)
        {
            m_cobTable = cobTable;
            BaseQuery =
            "SELECT out_books.book_id, check_out_date, books.book_isbn, books.book_name, _client.client_name " +
            "FROM out_books " +
            "LEFT JOIN books " +
            "ON out_books.book_id = books.book_id " +
            "LEFT JOIN _client " +
            "ON out_books.client_id = _client.client_id";
            TableLoaded = false;


        }

        public void LoadTable(MySqlConnection conn, bool force = false)
        {
            if (TableLoaded && !force)
                return;

            Debug.Assert(conn != null && 
                         conn.State == System.Data.ConnectionState.Open);


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = BaseQuery + ';';
            MySqlDataReader reader = cmd.ExecuteReader();

            
            DisplayQueryResults(reader);
            reader.Close();

            TableLoaded = true;
        }

        public void DisplayPerClientID(MySqlConnection conn, int clientID)
        {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = BaseQuery + $" WHERE out_books.client_id = {clientID};";
            MySqlDataReader reader = cmd.ExecuteReader();
            DisplayQueryResults(reader);
            reader.Close();
            TableLoaded = true;

        }

        public void DisplayPerBookID(MySqlConnection conn, int bookID)
        {

            MySqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = BaseQuery + $" WHERE out_books.book_id = {bookID};";
            MySqlDataReader reader = cmd.ExecuteReader();
            DisplayQueryResults(reader);
            reader.Close();
            TableLoaded = true;

        }


        private void DisplayQueryResults(MySqlDataReader reader)
        {
            m_cobTable.Rows.Clear();
            while (reader.Read())
            {

                object[] newRow =
                {
                    reader.GetInt32(0),
                    reader.GetDateTime(1).ToShortDateString(),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4)
                };
                m_cobTable.Rows.Add(newRow);
            }
        }

    }
}
