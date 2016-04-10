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
    public partial class NoteForm : Form
    {
        public NoteAdministration noteAdministration;
        public Account user;

        public NoteForm()
        {
            InitializeComponent();
        }

        private void NewNote_button_Click(object sender, EventArgs e)
        {
            NoteAddForm form = new NoteAddForm();
            form.noteAdministration = this.noteAdministration;
            form.user = this.user;
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.noteAdministration = form.noteAdministration;
                this.Visible = true;
                Note_Refresh();
            }
        }


        public void Note_Refresh()
        {
            Note_listBox.Items.Clear();
            foreach (Note n in noteAdministration.Notes)
            {
                Note_listBox.Items.Add(n.Information);
            }
        }

        private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Note_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Note_listBox.SelectedItem != null)
            {
                NoteDetailForm form = new NoteDetailForm();
                form.noteAdministration = this.noteAdministration;
                foreach (Note note in noteAdministration.Notes)
                {
                    if (note.Information == Note_listBox.SelectedItem.ToString())
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
    }
}
