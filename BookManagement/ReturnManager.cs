using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDBGUI.BookManagement
{
  
    internal class ReturnManager
    {
        private readonly List<string> m_isbnList;
        private readonly int m_clientID;

        public ReturnManager(List<string> isbns, int clientID)
        {
            m_isbnList = isbns;
            m_clientID = clientID;
        }

        /// <summary>
        /// This code is called by LibraryInterface
        /// The clientID is assumed valid as it is checked in
        /// ReturnForm
        /// </summary>
        public void doReturn(MySqlConnection conn)
        {
            
            foreach(string isbn in m_isbnList)
            {
                if(!DoSingleReturn(conn, isbn))
                {
                    Utils.ShowError(
                      $"Failed to return {isbn} for client {m_clientID}.",
                       "Update Failed"
                    );
                    return;
                }
            }

        }

        private bool DoSingleReturn(MySqlConnection conn, string isbn)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "InternalReturn";
            cmd.Parameters.Add(new MySqlParameter("_client_id", m_clientID));
            cmd.Parameters.Add(new MySqlParameter("_book_isbn", isbn));

            return cmd.ExecuteNonQuery() == 1;
        }
 
    
    
    }
}
