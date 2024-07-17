namespace LIBDBGUI
{
    partial class MainMenu
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
            this.AppNameLabel = new System.Windows.Forms.Label();
            this.newConnectionBtn = new System.Windows.Forms.Button();
            this.savedConnectionsView = new System.Windows.Forms.DataGridView();
            this.ConnectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastAccessDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.savedConnectionsView)).BeginInit();
            this.SuspendLayout();
            // 
            // AppNameLabel
            // 
            this.AppNameLabel.AutoSize = true;
            this.AppNameLabel.Location = new System.Drawing.Point(229, 27);
            this.AppNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AppNameLabel.Name = "AppNameLabel";
            this.AppNameLabel.Size = new System.Drawing.Size(133, 15);
            this.AppNameLabel.TabIndex = 0;
            this.AppNameLabel.Text = "Library DBMS Interface";
            this.AppNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newConnectionBtn
            // 
            this.newConnectionBtn.Location = new System.Drawing.Point(26, 333);
            this.newConnectionBtn.Margin = new System.Windows.Forms.Padding(2);
            this.newConnectionBtn.Name = "newConnectionBtn";
            this.newConnectionBtn.Size = new System.Drawing.Size(112, 22);
            this.newConnectionBtn.TabIndex = 1;
            this.newConnectionBtn.Text = "New Connection";
            this.newConnectionBtn.UseVisualStyleBackColor = true;
            this.newConnectionBtn.Click += new System.EventHandler(this.newConnectionBtn_Click);
            // 
            // savedConnectionsView
            // 
            this.savedConnectionsView.AllowUserToAddRows = false;
            this.savedConnectionsView.AllowUserToDeleteRows = false;
            this.savedConnectionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.savedConnectionsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConnectionName,
            this.Location,
            this.UserName,
            this.LastAccessDate});
            this.savedConnectionsView.Location = new System.Drawing.Point(26, 64);
            this.savedConnectionsView.MultiSelect = false;
            this.savedConnectionsView.Name = "savedConnectionsView";
            this.savedConnectionsView.ReadOnly = true;
            this.savedConnectionsView.RowHeadersWidth = 51;
            this.savedConnectionsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.savedConnectionsView.Size = new System.Drawing.Size(552, 264);
            this.savedConnectionsView.TabIndex = 2;
            this.savedConnectionsView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.savedConnectionsView_CellClick);
            // 
            // ConnectionName
            // 
            this.ConnectionName.HeaderText = "Name";
            this.ConnectionName.MinimumWidth = 6;
            this.ConnectionName.Name = "ConnectionName";
            this.ConnectionName.ReadOnly = true;
            this.ConnectionName.Width = 125;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 125;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 125;
            // 
            // LastAccessDate
            // 
            this.LastAccessDate.HeaderText = "Last Access Date";
            this.LastAccessDate.MinimumWidth = 6;
            this.LastAccessDate.Name = "LastAccessDate";
            this.LastAccessDate.ReadOnly = true;
            this.LastAccessDate.Width = 125;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(143, 333);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.savedConnectionsView);
            this.Controls.Add(this.newConnectionBtn);
            this.Controls.Add(this.AppNameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.savedConnectionsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AppNameLabel;
        private System.Windows.Forms.Button newConnectionBtn;
        private System.Windows.Forms.DataGridView savedConnectionsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastAccessDate;
        private System.Windows.Forms.Button connectBtn;
    }
}

