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
    internal class CheckOutBookManager
    {
        private DataGridView m_cobTable;

        public CheckOutBookManager(DataGridView cobTable)
        {
            m_cobTable = cobTable;
        }

        public void LoadTable(MySqlConnection conn)
        {
            Debug.Assert(conn != null && 
                         conn.State == System.Data.ConnectionState.Open);

            m_cobTable.Rows.Clear();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText =
            
            "SELECT out_books.book_id, check_out_date, books.book_isbn, books.book_name, _client.client_name " +
            "FROM out_books " +
            "LEFT JOIN books " +
            "ON out_books.book_id = books.book_id " +
            "LEFT JOIN _client " +
            "ON out_books.client_id = _client.client_id;";
            MySqlDataReader reader = cmd.ExecuteReader();

            
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
            reader.Close();
        }

    }
}
