using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CForm_Planner.TaskSystem.TaskForms
{
    public partial class TaskForm : Form
    {
        public TaskAdministration taskAdministration;
        public TaskForm()
        {
            InitializeComponent();
        }

        private void AddTask_button_Click(object sender, EventArgs e)
        {
            TaskAddForm form = new TaskAddForm();
            form.taskAdministration = this.taskAdministration;
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.taskAdministration = form.taskAdministration;
                this.Visible = true;
                ToDo_Refresh();
            }
        }

        private void ToDo_checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToDo_checkedListBox.SelectedItem != null)
            {
                TaskDetailForm form = new TaskDetailForm();
                form.taskAdministration = this.taskAdministration;

                foreach (TaskSystem.Task task in taskAdministration.Todo)
                {
                    if (task.Titel == ToDo_checkedListBox.SelectedItem.ToString())
                    {
                        this.Visible = false;
                        form.details = task;
                        form.Detail_Refresh();
                        var closing = form.ShowDialog();

                        if (closing == DialogResult.OK)
                        {
                            this.taskAdministration = form.taskAdministration;
                            ToDo_Refresh();
                            this.Visible = true;
                            return;
                        }
                    }
                }
            }
        }

        public void ToDo_Refresh()
        {
            ToDo_checkedListBox.Items.Clear();
            foreach (Task t in taskAdministration.Todo)
            {
                if (t.Completed == true)
                {
                    ToDo_checkedListBox.Items.Add(t.Titel, true);
                }
                else
                {
                    ToDo_checkedListBox.Items.Add(t.Titel, false);
                }
            }
        }

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ToDo_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

    }
}
