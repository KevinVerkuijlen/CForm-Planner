using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CForm_Planner.AccountSystem.AccountForms;
using CForm_Planner.AgendaSystem.AgendaForms;
using CForm_Planner.AlarmSystem.AlarmForms;
using CForm_Planner.AccountSystem;
using CForm_Planner.AlarmSystem;
using CForm_Planner.NoteSystem;
using CForm_Planner.TaskSystem;
using CForm_Planner.AgendaSystem;

namespace CForm_Planner
{
    public partial class Home : Form
    {
        private Administration Administration { get; set; }
        private NoteAdministration NoteAdministration { get; set; }
        private TaskAdministration TaskAdministration { get; set; }
        private AlarmAdministration AlarmAdministration { get; set; }
        private CalendarEventAdministration CalendarEventAdministration { get; set; }

        public Home()
        {
            Administration = new Administration();
            NoteAdministration = new NoteAdministration();
            TaskAdministration = new TaskAdministration();
            AlarmAdministration = new AlarmAdministration();
            CalendarEventAdministration = new CalendarEventAdministration();
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //administration.user = ReadFromBinaryFile<Account>(@"User.bin");
            NoteAdministration.Notes = ReadFromBinaryFile<List<Note>>(@"notes.bin");
            CalendarEventAdministration.Agenda = ReadFromBinaryFile<List<CalendarEvent>>(@"Agenda.bin");
            AlarmAdministration.Alarm_list = ReadFromBinaryFile<List<Alarm>>(@"Alarm.bin");
            TaskAdministration.Todo = ReadFromBinaryFile<List<CForm_Planner.TaskSystem.Task>>(@"Todo.bin");
            UserRefresh();

            Reminders form = new Reminders(CalendarEventAdministration, TaskAdministration);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                UserRefresh();
                this.Visible = true;
            }
        }

        private void Account_button_Click(object sender, EventArgs e)
        {
            if (Administration.User == null)
            {
                LoginForm form = new LoginForm(Administration);
                this.Visible = false;
                var closing = form.ShowDialog();
                if (closing == DialogResult.OK)
                {
                    this.Administration = form.Administration;
                  //  WriteToBinaryFile<Account>(@"User.bin", administration.user);
                    UserRefresh();
                    this.Visible = true;
                }
            }
            else
            {
                AccountDetailsForm form = new AccountDetailsForm(Administration);
                form.DetailRefresh();
                this.Visible = false;
                var closing = form.ShowDialog();
                if (closing == DialogResult.OK)
                {
                    this.Administration = form.Administration;
                    UserRefresh();
                    this.Visible = true;
                }
            }
        }

