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
using CForm_Planner.AgendaSystem;

namespace CForm_Planner.TaskSystem.TaskForms
{
    public partial class TaskForm : Form
    {
        public TaskAdministration TaskAdministration { get; private set; }
        public CalendarEventAdministration CalendarEventAdministration { get; private set; }
        public Account Account { get; private set; }

        public TaskForm(Account account, TaskAdministration taskAdministration, CalendarEventAdministration calendarEventAdministration)
        {
            Account = account;
            TaskAdministration = taskAdministration;
            CalendarEventAdministration = calendarEventAdministration;
            InitializeComponent();
        }

        private void AddTask_button_Click(object sender, EventArgs e)
        {
            TaskAddForm form = new TaskAddForm(Account, TaskAdministration);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                TaskAdministration = form.TaskAdministration;
                this.Visible = true;
                ToDo_Refresh();
            }
        }

        private void ToDo_checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ToDo_checkedListBox.SelectedItem != null)
            {
                foreach (TaskSystem.Task task in TaskAdministration.Todo)
                {
                    if (task.Titel == ToDo_checkedListBox.SelectedItem.ToString())
                    {
                        this.Visible = false;
                        TaskDetailForm form = new TaskDetailForm(Account, task, TaskAdministration, CalendarEventAdministration);
                        form.Detail_Refresh();
                        var closing = form.ShowDialog();

                        if (closing == DialogResult.OK)
                        {
                            TaskAdministration = form.TaskAdministration;
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
            foreach (Task t in TaskAdministration.Todo)
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


    }
}
