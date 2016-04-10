namespace CForm_Planner.AccountSystem.AccountForms
{
    partial class AccountDetailsForm
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
            this.ChangeAccount_button = new System.Windows.Forms.Button();
            this.FirstName_textBox = new System.Windows.Forms.TextBox();
            this.LastName_textBox = new System.Windows.Forms.TextBox();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Email_label = new System.Windows.Forms.Label();
            this.LastName_label = new System.Windows.Forms.Label();
            this.FirstName_label = new System.Windows.Forms.Label();
            this.Logout_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeAccount_button
            // 
            this.ChangeAccount_button.Location = new System.Drawing.Point(82, 206);
            this.ChangeAccount_button.Name = "ChangeAccount_button";
            this.ChangeAccount_button.Size = new System.Drawing.Size(347, 47);
            this.ChangeAccount_button.TabIndex = 22;
            this.ChangeAccount_button.Text = "Change account information";
            this.ChangeAccount_button.UseVisualStyleBackColor = true;
            this.ChangeAccount_button.Click += new System.EventHandler(this.ChangeAccount_button_Click);
            // 
            // FirstName_textBox
            // 
            this.FirstName_textBox.Location = new System.Drawing.Point(190, 10);
            this.FirstName_textBox.Name = "FirstName_textBox";
            this.FirstName_textBox.Size = new System.Drawing.Size(303, 31);
            this.FirstName_textBox.TabIndex = 21;
            // 
            // LastName_textBox
            // 
            this.LastName_textBox.Location = new System.Drawing.Point(190, 56);
            this.LastName_textBox.Name = "LastName_textBox";
            this.LastName_textBox.Size = new System.Drawing.Size(303, 31);
            this.LastName_textBox.TabIndex = 20;
            // 
            // Email_textBox
            // 
            this.Email_textBox.Enabled = false;
            this.Email_textBox.Location = new System.Drawing.Point(190, 109);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(303, 31);
            this.Email_textBox.TabIndex = 19;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(190, 155);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(303, 31);
            this.Password_textBox.TabIndex = 18;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(16, 155);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(112, 25);
            this.Password_label.TabIndex = 17;
            this.Password_label.Text = "Password:";
            // 
            // Email_label
            // 
            this.Email_label.AutoSize = true;
            this.Email_label.Location = new System.Drawing.Point(16, 109);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(144, 25);
            this.Email_label.TabIndex = 16;
            this.Email_label.Text = "Email Adress:";
            // 
            // LastName_label
            // 
            this.LastName_label.AutoSize = true;
            this.LastName_label.Location = new System.Drawing.Point(16, 62);
            this.LastName_label.Name = "LastName_label";
            this.LastName_label.Size = new System.Drawing.Size(121, 25);
            this.LastName_label.TabIndex = 15;
            this.LastName_label.Text = "Last Name:";
            // 
            // FirstName_label
            // 
            this.FirstName_label.AutoSize = true;
            this.FirstName_label.Location = new System.Drawing.Point(16, 16);
            this.FirstName_label.Name = "FirstName_label";
            this.FirstName_label.Size = new System.Drawing.Size(122, 25);
            this.FirstName_label.TabIndex = 14;
            this.FirstName_label.Text = "First Name:";
            // 
            // Logout_button
            // 
            this.Logout_button.Location = new System.Drawing.Point(82, 260);
            this.Logout_button.Name = "Logout_button";
            this.Logout_button.Size = new System.Drawing.Size(347, 59);
            this.Logout_button.TabIndex = 23;
            this.Logout_button.Text = "Logout";
            this.Logout_button.UseVisualStyleBackColor = true;
            this.Logout_button.Click += new System.EventHandler(this.Logout_button_Click);
            // 
            // AccountDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 341);
            this.Controls.Add(this.Logout_button);
            this.Controls.Add(this.ChangeAccount_button);
            this.Controls.Add(this.FirstName_textBox);
            this.Controls.Add(this.LastName_textBox);
            this.Controls.Add(this.Email_textBox);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Email_label);
            this.Controls.Add(this.LastName_label);
            this.Controls.Add(this.FirstName_label);
            this.Name = "AccountDetailsForm";
            this.Text = "AccountDetailsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountDetailsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeAccount_button;
        private System.Windows.Forms.TextBox FirstName_textBox;
        private System.Windows.Forms.TextBox LastName_textBox;
        private System.Windows.Forms.TextBox Email_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.Label LastName_label;
        private System.Windows.Forms.Label FirstName_label;
        private System.Windows.Forms.Button Logout_button;
    }
}