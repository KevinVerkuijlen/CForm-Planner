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
    public partial class TaskAddForm : Form
    {
        public TaskAdministration taskAdministration;

        public TaskAddForm()
        {
            InitializeComponent();
            
        }

        private void AddTask_button_Click(object sender, EventArgs e)
        {
            if (TaskTitel_textBox.Text != "" && TaskNotes_textBox.Text != "")
            {
                try
                {
                    TaskSystem.Task newtask = new TaskSystem.Task(TaskTitel_textBox.Text, TaskNotes_textBox.Text, false, "");
                    taskAdministration.AddTask(newtask);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
                this.DialogResult = DialogResult.OK;
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
