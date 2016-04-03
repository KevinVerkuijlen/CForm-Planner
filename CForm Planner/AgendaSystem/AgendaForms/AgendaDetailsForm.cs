using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CForm_Planner.AgendaSystem.AgendaForms
{
    public partial class AgendaDetailsForm : Form
    {
        public CalendarEventAdministration calendarEventAdministration;
        public CalendarEvent details;

        public AgendaDetailsForm()
        {
            InitializeComponent();
            NormalAppointment();
        }

        private void Change_button_Click(object sender, EventArgs e)
        {
            if (Titel_textBox.Text != "")
            {
                if (Note_textBox.Text != "")
                {
                    DateTime start = Start_datePicker.Value.Date.Add(Start_TimePicker.Value.TimeOfDay);
                    DateTime end = End_datePicker.Value.Date.Add(End_TimePicker.Value.TimeOfDay);
                    if (start <= end)
                    {
                        string titel = Titel_textBox.Text;
                        string notes = Note_textBox.Text;
                        if (details.GetType() == typeof(SchoolEvent))
                        {
                            if (Subject_textBox.Text != null)
                            {
                                if (Assignment_textBox.Text != null)
                                {
                                    try
                                    {
                                        SchoolEvent schoolAppiontment = new SchoolEvent(titel, notes, start, end, Subject_textBox.Text, Assignment_textBox.Text, "");
                                        calendarEventAdministration.ChangeCalendarEvent(details, schoolAppiontment);
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please fill in an assignment for the subject");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill in a subject for the appointment");
                            }
                        }
                        if (details.GetType() == typeof(GameEvent))
                        {
                            try
                            {
                                GameEvent gameAppiontment = new GameEvent(titel, notes, start, end, Game_textBox.Text, "");
                                calendarEventAdministration.ChangeCalendarEvent(details, gameAppiontment);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        if (details.GetType() == typeof(CalendarEvent))
                        {
                            try
                            {
                                CalendarEvent appiontment = new CalendarEvent(titel, notes, start, end, "");
                                calendarEventAdministration.ChangeCalendarEvent(details, appiontment);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
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
                calendarEventAdministration.RemoveCalendarEvent(details);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Detail_Refresh()
        {
            if (details != null)
            {
                Titel_textBox.Text = details.Titel;
                Note_textBox.Text = details.Notes;
                Start_datePicker.Value = details.StartDate.Date;
                Start_TimePicker.Value = details.StartDate.Date;
                End_datePicker.Value = details.EndDate.Date;
                End_TimePicker.Value = details.EndDate.Date;
                if (details.GetType() == typeof(SchoolEvent))
                {
                    SchoolEvent schoolDetails = (SchoolEvent)details;
                    Subject_label.Visible = true;
                    Subject_textBox.Visible = true;
                    Subject_textBox.Text = schoolDetails.Subject;
                    Assignment_label.Visible = true;
                    Assignment_textBox.Visible = true;
                    Assignment_textBox.Text = schoolDetails.Assignment;
                }
                if (details.GetType() == typeof(GameEvent))
                {
                    GameEvent gameDetails = (GameEvent)details;
                    Game_label.Visible = true;
                    Game_textBox.Visible = true;
                    Game_textBox.Text = gameDetails.GameName;
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
            Game_textBox.Visible = false;
        }

        private void AgendaDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
