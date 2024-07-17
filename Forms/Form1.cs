using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LIBDBGUI
{
    public partial class MainMenu : Form
    {
        private NewConnectionDialog m_ConnectionDialog;
        private ConnectionCache m_ConnectionCache;
        public MainMenu()
        {
            InitializeComponent();
            m_ConnectionCache = new ConnectionCache();
            m_ConnectionCache.Load();

            Dictionary<string, ConnectionData> values = m_ConnectionCache.ConnectionData;

            foreach(string name in values.Keys)
            {
                ConnectionData data = values[name];
                string[] row = {name, $"{data.IpAddress}:{data.Port}", data.UserName, data.LastAccessDate.ToString()};
                savedConnectionsView.Rows.Add(row);
            }


        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            m_ConnectionCache.flush();
        }
        // Split this into smaller functions
        private void newConnectionBtn_Click(object sender, EventArgs e)
        {
            m_ConnectionDialog = new NewConnectionDialog();
            m_ConnectionDialog.ShowDialog();
            // if the user clicked the 'X' instead of submitting
            if (!m_ConnectionDialog.ClosedBecauseSubmit)
                return;

            ConnectionData cd = new ConnectionData();

            cd.IpAddress = m_ConnectionDialog.IpAddress;
            cd.Port = m_ConnectionDialog.Port;
            cd.UserName = m_ConnectionDialog.UserName;
            
            MySqlConnection conn = createConnection(cd, m_ConnectionDialog.Password);

            if (conn.State != ConnectionState.Open)
                return;
            

            if (m_ConnectionDialog.SaveConnectionSettings)
            {
                m_ConnectionCache.addEntry(
                    m_ConnectionDialog.SaveConnectionName,
                    cd
                );
            }


            ShowLibraryInterface(conn);

        }

        private MySqlConnection createConnection(ConnectionData cd, string password)
        {

            string connectStr =
                $"server={cd.IpAddress};" +
                $"uid={cd.UserName};" +
                $"pwd={password};" +
                $"database=library";


            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connectStr;
                conn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return conn;
        }

        private void savedConnectionsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(savedConnectionsView.Rows[e.RowIndex].ToString());
          

        }

        private void savedConnectionsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CreateConnectionFromSelectedRow(e.RowIndex);
        }

        private void CreateConnectionFromSelectedRow(int RowIndex)
        {
            // ensures we have an valid index
            if (RowIndex < 0)
                return;

            DataGridViewCellCollection cell = savedConnectionsView.Rows[RowIndex].Cells;

            string[] ipPortMap = cell[1].Value.ToString().Split(':');

            ConnectionData cd = new ConnectionData()
            {
                IpAddress = ipPortMap[0],
                Port = int.Parse(ipPortMap[1]),
                UserName = cell[2].Value.ToString()
            };

            PasswordPrompt p = new PasswordPrompt(cd);
            p.ShowDialog();

            if (!p.PasswordSubmitted)
                return;
               
            MySqlConnection conn = createConnection(cd, p.Password);
            if (conn.State != ConnectionState.Open)
                return;

            m_ConnectionCache.UpdateAccess(cell[0].Value.ToString());
            ShowLibraryInterface(conn);
        }


        private void ShowLibraryInterface(MySqlConnection conn)
        {
            if(conn.State == ConnectionState.Open)
            {
                LibraryInterface mainInterface = new LibraryInterface(conn);
                mainInterface.ShowDialog();
                conn.Close();
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            CreateConnectionFromSelectedRow(savedConnectionsView.SelectedRows[0].Index);
        }
    }
}
