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
using CForm_Planner.AccountSystem;

namespace CForm_Planner
{
    public partial class TaskAddForm : Form
    {
        public TaskAdministration TaskAdministration { get; }
        public Account Account { get; }

        public TaskAddForm(Account account, TaskAdministration taskAdministration)
        {
            Account = account;
            TaskAdministration = taskAdministration;
            InitializeComponent();
        }

        private void AddTask_button_Click(object sender, EventArgs e)
        {
            string userEmail = "";
            if (Account != null)
            {
                userEmail = Account.EmailAdress;
            }
            if (TaskTitel_textBox.Text != "" && TaskNotes_textBox.Text != "")
            {
                if (Min_numericUpDown.Value > 0 || Hour_numericUpDown.Value > 0)
                {
                    try
                    {
                        TaskAdministration.AddTask(TaskTitel_textBox.Text, TaskNotes_textBox.Text, Convert.ToInt32(Hour_numericUpDown.Value), Convert.ToInt32(Min_numericUpDown.Value), false, userEmail);
                        this.DialogResult = DialogResult.OK;
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

        private void TaskAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
