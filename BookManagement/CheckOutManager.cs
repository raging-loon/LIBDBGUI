using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LIBDBGUI.BookManagement
{
    internal class CheckOutManager
    {
        private int m_clientID;
        private string m_isbn;
        private MySqlConnection m_connection;
        public CheckOutManager(MySqlConnection conn, int clientID, string isbn)
        {
            m_clientID = clientID;
            m_isbn = isbn;
            m_connection = conn;
        }

        /// <summary>
        /// Updates the database using the stored procedure "InternalCheckout"
        /// Also checks if there are enough copies and if the ISBN actually exists
        /// </summary>
        public bool checkout()
        {
            
            if(!Utils.IsValidClientID(m_connection, m_clientID))
            {
                MessageBox.Show("Invalid Client ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int copiesLeft = GetNumCopiesAvailable();
            
            if(copiesLeft == 0)
            {
                MessageBox.Show($"No copies of {m_isbn} left.");
                return false;
            }
            
            if(copiesLeft < 0)
            {
                MessageBox.Show("Invalid ISBN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Construct and execute procedure
            MySqlCommand command = new MySqlCommand();

            command.Connection = m_connection;
            command.CommandText = "InternalCheckout";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("_client_id", m_clientID));
            command.Parameters.Add(new MySqlParameter("_book_isbn", m_isbn));

            command.ExecuteNonQuery();
            
            return true;
        }

        /// <summary>
        /// Gets the number of availabe copies of a book
        /// </summary>
        /// <returns>-1 if the ISBN doesn't exist,
        ///           0 if there are no more copies
        ///             otherwise the number of copies
        /// </returns>
        private int GetNumCopiesAvailable()
        {
            MySqlCommand getCopyCount = new MySqlCommand();
            getCopyCount.Connection = m_connection;
            getCopyCount.CommandText =
                $"SELECT num_copies, num_copies_out FROM books WHERE book_isbn = '{m_isbn}';";

            MySqlDataReader res = getCopyCount.ExecuteReader();
            
            // Read will fail if no rows are returned, i.e. if the ISBN 
            // doesn't exist in the database
            if(!res.Read())
            {
                res.Close();
                return -1;
            }

            int numCopiesLeft = (int)res.GetValue(0) - (int)res.GetValue(1);
            res.Close();
            return numCopiesLeft;
        }

    }
}
