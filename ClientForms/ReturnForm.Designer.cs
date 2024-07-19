namespace LIBDBGUI.ClientForms
{
    partial class ReturnForm
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
            this.RFNameLabel = new System.Windows.Forms.Label();
            this.ReturnClientIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RFSubmitButton = new System.Windows.Forms.Button();
            this.RFISBNList = new System.Windows.Forms.DataGridView();
            this.ISBNList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RFISBNList)).BeginInit();
            this.SuspendLayout();
            // 
            // RFNameLabel
            // 
            this.RFNameLabel.AutoSize = true;
            this.RFNameLabel.Location = new System.Drawing.Point(128, 9);
            this.RFNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RFNameLabel.Name = "RFNameLabel";
            this.RFNameLabel.Size = new System.Drawing.Size(76, 15);
            this.RFNameLabel.TabIndex = 0;
            this.RFNameLabel.Text = "Return Form";
            // 
            // ReturnClientIDTextBox
            // 
            this.ReturnClientIDTextBox.Location = new System.Drawing.Point(74, 49);
            this.ReturnClientIDTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ReturnClientIDTextBox.Name = "ReturnClientIDTextBox";
            this.ReturnClientIDTextBox.Size = new System.Drawing.Size(153, 20);
            this.ReturnClientIDTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Client ID";
            // 
            // RFSubmitButton
            // 
            this.RFSubmitButton.Location = new System.Drawing.Point(260, 44);
            this.RFSubmitButton.Name = "RFSubmitButton";
            this.RFSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.RFSubmitButton.TabIndex = 5;
            this.RFSubmitButton.Text = "Submit";
            this.RFSubmitButton.UseVisualStyleBackColor = true;
            this.RFSubmitButton.Click += new System.EventHandler(this.RFSubmitButton_Click);
            // 
            // RFISBNList
            // 
            this.RFISBNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RFISBNList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBNList});
            this.RFISBNList.Location = new System.Drawing.Point(38, 74);
            this.RFISBNList.Name = "RFISBNList";
            this.RFISBNList.RowHeadersWidth = 51;
            this.RFISBNList.Size = new System.Drawing.Size(189, 316);
            this.RFISBNList.TabIndex = 6;
            // 
            // ISBNList
            // 
            this.ISBNList.HeaderText = "ISBN";
            this.ISBNList.MinimumWidth = 6;
            this.ISBNList.Name = "ISBNList";
            this.ISBNList.Width = 125;
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 402);
            this.Controls.Add(this.RFISBNList);
            this.Controls.Add(this.RFSubmitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReturnClientIDTextBox);
            this.Controls.Add(this.RFNameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReturnForm";
            this.Text = "486, 287";
            ((System.ComponentModel.ISupportInitialize)(this.RFISBNList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RFNameLabel;
        private System.Windows.Forms.TextBox ReturnClientIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RFSubmitButton;
        private System.Windows.Forms.DataGridView RFISBNList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBNList;
    }
}