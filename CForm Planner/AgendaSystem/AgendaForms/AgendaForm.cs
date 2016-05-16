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
    public partial class AgendaForm : Form
    {
        public CalendarEventAdministration CalendarEventAdministration { get; private set; }
        public Account Account { get; }

        public AgendaForm(Account account, CalendarEventAdministration calendarEventAdministration)
        {
            Account = account;
            CalendarEventAdministration = calendarEventAdministration;
            InitializeComponent();
            EndDate_label.Visible = false;
        }

        private void AgendaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void Agenda_monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Appointment_listBox.DataBindings.Clear();
            List<CalendarEvent> appiontments = new List<CalendarEvent>();
            SelectedDate_label.Text = "Selected Date: "+ Agenda_monthCalendar.SelectionRange.Start.Date.ToString();
            if (Agenda_monthCalendar.SelectionRange.End != Agenda_monthCalendar.SelectionRange.Start)
            {
                EndDate_label.Visible = true;
                EndDate_label.Text = "To: " + Agenda_monthCalendar.SelectionRange.End.Date.ToString();
                foreach (CalendarEvent c in CalendarEventAdministration.Agenda)
                {
                    if (c.StartDate.Date >= Agenda_monthCalendar.SelectionRange.Start.Date && c.StartDate.Date <= Agenda_monthCalendar.SelectionRange.End.Date 
                        || c.EndDate.Date >= Agenda_monthCalendar.SelectionRange.Start.Date && c.EndDate.Date <= Agenda_monthCalendar.SelectionRange.End.Date 
                        ||(c.StartDate.Date <= Agenda_monthCalendar.SelectionRange.Start.Date && c.EndDate.Date >= Agenda_monthCalendar.SelectionRange.End.Date))
                    {
                        appiontments.Add(c);
                    }
                }
            }
            else
            {
                foreach (CalendarEvent c in CalendarEventAdministration.Agenda)
                {
                    if (c.StartDate.Date == Agenda_monthCalendar.SelectionRange.Start.Date || c.EndDate.Date == Agenda_monthCalendar.SelectionRange.Start.Date || (c.StartDate.Date <= Agenda_monthCalendar.SelectionRange.Start.Date && c.EndDate.Date >= Agenda_monthCalendar.SelectionRange.Start.Date))
                    {
                        appiontments.Add(c);
                    } 
                }
            }
            SelectionMode selectionMode = Appointment_listBox.SelectionMode;
            Appointment_listBox.SelectionMode = SelectionMode.None;
            appiontments.Sort();
            Appointment_listBox.DataSource = appiontments;
            Appointment_listBox.DisplayMember = "AgendaDisplay";
            Appointment_listBox.SelectionMode = selectionMode;           
        }

        private void Appiontment_button_Click(object sender, EventArgs e)
        {
            AgendaAddForm form = new AgendaAddForm(Account, CalendarEventAdministration, null);
            this.Visible = false;
            var closing = form.ShowDialog();
            if (closing == DialogResult.OK)
            {
                CalendarEventAdministration = form.CalendarEventAdministration;
                this.Visible = true;
                Agenda_monthCalendar_DateChanged(null, null);
            }
        }

        private void Appointment_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Appointment_listBox.SelectedValue != null)
            {
                CalendarEvent selected = null;
                if (Appointment_listBox.SelectedValue.GetType() == typeof(CalendarEvent))
                {
                     selected = (CalendarEvent)Appointment_listBox.SelectedValue;
                }
                if (Appointment_listBox.SelectedValue.GetType() == typeof(SchoolEvent))
                {
                     selected = (SchoolEvent)Appointment_listBox.SelectedValue;
                }
                if (Appointment_listBox.SelectedValue.GetType() == typeof(GameEvent))
                {
                     selected = (GameEvent)Appointment_listBox.SelectedValue;
                }
                AgendaDetailsForm form = new AgendaDetailsForm(selected,CalendarEventAdministration);
                this.Visible = false;
                form.Detail_Refresh();
                var closing = form.ShowDialog();
                if (closing == DialogResult.OK)
                {
                    CalendarEventAdministration = form.CalendarEventAdministration;
                    this.Visible = true;
                    Agenda_monthCalendar_DateChanged(null, null);
                }
            }
        }
    }
}
