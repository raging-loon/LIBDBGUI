using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI.ClientForms
{
    internal struct ReturnBookData
    {
        public int TotalCopies;
        public int CopiesOut;
    };
    public partial class ReturnForm : Form
    {
        public bool WasSubmitted { get; private set; }

        public int ClientID { get; private set; }

        private MySqlConnection m_connection;

        /// <param name="conn">Used for ISBN validation</param>
        public ReturnForm(MySqlConnection conn)
        {
            InitializeComponent();
            WasSubmitted = false;
            ClientID = -1;
            m_connection = conn;
        }
        public List<string> GetISBNs()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < RFISBNList.RowCount; i++)
            {
                object toAppend = RFISBNList[0, i].Value;
                if(toAppend != null)
                    //790011146-8
                    list.Add(toAppend.ToString());
                        
            }

            return list;
        }
        
        private void RFSubmitButton_Click(object sender, EventArgs e)
        {
            // Check if the Text boxes have text
            if(ReturnClientIDTextBox.Text.Length == 0 )
            {
                ReturnClientIDTextBox.Focus();
                return;
            }
            if (RFISBNList.RowCount == 1 && RFISBNList[0,0].Value == null)
            {
                RFISBNList.Focus();
                return;
            }

            // validate ClientID/ISBN
            if (!ValidateClient())
                return;


            if (!ValidateISBNs(m_connection))
                return;


            WasSubmitted = true;
            Close();

        }

        private bool ValidateISBNs(MySqlConnection conn)
        {

            

            // -1 for last row which is always NULL
            for(int i = 0; i < RFISBNList.RowCount - 1; i++)
            {
                MySqlCommand cmd = conn.CreateCommand();
                object isbn = RFISBNList.Rows[i].Cells[0].Value;
                // Ignore any null values.
                // Typically this will be the end of th elist
                if (isbn == null)
                {
                    Utils.ShowError("Row cannot be empty", "Empty Row");
                    return false;
                }

                cmd.CommandText = $"SELECT book_id FROM books WHERE book_isbn = '{isbn.ToString()}';";
                object bookId = cmd.ExecuteScalar();
                if (bookId == null)
                {
                    Utils.ShowError($"Invalid or Unknown ISBN: {isbn.ToString()}", "Invalid Value");
                    return false;
                }

            }

            return true;
        }


        private bool ValidateClient()
        {
            int clientID;

            if (!int.TryParse(ReturnClientIDTextBox.Text, out clientID))
            {
                Utils.ShowError($"Invalid Client ID '{ReturnClientIDTextBox.Text}'. Must be an integer",
                                "Invalid Value");
                return false;
            }

            if (!Utils.IsValidClientID(m_connection, clientID))
            {
                Utils.ShowError($"Client {clientID} does not exist", "Error");
                return false;
            }

            if (!ClientHasBooks(clientID))
            {
                Utils.ShowError($"Client {clientID} does not have any books checked out", "Error");
                return false; 
            }
            ClientID = clientID;

            return true;
        }
        
        private bool ClientHasBooks(int id)
        {
            MySqlCommand cmd = m_connection.CreateCommand();

            cmd.CommandText = $"SELECT client_num_books FROM _client WHERE client_id = {id};";

            return (int)cmd.ExecuteScalar() != 0;
        }
        

    }
}
