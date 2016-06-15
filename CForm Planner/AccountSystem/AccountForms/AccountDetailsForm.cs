using System;
using System.Windows.Forms;

namespace CForm_Planner.AccountSystem.AccountForms
{
    public partial class AccountDetailsForm : Form
    {
        public Administration Administration { get; private set; }

        public AccountDetailsForm(Administration administration)
        {
            InitializeComponent();
            Administration = administration;
        }

        private void ChangeAccount_button_Click(object sender, EventArgs e)
        {
            if (FirstName_textBox.Text != "")
            {
                if (LastName_textBox.Text != "")
                {
                    if (Password_textBox.Text != "")
                    {
                        DialogResult result =
                            MessageBox.Show(
                                "Are you sure?",
                                "Confirm",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {

                                Administration.UpdateAccount(FirstName_textBox.Text, LastName_textBox.Text,
                                    Password_textBox.Text);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill in a Password");
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

        public void DetailRefresh()
        {
            FirstName_textBox.Text = Administration.User.Name;
            LastName_textBox.Text = Administration.User.LastName;
            Email_textBox.Text = Administration.User.EmailAdress;
        }

        private void Logout_button_Click(object sender, EventArgs e)
        {
            Administration.LogoutAccount();
            this.DialogResult = DialogResult.OK;
        }
    }
}
