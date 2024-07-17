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
    public partial class NewClientForm : Form
    {
        public bool WasSubmitted { get; private set; }
        public string ClientName
        {
            get { return ClientNameTextBox.Text; }
        }
        public bool GetClientIsTeacher
        {
            get { return ClientIsTeacher.Checked; }
        }

        public NewClientForm()
        {
            WasSubmitted = false;
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            if(ClientNameTextBox.Text.Length == 0)
            {
                ClientNameLabel.ForeColor = Color.Red;
                return;
            }
            WasSubmitted = true;
            Close();
        }
    }
}
