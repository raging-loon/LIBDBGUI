using LIBDBGUI.ClientForms;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    /// <summary>
    /// Manages the Client Tab in <c>LibraryInterface</c>
    /// </summary>
    internal class ClientManager
    {
        private DataGridView clientTable;
        private enum ClientDataIndex : int
        { 
            ID,
            IS_STUDENT,
            FINES,
            NUM_BOOKS,
            NAME
        }

        private class ColumnNames
        {
            public const int ID    = 0;
            public const int NAME  = 1;
            public const int BOOKS = 2;
            public const int FINES = 3;
            public const int TYPE  = 4;

        }


        /// <summary>
        /// Used during cell editing to determine whether the value has changed
        /// </summary>
        private CellEditState m_cellEditState;

        private bool m_tableIsPopulated;

        public ClientManager(DataGridView view)
        {
            clientTable = view;
            m_tableIsPopulated = false;
        }

        /// <summary>
        /// Filles <c>clientTable</c> with client data.
        /// Uses 'SELECT * from _client;' to obtain.
        /// </summary>
        /// <param name="conn">MySQL Connection</param>
        public void LoadTable(MySqlConnection conn)
        {
            if (m_tableIsPopulated)
                return;
            Debug.Assert(conn.State == System.Data.ConnectionState.Open);
         

            MySqlCommand getClientCommand = new MySqlCommand();
            getClientCommand.Connection = conn;
            getClientCommand.CommandText = "SELECT * from _client;";
            
            MySqlDataReader reader = getClientCommand.ExecuteReader();

            DisplayQueryResult(reader);

            reader.Close();
            m_tableIsPopulated = true;
        }
        /// <summary>
        /// Populate clientTable with info from a query
        /// </summary>
        /// <param name="reader">Reader that has the info</param>
        private void DisplayQueryResult(MySqlDataReader reader)
        {
            Debug.Assert(!reader.IsClosed);
            clientTable.Rows.Clear();


            while (reader.Read())
            {

                bool isStudent = (bool)reader.GetValue((int)ClientDataIndex.IS_STUDENT);
                object[] newRow =
                {
                    reader.GetValue((int)ClientDataIndex.ID),
                    reader.GetValue((int)ClientDataIndex.NAME),
                    reader.GetValue((int)ClientDataIndex.NUM_BOOKS),
                    reader.GetValue((int)ClientDataIndex.FINES),
                    isStudent ? "Student" : "Teacher"
                };
                int newIdx = clientTable.Rows.Add(newRow);
                clientTable.Rows[newIdx].ReadOnly = true;
            }

        }

     

        /***********************************************/
        /******* LibraryInterface event handlers *******/
        /***********************************************/


        public void NewButtonPressed(MySqlConnection conn, object sender, EventArgs e)
        {
            NewClientForm ncf = new NewClientForm();
            ncf.ShowDialog();
            if (!ncf.WasSubmitted)
                return;
            MySqlCommand insertNewUserCommand = new MySqlCommand();
            insertNewUserCommand.Connection = conn;
            
            
            /// TODO TODO TODO TODO: INPUT SANITIZATION 
            insertNewUserCommand.CommandText = 
                 "INSERT INTO _client (c_is_student, client_fines, client_num_books, client_name)" +
                $"VALUES ({ncf.GetClientIsTeacher}, 0.0, 0, '{ncf.ClientName}');";

            int rowsAffected = insertNewUserCommand.ExecuteNonQuery();

            m_tableIsPopulated = false;

            LoadTable(conn);
        }

        public void DeleteButtonPressed(MySqlConnection connection, object sender, EventArgs e)
        {
            string clientName = (string)clientTable.SelectedRows[0].Cells[1].Value;
            int clientID =      (int)clientTable.SelectedRows[0].Cells[0].Value;
            DialogResult userAnswer = MessageBox.Show(
                $"Are you sure you want to delete {clientName}?",
                "Client Deletion Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if ( userAnswer == DialogResult.Yes )
            {
                MySqlCommand deleteUserCommand = new MySqlCommand();
                deleteUserCommand.Connection = connection;
                deleteUserCommand.CommandText =
                    $"DELETE FROM _client WHERE( client_id = {clientID} AND client_name = '{clientName}');";

                int rowsAffected = deleteUserCommand.ExecuteNonQuery();
                m_tableIsPopulated = false;

                LoadTable(connection);
            }


        }

        public void RefreshButtonPressed(MySqlConnection connection, object sender, EventArgs e)
        {
            m_tableIsPopulated = false;
            LoadTable(connection);
        }

        public void SearchByIDWasPressed(MySqlConnection connection, int ID)
        {
            MySqlDataReader reader = Utils.executeQuery(connection,
                $"SELECT * FROM _client WHERE client_id = {ID}"
            );

            DisplayQueryResult(reader);

            reader.Close();
        }

        public void SearchByNameWasPressed(MySqlConnection connection, string name)
        {
            MySqlDataReader reader = Utils.executeQuery(connection,
                $"SELECT * FROM _client WHERE client_name REGEXP '^{name}$';"
            );

            DisplayQueryResult(reader);

            reader.Close();
        }

        public void BeginCellEdit(int rowIndex, int colIndex)
        {
            if (colIndex == ColumnNames.ID || colIndex == ColumnNames.BOOKS)
                return;
            DataGridViewCell selectedCell = clientTable.Rows[rowIndex].Cells[colIndex];
            selectedCell.ReadOnly = false;
            clientTable.CurrentCell = selectedCell;
            clientTable.BeginEdit(true);

            
            m_cellEditState = new CellEditState(selectedCell);
        }

        /// <summary>
        /// Update a field based on the new value
        /// Thie method determines the field name, clientID, and 
        /// formats the value, then sends the update command.
        /// 
        /// The field name is the column name
        /// </summary>
        public void EndCellEdit(MySqlConnection conn, int rowIndex, int colIndex)
        {
            DataGridViewCell selectedCell = clientTable.Rows[rowIndex].Cells[colIndex];

            // If the cell's value changed
            if(m_cellEditState != null && m_cellEditState.Changed(selectedCell))
            {
                // field to edit
                string fieldName = selectedCell.OwningColumn.Name;
                string value = selectedCell.Value.ToString();

                // get clientID for updating the right record
                int clientID = (int)clientTable[ColumnNames.ID, rowIndex].Value;

                // add quotes or the update will fail (syntax error)
                if (colIndex == ColumnNames.NAME)
                    value = $"'{value}'";
                if(colIndex == ColumnNames.TYPE)
                {
                    // Throw an error if the value is not "student" or "teacher"
                    if (value.ToLower() == "student")
                        value = "1";
                    else if(value.ToLower() == "teacher")
                        value = "0";
                    else
                    {
                        MessageBox.Show(
                            $"Invalid Client Type: {value}. Expected 'Teacher' or 'Student'",
                            "Invalid Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        // Reset the value
                        selectedCell.Value = m_cellEditState.PreviousValue;
                        return;
                    }
                }

                DatabaseTableUpdate update = new DatabaseTableUpdate(
                    fieldName, "_client", value, "client_id", clientID
                );

                if(update.update(conn))
                {
                    m_tableIsPopulated = false;
                    LoadTable(conn);
                }
                else
                {
                    MessageBox.Show(
                         $"Failed to update table",
                         "Update Failure",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                     );
                }

            }
            
        }

    }
}
