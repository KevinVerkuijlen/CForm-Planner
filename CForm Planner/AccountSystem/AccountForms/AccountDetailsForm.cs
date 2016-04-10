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
    public partial class AccountDetailsForm : Form
    {
        public Administration administration;

        public AccountDetailsForm()
        {
            InitializeComponent();
        }

        private void ChangeAccount_button_Click(object sender, EventArgs e)
        {
            if (FirstName_textBox.Text != "")
            {
                if (LastName_textBox.Text != "")
                {
                    if (Email_textBox.Text != "")
                    {
                        if (Password_textBox.Text != "")
                        {
                            Account changedAccount = new Account(FirstName_textBox.Text, LastName_textBox.Text, Email_textBox.Text, Password_textBox.Text);
                            try
                            {
                                administration.UpdateAccount(changedAccount);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill in a Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill in a email adress");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in a last name");
                }
            }
            else
            {
                MessageBox.Show("Please fill in a firstname");
            }
        }

        private void AccountDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void refresh()
        {
            FirstName_textBox.Text = administration.user.Name;
            LastName_textBox.Text = administration.user.LastName;
            Email_textBox.Text = administration.user.EmailAdress;
            Password_textBox.Text = administration.user.Password;
        }

        private void Logout_button_Click(object sender, EventArgs e)
        {
            administration.user = null;
            this.DialogResult = DialogResult.OK;
        }
    }
}
