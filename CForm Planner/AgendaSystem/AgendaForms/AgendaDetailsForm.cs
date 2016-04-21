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
                    if (start.ToString() == end.ToString() || start < end)
                    {
                        try
                        {
                            calendarEventAdministration.ChangeCalendarEvent(details, Titel_textBox.Text, Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, Game_textBox.Text, details.AccountEmail);
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
                Start_TimePicker.Value = details.StartDate;
                End_datePicker.Value = details.EndDate.Date;
                End_TimePicker.Value = details.EndDate;
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
