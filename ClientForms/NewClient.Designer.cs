namespace LIBDBGUI.ClientForms
{
    partial class NewClientForm
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
            this.ClientNameLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ClientNameTextBox = new System.Windows.Forms.TextBox();
            this.ClientIsTeacher = new System.Windows.Forms.CheckBox();
            this.NewClientLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClientNameLabel
            // 
            this.ClientNameLabel.AutoSize = true;
            this.ClientNameLabel.Location = new System.Drawing.Point(12, 47);
            this.ClientNameLabel.Name = "ClientNameLabel";
            this.ClientNameLabel.Size = new System.Drawing.Size(94, 19);
            this.ClientNameLabel.TabIndex = 0;
            this.ClientNameLabel.Text = "Client Name";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(123, 104);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(68, 24);
            this.SubmitButton.TabIndex = 1;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ClientNameTextBox
            // 
            this.ClientNameTextBox.Location = new System.Drawing.Point(86, 44);
            this.ClientNameTextBox.Name = "ClientNameTextBox";
            this.ClientNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.ClientNameTextBox.TabIndex = 2;
            // 
            // ClientIsTeacher
            // 
            this.ClientIsTeacher.AutoSize = true;
            this.ClientIsTeacher.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClientIsTeacher.Location = new System.Drawing.Point(12, 70);
            this.ClientIsTeacher.Name = "ClientIsTeacher";
            this.ClientIsTeacher.Size = new System.Drawing.Size(133, 19);
            this.ClientIsTeacher.TabIndex = 3;
            this.ClientIsTeacher.Text = "Client is a teacher?";
            this.ClientIsTeacher.UseVisualStyleBackColor = true;
            // 
            // NewClientLabel
            // 
            this.NewClientLabel.AutoSize = true;
            this.NewClientLabel.Location = new System.Drawing.Point(105, 9);
            this.NewClientLabel.Name = "NewClientLabel";
            this.NewClientLabel.Size = new System.Drawing.Size(98, 15);
            this.NewClientLabel.TabIndex = 4;
            this.NewClientLabel.Text = "New Client Form";
            // 
            // NewClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 140);
            this.Controls.Add(this.NewClientLabel);
            this.Controls.Add(this.ClientIsTeacher);
            this.Controls.Add(this.ClientNameTextBox);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.ClientNameLabel);
            this.Name = "NewClientForm";
            this.Text = "New Client Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClientNameLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.TextBox ClientNameTextBox;
        private System.Windows.Forms.CheckBox ClientIsTeacher;
        private System.Windows.Forms.Label NewClientLabel;
    }
}