using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDBGUI
{
    /// <summary>
    /// Updates the database
    /// 
    /// Relies on the DataGridView's to have the corresponding field name
    /// as column names
    /// </summary>
    internal class DatabaseTableUpdate
    {
        private string m_fieldName;
        private string m_tableName;
        private object m_newValue;
        private string m_primaryKeyName;
        private int    m_primaryKey;

        public string LastError { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">Name of Field to update. E.g. book_isbn</param>
        /// <param name="tableName">Name of Table. e.g. books</param>
        /// <param name="newValue">New value</param>
        /// <param name="pkName">Name of the table's primary key</param>
        /// <param name="pkVal">Value of the key</param>
        public DatabaseTableUpdate(string fieldName, string tableName, object newValue, string pkName, int pkVal)
        {
            m_fieldName = fieldName;
            m_tableName = tableName;
            m_newValue = newValue;
            m_primaryKeyName = pkName;
            m_primaryKey = pkVal;
        }

        /// <summary>
        /// Update the table
        /// 
        /// If it failed, check DatabaseTableUpdate.LastError
        /// 
        /// </summary>
        /// <returns>True if the Update was successful</returns>
        public bool update(MySqlConnection connection)
        {
            Debug.Assert(connection != null && connection.State == System.Data.ConnectionState.Open);

            MySqlCommand updateCmd = new MySqlCommand();
            updateCmd.Connection = connection;
            updateCmd.CommandText =
                $"UPDATE {m_tableName} SET {m_fieldName} = {m_newValue} WHERE {m_primaryKeyName} = {m_primaryKey}";

            int rowsEffected;

            try
            {
                rowsEffected = updateCmd.ExecuteNonQuery();

                return rowsEffected == 1;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }

        }

    }
}
