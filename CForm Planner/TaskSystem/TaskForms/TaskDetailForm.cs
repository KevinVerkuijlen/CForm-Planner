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
using CForm_Planner.TaskSystem;
using CForm_Planner.AgendaSystem;
using CForm_Planner.AgendaSystem.AgendaForms;

namespace CForm_Planner
{
    public partial class TaskDetailForm : Form
    {
        public TaskAdministration TaskAdministration { get; }
        public CalendarEventAdministration CalendarEventAdministration { get; private set; }
        public Account Account { get; }
        public TaskSystem.Task Task { get; }

        public TaskDetailForm(Account account, TaskSystem.Task task, TaskAdministration taskAdministration, CalendarEventAdministration calendarEventAdministration)
        {
            Account = account;
            Task = task;
            TaskAdministration = taskAdministration;
            CalendarEventAdministration = calendarEventAdministration;
            InitializeComponent();
        }

        private void ChangeTask_button_Click(object sender, EventArgs e)
        {
            if (TaskTitel_textBox.Text != "" && TaskNotes_textBox.Text != "")
            {
                if (Min_numericUpDown.Value > 0 || Hour_numericUpDown.Value > 0)
                {
                    bool completed;
                    if (Completed_radioButton.Checked == true)
                    {
                        completed = true;
                    }
                    else
                    {
                        completed = false;
                    }
                    try
                    {
                        TaskAdministration.ChangeTask(Task, TaskTitel_textBox.Text, TaskNotes_textBox.Text, Convert.ToInt32(Hour_numericUpDown.Value), Convert.ToInt32(Min_numericUpDown.Value), completed);
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
                    MessageBox.Show("You need to enter a duration greater then zero");
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
                TaskAdministration.RemoveTask(Task);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Detail_Refresh()
        {
            if (Task != null)
            {
                TaskTitel_textBox.Text = Task.Titel;
                TaskNotes_textBox.Text = Task.Notes;
                Hour_numericUpDown.Value = Task.HourDuration;
                Min_numericUpDown.Value = Task.MinDuration;
                if (Task.Completed == true)
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
            DialogResult = DialogResult.OK;
        }

        private void TaskToAppointment_button_Click(object sender, EventArgs e)
        {
            CalendarEvent calendarTask = new CalendarEvent(Task.Titel, Task.Notes, DateTime.Now, DateTime.Now, Task.AccountEmail);
            AgendaAddForm form = new AgendaAddForm(Account,CalendarEventAdministration, calendarTask);
            this.Visible = false;
            form.Detail_Refresh();
            var closing = form.ShowDialog();
            if (closing == DialogResult.Yes)
            {
                CalendarEventAdministration = form.CalendarEventAdministration;
                TaskAdministration.RemoveTask(Task);
                this.DialogResult = DialogResult.OK;
            }
            else if (closing == DialogResult.OK)
            {
                CalendarEventAdministration = form.CalendarEventAdministration;
                this.Visible = true;
            }
        }
    }
}
