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
    public partial class NoteForm : Form
    {
        public NoteAdministration noteAdministration = new NoteAdministration();
        public NoteForm()
        {
            InitializeComponent();
        }

        private void NewNote_button_Click(object sender, EventArgs e)
        {
            NoteAddForm form = new NoteAddForm();
            form.noteAdministration = this.noteAdministration;
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.noteAdministration = form.noteAdministration;
                this.Visible = true;
                Note_Refresh();
            }
        }

        private void Notes_checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Notes_checkedListBox.SelectedItem != null)
            {
                NoteDetailForm form = new NoteDetailForm();
                form.noteAdministration = this.noteAdministration;
                foreach (Note note in noteAdministration.Notes)
                { 
                    if(note.Information == Notes_checkedListBox.SelectedItem.ToString())
                    {
                        this.Visible = false;
                        form.details = note;
                        form.Detail_Refresh();
                        var closing = form.ShowDialog();

                        if (closing == DialogResult.OK)
                        {
                            this.noteAdministration = form.noteAdministration;
                            Note_Refresh();
                            this.Visible = true;
                            return;
                        }
                    }
                }
            }
        }

        public void Note_Refresh()
        {
            Notes_checkedListBox.Items.Clear();
            foreach (Note n in noteAdministration.Notes)
            {
                Notes_checkedListBox.Items.Add(n.Information);
            }
        }

        private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
