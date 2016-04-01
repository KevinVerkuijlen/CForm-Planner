using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CForm_Planner.TaskSystem;

namespace CForm_Planner
{
    public partial class TaskDetailForm : Form
    {
        public TaskAdministration taskAdministration;
        public TaskSystem.Task details;

        public TaskDetailForm()
        {
            InitializeComponent();
        }

        private void ChangeTask_button_Click(object sender, EventArgs e)
        {
            if (TaskTitel_textBox.Text != "" && TaskNotes_textBox.Text != "")
            {
                bool completed;
                if(Completed_radioButton.Checked == true){
                    completed = true;
                }
                else{
                    completed = false;
                }
                try
                {
                    TaskSystem.Task changedTask = new TaskSystem.Task(TaskTitel_textBox.Text, TaskNotes_textBox.Text, completed, "");
                    taskAdministration.ChangeTask(details, changedTask);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill  in a task titel and notes");
            }
        }

        private void RemoveTask_button_Click(object sender, EventArgs e)
        {
            try
            {
                taskAdministration.RemoveTask(details);
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
                TaskTitel_textBox.Text = details.Titel;
                TaskNotes_textBox.Text = details.Notes;
                if (details.Completed == true)
                {
                    Completed_radioButton.Checked = true;
                }
                else
                {
                    Completed_radioButton.Checked = false;
                }
            }
        }

        private void TaskDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
