using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    public partial class PasswordPrompt : Form
    {
        /// <summary>
        /// Was this Form closed via the Exit button?
        /// </summary>
        public bool PasswordSubmitted { get; private set; }
        
        public string Password 
        { 
            get { return passwordTextBox.Text; } 
        }

        public PasswordPrompt(ConnectionData cd)
        {
            InitializeComponent();
            PasswordSubmitted = false;
            infoLabel.Text = $"{cd.UserName} @ {cd.IpAddress}:{cd.Port}";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length == 0)
                passwordTextBox.Focus();
            else
            {
                PasswordSubmitted = true;
                Close();
            }
        }
        
    }
}
