using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    [Serializable]
    public class CalendarEvent : IComparable<CalendarEvent>
    {
        public string Titel { get; protected set; }
        public string Notes { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string AccountEmail { get; protected set; }
        public string AgendaDisplay { get; protected set; }

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
            this.AgendaDisplay = titel + ", Start Date: " + startDate.ToString() + ", End Date: " + endDate.ToString();
        }


        public override bool Equals(object obj)
        {
            if (obj is CalendarEvent)
            {
                CalendarEvent other = ((CalendarEvent)obj);
                return this.Titel == other.Titel
                    && this.StartDate == other.StartDate
                    && this.EndDate == other.EndDate
                    && this.Notes == other.Notes
                    && this.AccountEmail == other.AccountEmail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Titel.GetHashCode() ^ StartDate.GetHashCode() ^ EndDate.GetHashCode() ^ Notes.GetHashCode() ^ AccountEmail.GetHashCode();
        }

        public int CompareTo(CalendarEvent other)
        {
            if (this.StartDate < other.StartDate)
            {
                return -1;
            }
            else if (this.StartDate > other.StartDate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
