using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CForm_Planner.NoteSystem
{
    public partial class NoteDetailForm : Form
    {
        public NoteAdministration noteAdministration;
        public Note details;
        public NoteDetailForm()
        {
            InitializeComponent();
        }

        private void ChangeNote_button_Click(object sender, EventArgs e)
        {
            if (NoteInfo_textBox.Text != "")
            {
                try
                {
                    Note changedNote = new Note(NoteInfo_textBox.Text, "");
                    noteAdministration.ChangeNote(details, changedNote);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RemoveNote_button_Click(object sender, EventArgs e)
        {
            try
            {
                noteAdministration.RemoveNote(details);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Detail_Refresh()
        {
            if (details != null)
            {
                NoteInfo_textBox.Text = details.Information;
            }
        }

        private void NoteDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
