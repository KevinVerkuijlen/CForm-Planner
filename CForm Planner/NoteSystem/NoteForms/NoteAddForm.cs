using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.NoteSystem
{
    public partial class NoteAddForm : Form
    {
        public NoteAdministration NoteAdministration { get; }
        public Account Account { get; }

        public NoteAddForm(Account account, NoteAdministration noteAdministration)
        {
            Account = account;
            NoteAdministration = noteAdministration;
            InitializeComponent();
        }

        private void AddNote_button_Click(object sender, EventArgs e)
        {
            string userEmail = "";
            if (Account != null)
            {
                userEmail = Account.EmailAdress;
            }
            if (NoteInfo_textBox.Text != "")
            {
                try
                {
                    NoteAdministration.AddNote(NoteInfo_textBox.Text, userEmail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please fill  in some information for the note");
            }
            
        }

        private void NoteAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
