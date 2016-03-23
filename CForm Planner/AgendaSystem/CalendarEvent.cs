using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    public abstract class CalendarEvent
    {
        public string Titel { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountEmail { get; set; }

        public CalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string accountemail)
        {
            if (titel == null)
            {
                throw new ArgumentNullException("titel", "title is empty");
            }
            if (notes == null)
            {
                throw new ArgumentNullException("notes", "notes is empty");
            }
            if(startDate == null)
            {
                throw new ArgumentNullException("startdate", "startdate is empty");
            }
            if (endDate == null)
            {
                throw new ArgumentNullException("enddate", "enddate is empty");
            }
            this.Titel = titel;
            this.Notes = notes;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountEmail = accountemail;
        }

    }
}
