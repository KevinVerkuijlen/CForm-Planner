namespace CForm_Planner.AccountSystem.AccountForms
{
    partial class LoginForm
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
            this.Email_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Register_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Email_label
            // 
            this.Email_label.AutoSize = true;
            this.Email_label.Location = new System.Drawing.Point(90, 55);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(138, 25);
            this.Email_label.TabIndex = 0;
            this.Email_label.Text = "Email Adress";
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(108, 167);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(106, 25);
            this.Password_label.TabIndex = 1;
            this.Password_label.Text = "Password";
            // 
            // Login_button
            // 
            this.Login_button.Location = new System.Drawing.Point(113, 256);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(89, 45);
            this.Login_button.TabIndex = 3;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(12, 205);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(303, 31);
            this.Password_textBox.TabIndex = 5;
            // 
            // Register_button
            // 
            this.Register_button.Location = new System.Drawing.Point(91, 451);
            this.Register_button.Name = "Register_button";
            this.Register_button.Size = new System.Drawing.Size(123, 55);
            this.Register_button.TabIndex = 4;
            this.Register_button.Text = "Register";
            this.Register_button.UseVisualStyleBackColor = true;
            this.Register_button.Click += new System.EventHandler(this.Register_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 75);
            this.label3.TabIndex = 2;
            this.label3.Text = "if you don\'t have an \r\naccount yet you can \r\nregister yourself here";
            // 
            // Email_textBox
            // 
            this.Email_textBox.Location = new System.Drawing.Point(12, 95);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(303, 31);
            this.Email_textBox.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 617);
            this.Controls.Add(this.Email_textBox);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Register_button);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Email_label);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Button Register_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Email_textBox;
    }
}