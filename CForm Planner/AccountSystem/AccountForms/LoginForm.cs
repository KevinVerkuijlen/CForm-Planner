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
        public Administration administration;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            if (Email_textBox.Text != "")
            {
                if (Password_textBox.Text != "")
                {
                    administration.LoginAccount(Email_textBox.Text, Password_textBox.Text);
                    if (administration.user != null)
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
            RegisterForm form = new RegisterForm();
            form.administration = this.administration;
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.administration = form.administration;
                this.Visible = true;
            } 
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