        private void Note_button_Click(object sender, EventArgs e)
        {
            NoteForm form = new NoteForm(Administration.User, NoteAdministration);
            form.Note_Refresh();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                NoteAdministration = form.NoteAdministration;
                WriteToBinaryFile<List<Note>>(@"notes.bin", NoteAdministration.Notes);
                this.Visible = true;
            }
        }

        private void Agenda_button_Click(object sender, EventArgs e)
        {
            AgendaForm form = new AgendaForm(Administration.User, CalendarEventAdministration);
            form.Agenda_monthCalendar_DateChanged(null, null);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.CalendarEventAdministration = form.CalendarEventAdministration;
                WriteToBinaryFile<List<CalendarEvent>>(@"Agenda.bin", CalendarEventAdministration.Agenda);
                UserRefresh();
                this.Visible = true;
            }
        }

        private void Alarm_button_Click(object sender, EventArgs e)
        {
            AlarmForm form = new AlarmForm(Administration.User, AlarmAdministration);
            form.Alarm_Refresh();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                AlarmAdministration = form.AlarmAdministration;
                WriteToBinaryFile<List<Alarm>>(@"Alarm.bin", AlarmAdministration.Alarm_list);
                Visible = true;
            }
        }

        private void ToDo_button_Click(object sender, EventArgs e)
        {
            TaskSystem.TaskForms.TaskForm form = new TaskSystem.TaskForms.TaskForm(Administration.User, TaskAdministration, CalendarEventAdministration);
            form.ToDo_Refresh();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                TaskAdministration = form.TaskAdministration;
                WriteToBinaryFile<List<CForm_Planner.TaskSystem.Task>>(@"Todo.bin", TaskAdministration.Todo);
                UserRefresh();
                this.Visible = true;
            }
        }

        private void Alarm_timer_Tick(object sender, EventArgs e)
        {
            foreach (Alarm a in AlarmAdministration.Alarm_list)
            {
                if (Convert.ToInt16(DateTime.Now.ToString("HH")) == a.Alarmtime.Hour && Convert.ToInt32(DateTime.Now.ToString("mm")) == a.Alarmtime.Minute)
                {
                    MessageBox.Show("lolololol");
                }
            }
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public void UserRefresh()
        {
            if (Administration.User != null)
            {
                Name_label.Visible = true;
                UName_label.Visible = true;
                UName_label.Text = Administration.User.Name;
                LastName_label.Visible = true;
                ULastName_label.Visible = true;
                ULastName_label.Text = Administration.User.LastName;
                email_label.Visible = true;
                UEmail_label.Visible = true;
                UEmail_label.Text = Administration.User.EmailAdress;
                download_button.Enabled = true;
                upload_button.Enabled = true;
                try
                {
                    if (CalendarEventAdministration.Agenda.Exists(x => x.AccountEmail == ""))
                    {
                        DialogResult result =
                            MessageBox.Show(
                                "Your agenda contains severall items which aren't linked to an account" +
                                Environment.NewLine + " do you wish link these to you account?",
                                "Confirm",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            CalendarEventAdministration.EmptyCalendarToUser(Administration.User);
                        }
                        else if (result == DialogResult.No)
                        {
                        }
                    }
                    CalendarEventAdministration.CleanCalendar(Administration.User);
                    if (AlarmAdministration.Alarm_list.Exists(x => x.AccountEmail == ""))
                    {
                        DialogResult result =
                            MessageBox.Show(
                                "Your alarm list contains severall items which aren't linked to an account" +
                                Environment.NewLine + " do you wish link these to you account?",
                                "Confirm",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            AlarmAdministration.EmptyAlarmsToUser(Administration.User);
                        }
                        else if (result == DialogResult.No)
                        {
                        }
                    }
                    AlarmAdministration.CleanAlarms(Administration.User);
                    if (NoteAdministration.Notes.Exists(x => x.Accountemail == ""))
                    {
                        DialogResult result =
                            MessageBox.Show(
                                "Your Notes contains severall items which aren't linked to an account" +
                                Environment.NewLine + " do you wish link these to you account?",
                                "Confirm",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            NoteAdministration.EmptyNotesToUser(Administration.User);
                        }
                        else if (result == DialogResult.No)
                        {
                        }
                    }
                    NoteAdministration.CleanNotes(Administration.User);
                    if (TaskAdministration.Todo.Exists(x => x.Accountemail == ""))
                    {
                        DialogResult result =
                            MessageBox.Show(
                                "Your ToDo-list contains severall items which aren't linked to an account" +
                                Environment.NewLine + " do you wish link these to you account?",
                                "Confirm",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            TaskAdministration.EmptyTasksToUser(Administration.User);
                        }
                        else if (result == DialogResult.No)
                        {
                        }
                    }
                    TaskAdministration.CleanTasks(Administration.User);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                Name_label.Visible = false;
                UName_label.Visible = false;
                LastName_label.Visible = false;
                ULastName_label.Visible = false;
                email_label.Visible = false;
                UEmail_label.Visible = false;
                download_button.Enabled = false;
                upload_button.Enabled = false;
            }
            int todayAppointment = 0;
            foreach (CalendarEvent appointment in CalendarEventAdministration.Agenda)
            {
                if (appointment.StartDate.Date == DateTime.Now.Date || appointment.EndDate.Date == DateTime.Now.Date || (appointment.StartDate.Date <= DateTime.Now.Date && appointment.EndDate.Date >= DateTime.Now.Date))
                {
                    todayAppointment += 1;
                }
            }
            Today_label.Text = "Today: " + todayAppointment.ToString();

            int tasks = 0;
            foreach (CForm_Planner.TaskSystem.Task task in TaskAdministration.Todo)
            {
                if (task.Completed == false)
                {
                    tasks += 1;
                }
            }
            TaskP2_label.Text = "Tasks = " + tasks.ToString();
        }

        private void download_button_Click(object sender, EventArgs e)
        {
            if (Administration.User != null)
            {
                try
                {
                    NoteAdministration.MergeNotes(Administration.User);
                    TaskAdministration.MergeTask(Administration.User);
                    AlarmAdministration.MergeAlarms(Administration.User);
                    CalendarEventAdministration.MergeCalendar(Administration.User);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void upload_button_Click(object sender, EventArgs e)
        {
            if (Administration.User != null)
            {
                try
                {
                    NoteAdministration.UploadNotes(Administration.User);
                    TaskAdministration.UploadTasks(Administration.User);
                    AlarmAdministration.UploadAlarms(Administration.User);
                    CalendarEventAdministration.UploadCalendar(Administration.User);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }

}

