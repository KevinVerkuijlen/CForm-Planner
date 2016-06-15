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

namespace CForm_Planner.AgendaSystem.AgendaForms
{
    public partial class AgendaDetailsForm : Form
    {
        public CalendarEventAdministration CalendarEventAdministration { get; }
        public CalendarEvent CalendarEvent { get; }

        public AgendaDetailsForm(CalendarEvent calendarEvent, CalendarEventAdministration calendarEventAdministration)
        {
            CalendarEvent = calendarEvent;
            CalendarEventAdministration = calendarEventAdministration;
            InitializeComponent();
            NormalAppointment();
            Game_comboBox.Items.AddRange(CalendarEventAdministration.GetGames().ToArray());
        }

        private void Change_button_Click(object sender, EventArgs e)
        {
            if (Titel_textBox.Text != "")
            {
                if (Note_textBox.Text != "")
                {
                    DateTime start = Start_datePicker.Value.Date.Add(Start_TimePicker.Value.TimeOfDay);
                    DateTime end = End_datePicker.Value.Date.Add(End_TimePicker.Value.TimeOfDay);
                    if (start.ToString() == end.ToString() || start < end)
                    {
                        try
                        {
                            switch (CalendarEvent.GetType().ToString())
                            {
                                case "CForm_Planner.AgendaSystem.SchoolEvent":
                                    CalendarEventAdministration.ChangeCalendarEvent((SchoolEvent)CalendarEvent, Titel_textBox.Text,
                                        Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, null);
                                    break;
                                case "CForm_Planner.AgendaSystem.GameEvent":
                                    CalendarEventAdministration.ChangeCalendarEvent((GameEvent)CalendarEvent, Titel_textBox.Text,
                                        Note_textBox.Text, start, end, null, null, Game_comboBox.Text);
                                    break;
                                case "CForm_Planner.AgendaSystem.CalendarEvent":
                                    CalendarEventAdministration.ChangeCalendarEvent(CalendarEvent, Titel_textBox.Text,
                                        Note_textBox.Text, start, end, null, null, null);
                                    break;
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your end date needs to be later or equal to your start date");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in some notes for the appointment");
                }
            }
            else
            {
                MessageBox.Show("You need to fill in a titel for the appiontment");
            }
        }

        private void Remove_button_Click(object sender, EventArgs e)
        {
            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(CalendarEvent);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Detail_Refresh()
        {
            if (CalendarEvent != null)
            {
                Titel_textBox.Text = CalendarEvent.Titel;
                Note_textBox.Text = CalendarEvent.Notes;
                Start_datePicker.Value = CalendarEvent.StartDate.Date;
                Start_TimePicker.Value = CalendarEvent.StartDate;
                End_datePicker.Value = CalendarEvent.EndDate.Date;
                End_TimePicker.Value = CalendarEvent.EndDate;
                if (CalendarEvent.GetType() == typeof(SchoolEvent))
                {
                    SchoolEvent schoolDetails = (SchoolEvent)CalendarEvent;
                    Subject_label.Visible = true;
                    Subject_textBox.Visible = true;
                    Subject_textBox.Text = schoolDetails.Subject;
                    Assignment_label.Visible = true;
                    Assignment_textBox.Visible = true;
                    Assignment_textBox.Text = schoolDetails.Assignment;
                }
                if (CalendarEvent.GetType() == typeof(GameEvent))
                {
                    GameEvent gameDetails = (GameEvent)CalendarEvent;
                    Game_label.Visible = true;
                    Game_comboBox.Visible = true;
                    Game_comboBox.Text = gameDetails.GameName;
                }
            }
        }

        private void NormalAppointment()
        {
            Subject_label.Visible = false;
            Subject_textBox.Visible = false;
            Assignment_label.Visible = false;
            Assignment_textBox.Visible = false;
            Game_label.Visible = false;
            Game_comboBox.Visible = false;
        }

        private void AgendaDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
