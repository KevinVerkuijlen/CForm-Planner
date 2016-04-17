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
using CForm_Planner.AgendaSystem;

namespace CForm_Planner
{
    public partial class Reminders : Form
    {
        public CalendarEventAdministration calendarEventAdministration;
        public TaskAdministration taskAdministration;

        public Reminders()
        {
            InitializeComponent();
        }

        private void Reminders_Load(object sender, EventArgs e)
        {
            int totalAppointment = 0;
            int normalAppointment = 0;
            int schoolAppointment = 0;
            int gameAppointment = 0;
            foreach (CalendarEvent appointment in calendarEventAdministration.Agenda)
            {
                if (appointment.StartDate.Date >= DateTime.Now.Date && appointment.StartDate.Date <= DateTime.Now.AddDays(7).Date
                    || appointment.EndDate.Date >= DateTime.Now.Date && appointment.EndDate.Date <= DateTime.Now.AddDays(7).Date
                    || (appointment.StartDate.Date <= DateTime.Now.Date && appointment.EndDate.Date >= DateTime.Now.AddDays(7).Date))
                {
                    totalAppointment += 1;
                    if (appointment.GetType() == typeof(SchoolEvent))
                    {
                        schoolAppointment += 1;
                    }
                    if (appointment.GetType() == typeof(GameEvent))
                    {
                        gameAppointment += 1;
                    }
                }
                normalAppointment = totalAppointment - (schoolAppointment + gameAppointment);
            }
            TotalAppointments_label.Text = "You have "+totalAppointment.ToString()+" appiontments for the coming week";
            NormalAppointmenst_label.Text = normalAppointment.ToString()+" normal appointments";
            SchoolAppointments_label.Text = schoolAppointment.ToString() + " appointments for school";
            GameAppointments_label.Text = gameAppointment.ToString() + " appointments for games";

            int tasks = 0;
            foreach (CForm_Planner.TaskSystem.Task task in taskAdministration.Todo)
            {
                if (task.Completed == false)
                {
                    tasks += 1;
                }
            }
            ToDoTasks_label.Text = "You still have "+tasks.ToString()+" uncompleted tasks";
        }
    }
}
