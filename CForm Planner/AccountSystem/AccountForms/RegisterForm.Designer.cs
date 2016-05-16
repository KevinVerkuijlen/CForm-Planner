namespace CForm_Planner.AccountSystem.AccountForms
{
    partial class RegisterForm
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
            this.FirstName_label = new System.Windows.Forms.Label();
            this.LastName_label = new System.Windows.Forms.Label();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Email_label = new System.Windows.Forms.Label();
            this.LastName_textBox = new System.Windows.Forms.TextBox();
            this.FirstName_textBox = new System.Windows.Forms.TextBox();
            this.CompRegister_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstName_label
            // 
            this.FirstName_label.AutoSize = true;
            this.FirstName_label.Location = new System.Drawing.Point(12, 31);
            this.FirstName_label.Name = "FirstName_label";
            this.FirstName_label.Size = new System.Drawing.Size(122, 25);
            this.FirstName_label.TabIndex = 0;
            this.FirstName_label.Text = "First Name:";
            // 
            // LastName_label
            // 
            this.LastName_label.AutoSize = true;
            this.LastName_label.Location = new System.Drawing.Point(12, 77);
            this.LastName_label.Name = "LastName_label";
            this.LastName_label.Size = new System.Drawing.Size(121, 25);
            this.LastName_label.TabIndex = 1;
            this.LastName_label.Text = "Last Name:";
            // 
            // Email_textBox
            // 
            this.Email_textBox.Location = new System.Drawing.Point(186, 124);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(303, 31);
            this.Email_textBox.TabIndex = 10;
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(186, 170);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(303, 31);
            this.Password_textBox.TabIndex = 9;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(12, 170);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(112, 25);
            this.Password_label.TabIndex = 8;
            this.Password_label.Text = "Password:";
            // 
            // Email_label
            // 
            this.Email_label.AutoSize = true;
            this.Email_label.Location = new System.Drawing.Point(12, 124);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(144, 25);
            this.Email_label.TabIndex = 7;
            this.Email_label.Text = "Email Adress:";
            // 
            // LastName_textBox
            // 
            this.LastName_textBox.Location = new System.Drawing.Point(186, 71);
            this.LastName_textBox.Name = "LastName_textBox";
            this.LastName_textBox.Size = new System.Drawing.Size(303, 31);
            this.LastName_textBox.TabIndex = 11;
            // 
            // FirstName_textBox
            // 
            this.FirstName_textBox.Location = new System.Drawing.Point(186, 25);
            this.FirstName_textBox.Name = "FirstName_textBox";
            this.FirstName_textBox.Size = new System.Drawing.Size(303, 31);
            this.FirstName_textBox.TabIndex = 12;
            // 
            // CompRegister_button
            // 
            this.CompRegister_button.Location = new System.Drawing.Point(78, 223);
            this.CompRegister_button.Name = "CompRegister_button";
            this.CompRegister_button.Size = new System.Drawing.Size(349, 45);
            this.CompRegister_button.TabIndex = 13;
            this.CompRegister_button.Text = "Complete registration";
            this.CompRegister_button.UseVisualStyleBackColor = true;
            this.CompRegister_button.Click += new System.EventHandler(this.CompRegister_button_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 283);
            this.Controls.Add(this.CompRegister_button);
            this.Controls.Add(this.FirstName_textBox);
            this.Controls.Add(this.LastName_textBox);
            this.Controls.Add(this.Email_textBox);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Email_label);
            this.Controls.Add(this.LastName_label);
            this.Controls.Add(this.FirstName_label);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstName_label;
        private System.Windows.Forms.Label LastName_label;
        private System.Windows.Forms.TextBox Email_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.TextBox LastName_textBox;
        private System.Windows.Forms.TextBox FirstName_textBox;
        private System.Windows.Forms.Button CompRegister_button;
    }
}