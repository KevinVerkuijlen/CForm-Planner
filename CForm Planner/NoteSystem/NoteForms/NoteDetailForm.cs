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
        public NoteAdministration NoteAdministration { get; }
        public Note Note { get; }

        public NoteDetailForm(Note note, NoteAdministration noteAdministration)
        {
            Note = note;
            NoteAdministration = noteAdministration;
            InitializeComponent();
        }

        private void ChangeNote_button_Click(object sender, EventArgs e)
        {
            if (NoteInfo_textBox.Text != "")
            {
                try
                {
                    NoteAdministration.ChangeNote(Note, NoteInfo_textBox.Text);
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
                NoteAdministration.RemoveNote(Note);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Detail_Refresh()
        {
            if (Note != null)
            {
                NoteInfo_textBox.Text = Note.Information;
            }
        }

        private void NoteDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
