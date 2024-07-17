namespace LIBDBGUI.ClientForms
{
    partial class CheckOutForm
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
            this.CheckOutButton = new System.Windows.Forms.Button();
            this.COFClientIDTextBox = new System.Windows.Forms.TextBox();
            this.COFISBNTextBox = new System.Windows.Forms.TextBox();
            this.COFClientIDLabel = new System.Windows.Forms.Label();
            this.COFBookIDLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckOutButton
            // 
            this.CheckOutButton.Location = new System.Drawing.Point(126, 157);
            this.CheckOutButton.Name = "CheckOutButton";
            this.CheckOutButton.Size = new System.Drawing.Size(91, 27);
            this.CheckOutButton.TabIndex = 0;
            this.CheckOutButton.Text = "Check Out";
            this.CheckOutButton.UseVisualStyleBackColor = true;
            this.CheckOutButton.Click += new System.EventHandler(this.CheckOutButton_Click);
            // 
            // COFClientIDTextBox
            // 
            this.COFClientIDTextBox.Location = new System.Drawing.Point(71, 42);
            this.COFClientIDTextBox.Name = "COFClientIDTextBox";
            this.COFClientIDTextBox.Size = new System.Drawing.Size(182, 20);
            this.COFClientIDTextBox.TabIndex = 1;
            // 
            // COFISBNTextBox
            // 
            this.COFISBNTextBox.Location = new System.Drawing.Point(71, 93);
            this.COFISBNTextBox.Name = "COFISBNTextBox";
            this.COFISBNTextBox.Size = new System.Drawing.Size(182, 20);
            this.COFISBNTextBox.TabIndex = 2;
            // 
            // COFClientIDLabel
            // 
            this.COFClientIDLabel.AutoSize = true;
            this.COFClientIDLabel.Location = new System.Drawing.Point(12, 47);
            this.COFClientIDLabel.Name = "COFClientIDLabel";
            this.COFClientIDLabel.Size = new System.Drawing.Size(53, 15);
            this.COFClientIDLabel.TabIndex = 3;
            this.COFClientIDLabel.Text = "Client ID";
            // 
            // COFBookIDLabel
            // 
            this.COFBookIDLabel.AutoSize = true;
            this.COFBookIDLabel.Location = new System.Drawing.Point(12, 96);
            this.COFBookIDLabel.Name = "COFBookIDLabel";
            this.COFBookIDLabel.Size = new System.Drawing.Size(35, 15);
            this.COFBookIDLabel.TabIndex = 4;
            this.COFBookIDLabel.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Check Out Form";
            // 
            // CheckOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 195);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.COFBookIDLabel);
            this.Controls.Add(this.COFClientIDLabel);
            this.Controls.Add(this.COFISBNTextBox);
            this.Controls.Add(this.COFClientIDTextBox);
            this.Controls.Add(this.CheckOutButton);
            this.Name = "CheckOutForm";
            this.Text = "Check Out Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckOutButton;
        private System.Windows.Forms.TextBox COFClientIDTextBox;
        private System.Windows.Forms.TextBox COFISBNTextBox;
        private System.Windows.Forms.Label COFClientIDLabel;
        private System.Windows.Forms.Label COFBookIDLabel;
        private System.Windows.Forms.Label label3;
    }
}