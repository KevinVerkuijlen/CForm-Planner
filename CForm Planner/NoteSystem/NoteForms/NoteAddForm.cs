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
    public partial class NoteAddForm : Form
    {
        public NoteAdministration noteAdministration;
        public NoteAddForm()
        {
            InitializeComponent();
        }

        private void AddNote_button_Click(object sender, EventArgs e)
        {
            if (NoteInfo_textBox.Text != "")
            {
                try
                {
                    Note newNote = new Note(NoteInfo_textBox.Text, "");
                    try
                    {
                        noteAdministration.AddNote(newNote);
                    }
                    catch (PlannerExceptions ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                catch (ArgumentNullException ex)
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
