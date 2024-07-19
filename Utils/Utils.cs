using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    internal class Utils
    {
        public static void ShowError(string message, string caption)
        {
            MessageBox.Show(
                message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error
            );
        }

        /// <summary>
        /// Executes a SQL Query
        /// </summary>
        /// <param name="conn">The connection</param>
        /// <param name="cmd">Command</param>
        /// <returns>A Reader so returned values can be read</returns>
        public static MySqlDataReader executeQuery(MySqlConnection conn, string cmd)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = cmd;

            MySqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public static bool IsValidClientID(MySqlConnection conn, string clientID)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                $"SELECT * FROM _client WHERE client_id = {clientID};";

            return cmd.ExecuteScalar() != null;
        }
        public static bool IsValidClientID(MySqlConnection conn, int clientID)
        {
            return IsValidClientID(conn, $"{clientID}");
        }


        public static bool IsValidISBN(string isbn)
        {
            return Regex.IsMatch(isbn, "^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$") ||
                   Regex.IsMatch(isbn, "^([0-9]{9})\\-(\\w|\\d)$");
        }

    }
}
