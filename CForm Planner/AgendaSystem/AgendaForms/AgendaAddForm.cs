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
    public partial class AgendaAddForm : Form
    {
        public CalendarEventAdministration calendarEventAdministration;
        public Account user;
        public CalendarEvent task;
        
        public AgendaAddForm()
        {
            InitializeComponent();
            Normal_radioButton.Checked = true;
        }

        private void Normal_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            NormalAppointment();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            string userEmail = "";
            if (user != null)
            {
                userEmail = user.EmailAdress;
            }
            if (Titel_textBox.Text != "")
            {
                if (Note_textBox.Text != "")
                {
                    DateTime start = Start_datePicker.Value.Date.Add(Start_TimePicker.Value.TimeOfDay);
                    DateTime end = End_datePicker.Value.Date.Add(End_TimePicker.Value.TimeOfDay);
                    if (start.ToString() == end.ToString() || start < end)
                    {
                        if (Repeat_checkBox.Checked)
                        {
                            if (start.Date == end.Date)
                            {
                                try
                                {
                                    calendarEventAdministration.AddCalendarEvent(Titel_textBox.Text, Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, Game_textBox.Text, userEmail);
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                    if (Repeat_comboBox.Text == "days")
                                {
                                    calendarEventAdministration.RepeatCalendarEventEachDay(Titel_textBox.Text, Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, Game_textBox.Text, userEmail, Convert.ToInt32(Repeat_numericUpDown.Value));
                                }
                                else if (Repeat_comboBox.Text == "work days") 
                                {
                                    calendarEventAdministration.RepeatCalendarEventEachWorkDay(Titel_textBox.Text, Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, Game_textBox.Text, userEmail, Convert.ToInt32(Repeat_numericUpDown.Value));
                                }
                                else if (Repeat_comboBox.Text == "weeks")
                                {
                                    calendarEventAdministration.RepeatCalendarEventEachDayInWeek(Titel_textBox.Text, Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, Game_textBox.Text, userEmail, Convert.ToInt32(Repeat_numericUpDown.Value));
                                }
                                AgendaAddForm_FormClosing(null, null);
                            }
                            else
                            {
                                MessageBox.Show("To repeat an event it needs to be on one day");
                            }
                        }
                        else
                        {
                            try
                            {
                                calendarEventAdministration.AddCalendarEvent(Titel_textBox.Text, Note_textBox.Text, start, end, Subject_textBox.Text, Assignment_textBox.Text, Game_textBox.Text, userEmail);
                                AgendaAddForm_FormClosing(null, null);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
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

        private void School_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            NormalAppointment();
            Subject_label.Visible = true;
            Subject_textBox.Visible = true;
            Assignment_label.Visible = true;
            Assignment_textBox.Visible = true;
        }

        private void Game_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            NormalAppointment();
            Game_label.Visible = true;
            Game_textBox.Visible = true;
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

        private void AgendaAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (task != null)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public void Detail_Refresh()
        {
            if (task != null)
            {
                Titel_textBox.Text = task.Titel;
                Note_textBox.Text = task.Notes;
                Start_datePicker.Value = task.StartDate.Date;
                Start_TimePicker.Value = task.StartDate;
                End_datePicker.Value = task.EndDate.Date;
                End_TimePicker.Value = task.EndDate;
            }
        }
    }
}
