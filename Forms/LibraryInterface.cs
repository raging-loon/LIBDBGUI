using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIBDBGUI.ClientForms;
using LIBDBGUI.BookManagement;
using MySql.Data.MySqlClient;

namespace LIBDBGUI
{
    public partial class LibraryInterface : Form
    {
        private MySqlConnection m_connection = null;
        private ClientManager m_clientManager;
        private BookManager m_bookManager;
        private CheckedOutBookManager m_checkOutBookManager;
        
        public LibraryInterface(MySqlConnection conn)
        {
            
            if (conn == null)
                throw new NullReferenceException("LibraryInterface: MysqlConnection == null");
            m_connection = conn;

            InitializeComponent();

            // Add double buffering to the tables
            Type dgvt = bookTable.GetType();

            PropertyInfo pi = dgvt.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(bookTable, true, null);



            m_clientManager = new ClientManager(ClientTable);
            m_clientManager.LoadTable(conn);
            
            m_checkOutBookManager = new CheckedOutBookManager(OutBookTable);

            m_bookManager = new BookManager(bookTable);


        }


        /// <summary>
        /// Library book checkout
        /// TODO: Support more than one book
        /// 
        /// Updates Book's 'num_copies_out'
        /// Updates 'out_books' table
        /// Updates _client by incrementing books checked out
        /// 
        /// </summary>
        private void checkOutButton_Click(object sender, EventArgs e)
        {
            CheckOutForm cof = new CheckOutForm();
            cof.ShowDialog();

            if (!cof.CloseFromSubmit)
                return;

            CheckOutManager com = new CheckOutManager(
                m_connection,
                cof.ClientID,
                cof.ISBN
            );
            com.checkout();

            m_clientManager.LoadTable(m_connection);
        }

        private void ReturnBooksButton_Click(object sender, EventArgs e)
        {
            ReturnForm rf = new ReturnForm(m_connection);
            rf.ShowDialog();

            if (!rf.WasSubmitted)
                return;

            ReturnManager rm = new ReturnManager(rf.GetISBNs().ToArray(), rf.ClientID);
            rm.doReturn(m_connection);
            
        }
        private void LibraryTabs_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0: m_clientManager.LoadTable(m_connection); break;
         
                
                case 1: m_bookManager.LoadTable(m_connection); break;
                case 2: m_checkOutBookManager.LoadTable(m_connection); break;
            }
        }
        /***********************************************************/
        /*********** LibraryInterface Intercepted Events ***********/
        /***********************************************************/
        private void BookSearchViewClientsButton_Click(object sender, EventArgs e)
        {
            int bookID = (int)bookTable[0, bookTable.CurrentCell.RowIndex].Value;

            m_checkOutBookManager.DisplayPerBookID(m_connection, bookID);

            LibraryTabs.SelectedTab = CheckedOutBooksTab;
        }

        private void ClientsViewCheckedOutBooksButton_Click(object sender, EventArgs e)
        {
            int clientID = (int)ClientTable[0, ClientTable.CurrentCell.RowIndex].Value;

            m_checkOutBookManager.DisplayPerClientID(m_connection, clientID);

            LibraryTabs.SelectedTab = CheckedOutBooksTab;
        }
        /******************************************************/
        /*********** ClientManager forwarded Events ***********/
        /******************************************************/
        private void ClientNewButton_Click(object sender, EventArgs e)
        {
            m_clientManager.NewButtonPressed(m_connection, sender, e);
        }

        private void ClientDeleteButton_Click(object sender, EventArgs e)
        {
            m_clientManager.DeleteButtonPressed(m_connection, sender, e);
        }

        private void ClientTableRefreshButton_Click(object sender, EventArgs e)
        {
            m_clientManager.RefreshButtonPressed(m_connection, sender, e);
        }

        private void ClientSearchByID_Click(object sender, EventArgs e)
        {
            // TODO: Turn this into a function if it is used again
            if (ClientSearchBox.Text.Length == 0)
            {
                MessageBox.Show("No value was provided", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int id = int.Parse(ClientSearchBox.Text);
                m_clientManager.SearchByIDWasPressed(m_connection, id);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid ID provided. Must be a whole number.", 
                                "Invalid Search", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClientSearchByName_Click(object sender, EventArgs e)
        {
            if (ClientSearchBox.Text.Length == 0)
            {
                MessageBox.Show("No value was provided", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_clientManager.SearchByNameWasPressed(m_connection, ClientSearchBox.Text);
        }
        private void ClientTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
               
                m_clientManager.BeginCellEdit(e.RowIndex, e.ColumnIndex);
            }
        }
        private void ClientTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            m_clientManager.EndCellEdit(m_connection, e.RowIndex, e.ColumnIndex);
        }
        /************************************************************/
        /*********** CheckOutBookManager forwarded Events ***********/
        /************************************************************/
        private void OutBooksRefreshButton_Click(object sender, EventArgs e)
        {
            m_checkOutBookManager.LoadTable(m_connection, true);
        }



        /****************************************************/
        /*********** BookManager forwarded Events ***********/
        /****************************************************/

        private bool CheckBookSearchTextBoxIsNotEmpty()
        {
            if(BookSearchTextBox.Text.Length == 0)
            {
                BookSearchTextBox.Focus();
                return false;

            }
            return true;
        }

        private void bookTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0)
                m_bookManager.BeginCellEdit(e.RowIndex, e.ColumnIndex);
        }

        private void bookTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            m_bookManager.EndCellEdit(m_connection, e.RowIndex, e.ColumnIndex);

        }

        private void BMRefresh_Click(object sender, EventArgs e)
        {
            m_bookManager.LoadTable(m_connection, true);
        }

        private void BookSearchByName_Click(object sender, EventArgs e)
        {
            if (CheckBookSearchTextBoxIsNotEmpty())
                m_bookManager.SearchByTitle(m_connection, BookSearchTextBox.Text);  
        }

        private void BookSearchISBN_Click(object sender, EventArgs e)
        {
            if(CheckBookSearchTextBoxIsNotEmpty())
                m_bookManager.SearchByISBN(m_connection, BookSearchTextBox.Text);

        }

        private void BookSearchAuthor_Click(object sender, EventArgs e)
        {
            if (CheckBookSearchTextBoxIsNotEmpty())
                m_bookManager.SearchByAuthor(m_connection, BookSearchTextBox.Text);
        }

  
    }
}
