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
    public partial class RegisterForm : Form
    {
        public Administration Administration { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public RegisterForm(Administration administration)
        {
            Administration = administration;
            InitializeComponent();
        }

        private void CompRegister_button_Click(object sender, EventArgs e)
        {
            if(FirstName_textBox.Text != "")
            {
                if(LastName_textBox.Text != "")
                {
                    if(Email_textBox.Text != "")
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
                                    Email = Email_textBox.Text;
                                    Password = Password_textBox.Text;
                                    Administration.Register(FirstName_textBox.Text, LastName_textBox.Text, Email, Password);
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

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
