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
using CForm_Planner.AlarmSystem;
using CForm_Planner.NoteSystem;
using CForm_Planner.TaskSystem;
using CForm_Planner.AgendaSystem;

namespace CForm_Planner
{
    public partial class Home : Form
    {
        private NoteAdministration noteAdministration = new NoteAdministration();
        private TaskAdministration taskAdministration = new TaskAdministration();
        private AlarmAdministration alarmAdministration = new AlarmAdministration();
        private CalendarEventAdministration calendarEventAdministration = new CalendarEventAdministration();

        public Home()
        {
            InitializeComponent();
            MessageBox.Show("Alarm en Agenda sorteren (task prioriteit)");
        }

        private void Account_button_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.Visible = true;
            }
        }

        private void Note_button_Click(object sender, EventArgs e)
        {
            noteAdministration.Notes = ReadFromBinaryFile<List<Note>>(@"notes.bin");
            NoteForm form = new NoteForm();
            form.noteAdministration = noteAdministration;
            form.Note_Refresh();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.noteAdministration = form.noteAdministration;
                WriteToBinaryFile<List<Note>>(@"notes.bin", noteAdministration.Notes);
                this.Visible = true;
            }
        }

        private void Agenda_button_Click(object sender, EventArgs e)
        {
            calendarEventAdministration.Agenda = ReadFromBinaryFile<List<CalendarEvent>>(@"Agenda.bin");
            AgendaForm form = new AgendaForm();
            form.calendarEventAdministration = this.calendarEventAdministration;
            form.Agenda_monthCalendar_DateChanged(null, null);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.calendarEventAdministration = form.calendarEventAdministration;
                WriteToBinaryFile<List<CalendarEvent>>(@"Agenda.bin", calendarEventAdministration.Agenda);
                this.Visible = true;
            }
        }

        private void Alarm_button_Click(object sender, EventArgs e)
        {
            alarmAdministration.Alarm_list = ReadFromBinaryFile<List<Alarm>>(@"Alarm.bin");
            AlarmForm form = new AlarmForm();
            form.alarmAdministration = this.alarmAdministration;
            form.Alarm_Refresh();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.alarmAdministration = form.alarmAdministration;
                WriteToBinaryFile<List<Alarm>>(@"Alarm.bin", alarmAdministration.Alarm_list);
                this.Visible = true;
            }
        }

        private void ToDo_button_Click(object sender, EventArgs e)
        {
            taskAdministration.Todo = ReadFromBinaryFile<List<CForm_Planner.TaskSystem.Task>>(@"Todo.bin");
            CForm_Planner.TaskSystem.TaskForms.TaskForm form = new CForm_Planner.TaskSystem.TaskForms.TaskForm();
            form.taskAdministration = this.taskAdministration;
            form.ToDo_Refresh();
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                this.taskAdministration = form.taskAdministration;
                WriteToBinaryFile<List<CForm_Planner.TaskSystem.Task>>(@"Todo.bin", taskAdministration.Todo);
                this.Visible = true;
            }
        }

        private void Alarm_timer_Tick(object sender, EventArgs e)
        {
            foreach (Alarm a in alarmAdministration.Alarm_list)
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
    }

}

