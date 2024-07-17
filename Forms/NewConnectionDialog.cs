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
    public partial class NewConnectionDialog : Form
    {
        public string IpAddress 
        { 
            get { return ncdIpAddressTextBox.Text; } 
        }

        public string UserName
        {
            get { return ncdUserTextBox.Text; }
        }

        public string Password
        {
            get { return ncdPasswordTextBox.Text; }
        }

        public bool SaveConnectionSettings
        {
            get { return ncdSaveSettingsOption.Checked; }
        }

        public string SaveConnectionName 
        {
            get {  return ncdSaveName.Text; } 
        }

        public int Port
        {
            get { return ((int)ncdPortNupDown.Value); }
        }

        // evoked when this dialog closes
        //public event DialogClosed;
        public NewConnectionDialog()
        {
            ClosedBecauseSubmit = false;
            InitializeComponent();
        }

        public bool ClosedBecauseSubmit { get; private set; }

        private void ncdConnectBtn_Click(object sender, EventArgs e)
        {
            ResetInvalidValuesIndicator();

            if(CheckConnectionValues())
            {
                ClosedBecauseSubmit = true;
                this.Close();
            }
        }

        private void ResetInvalidValuesIndicator()
        {
            ncdIpAddressLabel.ForeColor = Color.Black;
            ncdPasswordLabel.ForeColor  = Color.Black;
            ncdUserLabel.ForeColor      = Color.Black;
            ncdSaveNameLabel.ForeColor  = Color.Black;

        }

        private bool CheckConnectionValues()
        {
            if(ncdIpAddressTextBox.Text.Length == 0)
            {
                ncdIpAddressLabel.ForeColor = Color.Red;
                return false;
            }

            if(ncdUserTextBox.Text.Length == 0)
            {
                ncdUserLabel.ForeColor = Color.Red;
                return false;
            }

            if(ncdPasswordTextBox.Text.Length == 0)
            {
                ncdPasswordLabel.ForeColor = Color.Red;
                return false;
            }

            if(ncdSaveSettingsOption.Checked && ncdSaveName.Text.Length == 0)
            {
                ncdSaveNameLabel.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private void ncdSaveSettingsOption_CheckedChanged(object sender, EventArgs e)
        {
            ncdSaveName.Enabled = !ncdSaveName.Enabled;
            ncdSaveNameLabel.Enabled = !ncdSaveNameLabel.Enabled;
        }
    }
}
