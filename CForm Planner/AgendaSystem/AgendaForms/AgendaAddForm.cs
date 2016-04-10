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
                        string titel = Titel_textBox.Text;
                        string notes = Note_textBox.Text;
                        if (Normal_radioButton.Checked == true)
                        {
                            try
                            {
                                CalendarEvent appiontment = new CalendarEvent(titel, notes, start, end, userEmail);
                                calendarEventAdministration.AddCalendarEvent(appiontment);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        if (School_radioButton.Checked == true)
                        {
                            if (Subject_textBox.Text != null)
                            {
                                if (Assignment_textBox.Text != null)
                                {
                                    try
                                    {
                                        SchoolEvent schoolAppiontment = new SchoolEvent(titel, notes, start, end, Subject_textBox.Text, Assignment_textBox.Text, userEmail);
                                        calendarEventAdministration.AddCalendarEvent(schoolAppiontment);
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    catch(Exception ex)
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
                        if (Game_radioButton.Checked == true)
                        {
                            try
                            {
                                GameEvent gameAppiontment = new GameEvent(titel, notes, start, end, Game_textBox.Text, userEmail);
                                calendarEventAdministration.AddCalendarEvent(gameAppiontment);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch(Exception ex)
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
            this.DialogResult = DialogResult.OK;
        }
    }
}
