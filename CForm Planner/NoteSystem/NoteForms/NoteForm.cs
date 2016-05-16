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
        public NoteAdministration NoteAdministration { get; private set; }
        public Account Account { get; private set; }

        public NoteForm(Account account, NoteAdministration noteAdministration)
        {
            Account = account;
            NoteAdministration = noteAdministration;
            InitializeComponent();
        }

        private void NewNote_button_Click(object sender, EventArgs e)
        {
            NoteAddForm form = new NoteAddForm(Account, NoteAdministration);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                NoteAdministration = form.NoteAdministration;
                this.Visible = true;
                Note_Refresh();
            }
        }


        public void Note_Refresh()
        {
            Note_listBox.Items.Clear();
            foreach (Note n in NoteAdministration.Notes)
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
                foreach (Note note in NoteAdministration.Notes)
                {
                    if (note.Information == Note_listBox.SelectedItem.ToString())
                    {
                        this.Visible = false;
                        NoteDetailForm form = new NoteDetailForm(note, NoteAdministration);
                        form.Detail_Refresh();
                        var closing = form.ShowDialog();

                        if (closing == DialogResult.OK)
                        {
                            NoteAdministration = form.NoteAdministration;
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
