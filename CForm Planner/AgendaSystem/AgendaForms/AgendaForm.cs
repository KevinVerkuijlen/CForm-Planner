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
    public partial class AgendaForm : Form
    {
        public CalendarEventAdministration calendarEventAdministration = new CalendarEventAdministration();
        public AgendaForm()
        {
            InitializeComponent();
            EndDate_label.Visible = false;
        }

        private void AgendaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Agenda_monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            SelectedDate_label.Text = "Selected Date: "+ Agenda_monthCalendar.SelectionRange.Start.ToString();
            if (Agenda_monthCalendar.SelectionRange.End != Agenda_monthCalendar.SelectionRange.Start)
            {
                EndDate_label.Visible = true;
                EndDate_label.Text = "To: " + Agenda_monthCalendar.SelectionRange.End.ToString();
            }
        }

        private void Apiontment_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
