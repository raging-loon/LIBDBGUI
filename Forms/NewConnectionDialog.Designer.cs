namespace LIBDBGUI
{
    partial class NewConnectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ncdIpAddressLabel = new System.Windows.Forms.Label();
            this.ncdUserLabel = new System.Windows.Forms.Label();
            this.ncdPasswordLabel = new System.Windows.Forms.Label();
            this.ncdIpAddressTextBox = new System.Windows.Forms.TextBox();
            this.ncdUserTextBox = new System.Windows.Forms.TextBox();
            this.ncdPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ncdConnectBtn = new System.Windows.Forms.Button();
            this.ncdPortLabel = new System.Windows.Forms.Label();
            this.ncdPortNupDown = new System.Windows.Forms.NumericUpDown();
            this.ncdSaveSettingsOption = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ncdSaveNameLabel = new System.Windows.Forms.Label();
            this.ncdSaveName = new System.Windows.Forms.TextBox();
            this.ncdSaveConnectionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ncdPortNupDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ncdIpAddressLabel
            // 
            this.ncdIpAddressLabel.AutoSize = true;
            this.ncdIpAddressLabel.Location = new System.Drawing.Point(12, 22);
            this.ncdIpAddressLabel.Name = "ncdIpAddressLabel";
            this.ncdIpAddressLabel.Size = new System.Drawing.Size(73, 16);
            this.ncdIpAddressLabel.TabIndex = 0;
            this.ncdIpAddressLabel.Text = "IP Address";
            // 
            // ncdUserLabel
            // 
            this.ncdUserLabel.AutoSize = true;
            this.ncdUserLabel.Location = new System.Drawing.Point(12, 54);
            this.ncdUserLabel.Name = "ncdUserLabel";
            this.ncdUserLabel.Size = new System.Drawing.Size(36, 16);
            this.ncdUserLabel.TabIndex = 1;
            this.ncdUserLabel.Text = "User";
            // 
            // ncdPasswordLabel
            // 
            this.ncdPasswordLabel.AutoSize = true;
            this.ncdPasswordLabel.Location = new System.Drawing.Point(12, 85);
            this.ncdPasswordLabel.Name = "ncdPasswordLabel";
            this.ncdPasswordLabel.Size = new System.Drawing.Size(67, 16);
            this.ncdPasswordLabel.TabIndex = 2;
            this.ncdPasswordLabel.Text = "Password";
            // 
            // ncdIpAddressTextBox
            // 
            this.ncdIpAddressTextBox.Location = new System.Drawing.Point(91, 20);
            this.ncdIpAddressTextBox.Name = "ncdIpAddressTextBox";
            this.ncdIpAddressTextBox.Size = new System.Drawing.Size(130, 22);
            this.ncdIpAddressTextBox.TabIndex = 3;
            this.ncdIpAddressTextBox.WordWrap = false;
            // 
            // ncdUserTextBox
            // 
            this.ncdUserTextBox.Location = new System.Drawing.Point(91, 51);
            this.ncdUserTextBox.Name = "ncdUserTextBox";
            this.ncdUserTextBox.Size = new System.Drawing.Size(130, 22);
            this.ncdUserTextBox.TabIndex = 4;
            // 
            // ncdPasswordTextBox
            // 
            this.ncdPasswordTextBox.Location = new System.Drawing.Point(91, 82);
            this.ncdPasswordTextBox.Name = "ncdPasswordTextBox";
            this.ncdPasswordTextBox.PasswordChar = '*';
            this.ncdPasswordTextBox.Size = new System.Drawing.Size(130, 22);
            this.ncdPasswordTextBox.TabIndex = 5;
            // 
            // ncdConnectBtn
            // 
            this.ncdConnectBtn.Location = new System.Drawing.Point(196, 122);
            this.ncdConnectBtn.Name = "ncdConnectBtn";
            this.ncdConnectBtn.Size = new System.Drawing.Size(75, 24);
            this.ncdConnectBtn.TabIndex = 6;
            this.ncdConnectBtn.Text = "Connect";
            this.ncdConnectBtn.UseVisualStyleBackColor = true;
            this.ncdConnectBtn.Click += new System.EventHandler(this.ncdConnectBtn_Click);
            // 
            // ncdPortLabel
            // 
            this.ncdPortLabel.AutoSize = true;
            this.ncdPortLabel.Location = new System.Drawing.Point(227, 22);
            this.ncdPortLabel.Name = "ncdPortLabel";
            this.ncdPortLabel.Size = new System.Drawing.Size(31, 16);
            this.ncdPortLabel.TabIndex = 7;
            this.ncdPortLabel.Text = "Port";
            // 
            // ncdPortNupDown
            // 
            this.ncdPortNupDown.AccessibleDescription = "Target Port";
            this.ncdPortNupDown.Location = new System.Drawing.Point(385, 20);
            this.ncdPortNupDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ncdPortNupDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ncdPortNupDown.Name = "ncdPortNupDown";
            this.ncdPortNupDown.Size = new System.Drawing.Size(67, 22);
            this.ncdPortNupDown.TabIndex = 8;
            this.ncdPortNupDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ncdPortNupDown.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // ncdSaveSettingsOption
            // 
            this.ncdSaveSettingsOption.AccessibleDescription = "";
            this.ncdSaveSettingsOption.AccessibleName = "";
            this.ncdSaveSettingsOption.AutoSize = true;
            this.ncdSaveSettingsOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ncdSaveSettingsOption.Location = new System.Drawing.Point(434, 54);
            this.ncdSaveSettingsOption.Name = "ncdSaveSettingsOption";
            this.ncdSaveSettingsOption.Size = new System.Drawing.Size(18, 17);
            this.ncdSaveSettingsOption.TabIndex = 10;
            this.toolTip1.SetToolTip(this.ncdSaveSettingsOption, "This will NOT save the password");
            this.ncdSaveSettingsOption.UseVisualStyleBackColor = true;
            this.ncdSaveSettingsOption.CheckedChanged += new System.EventHandler(this.ncdSaveSettingsOption_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            // 
            // ncdSaveNameLabel
            // 
            this.ncdSaveNameLabel.AutoSize = true;
            this.ncdSaveNameLabel.Enabled = false;
            this.ncdSaveNameLabel.Location = new System.Drawing.Point(227, 85);
            this.ncdSaveNameLabel.Name = "ncdSaveNameLabel";
            this.ncdSaveNameLabel.Size = new System.Drawing.Size(114, 16);
            this.ncdSaveNameLabel.TabIndex = 11;
            this.ncdSaveNameLabel.Text = "Connection Name";
            // 
            // ncdSaveName
            // 
            this.ncdSaveName.Enabled = false;
            this.ncdSaveName.Location = new System.Drawing.Point(347, 82);
            this.ncdSaveName.Name = "ncdSaveName";
            this.ncdSaveName.Size = new System.Drawing.Size(105, 22);
            this.ncdSaveName.TabIndex = 12;
            // 
            // ncdSaveConnectionLabel
            // 
            this.ncdSaveConnectionLabel.AutoSize = true;
            this.ncdSaveConnectionLabel.Location = new System.Drawing.Point(227, 52);
            this.ncdSaveConnectionLabel.Name = "ncdSaveConnectionLabel";
            this.ncdSaveConnectionLabel.Size = new System.Drawing.Size(160, 16);
            this.ncdSaveConnectionLabel.TabIndex = 10;
            this.ncdSaveConnectionLabel.Text = "Save Connection Settings";
            // 
            // NewConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 162);
            this.Controls.Add(this.ncdSaveConnectionLabel);
            this.Controls.Add(this.ncdSaveName);
            this.Controls.Add(this.ncdSaveNameLabel);
            this.Controls.Add(this.ncdSaveSettingsOption);
            this.Controls.Add(this.ncdPortNupDown);
            this.Controls.Add(this.ncdPortLabel);
            this.Controls.Add(this.ncdConnectBtn);
            this.Controls.Add(this.ncdPasswordTextBox);
            this.Controls.Add(this.ncdUserTextBox);
            this.Controls.Add(this.ncdIpAddressTextBox);
            this.Controls.Add(this.ncdPasswordLabel);
            this.Controls.Add(this.ncdUserLabel);
            this.Controls.Add(this.ncdIpAddressLabel);
            this.MaximumSize = new System.Drawing.Size(490, 209);
            this.MinimumSize = new System.Drawing.Size(490, 209);
            this.Name = "NewConnectionDialog";
            this.Text = "New MySQL Connection";
            ((System.ComponentModel.ISupportInitialize)(this.ncdPortNupDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ncdIpAddressLabel;
        private System.Windows.Forms.Label ncdUserLabel;
        private System.Windows.Forms.Label ncdPasswordLabel;
        private System.Windows.Forms.TextBox ncdIpAddressTextBox;
        private System.Windows.Forms.TextBox ncdUserTextBox;
        private System.Windows.Forms.TextBox ncdPasswordTextBox;
        private System.Windows.Forms.Button ncdConnectBtn;
        private System.Windows.Forms.Label ncdPortLabel;
        private System.Windows.Forms.NumericUpDown ncdPortNupDown;
        private System.Windows.Forms.CheckBox ncdSaveSettingsOption;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label ncdSaveNameLabel;
        private System.Windows.Forms.TextBox ncdSaveName;
        private System.Windows.Forms.Label ncdSaveConnectionLabel;
    }
}