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
    public partial class CheckOutForm : Form
    {
        public bool CloseFromSubmit { get; private set; }

        public int ClientID
        {
            get { return int.Parse(COFClientIDTextBox.Text); }
        }

        public string ISBN
        {
            get { return COFISBNTextBox.Text; }
        }

        public CheckOutForm()
        {
            CloseFromSubmit = false;
            InitializeComponent();
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            if(COFClientIDTextBox.Text.Length == 0 )
            {
                COFClientIDTextBox.Focus();
                return;
            }
            if(COFISBNTextBox.Text.Length == 0 )
            {
                COFISBNTextBox.Focus();
                return;
            }
            CloseFromSubmit = true;

            Close();
        }
    }
}
