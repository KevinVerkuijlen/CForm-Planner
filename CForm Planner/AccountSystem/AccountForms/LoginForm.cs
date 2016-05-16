using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CForm_Planner.AccountSystem.AccountForms
{
    public partial class LoginForm : Form
    {
        public Administration Administration { get; private set; }
        public LoginForm(Administration administration)
        {
            InitializeComponent();
            Administration = administration;
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            if (Email_textBox.Text != "")
            {
                if (Password_textBox.Text != "")
                {
                    Administration.LoginAccount(Email_textBox.Text, Password_textBox.Text);
                    if (Administration.User != null)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find an account with this email and password combination");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in a password");
                }
            }
            else
            {
                MessageBox.Show("Please fill in a email adress");
            }
            
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm(Administration);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Administration = form.Administration;
                Administration.LoginAccount(form.Email, form.Password);
                if (Administration.User != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
            } 
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
