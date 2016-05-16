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
        public string Titel { get; private set; }
        public string Notes { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string AccountEmail { get; private set; }
        public string AgendaDisplay { get; private set; }

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
            Titel = titel;
            Notes = notes;
            StartDate = startDate;
            EndDate = endDate;
            AccountEmail = accountemail;
            AgendaDisplay = titel + ", Start Date: " + startDate.ToString() + ", End Date: " + endDate.ToString();
        }

        public virtual bool Update(string titel, string notes, DateTime startDate, DateTime endDate, string accountemail)
        {
            if (Titel != titel || Notes != notes || StartDate != startDate || EndDate != endDate ||
                AccountEmail != accountemail)
            {
                Titel = titel;
                Notes = notes;
                StartDate = startDate;
                EndDate = endDate;
                AccountEmail = accountemail;
                AgendaDisplay = titel + ", Start Date: " + startDate.ToString() + ", End Date: " + endDate.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Update(string titel, string notes, DateTime startDate, DateTime endDate, string gamename, string accountemail)
        {
            if (Titel != titel || Notes != notes || StartDate != startDate || EndDate != endDate ||
                AccountEmail != accountemail)
            {
                Titel = titel;
                Notes = notes;
                StartDate = startDate;
                EndDate = endDate;
                AccountEmail = accountemail;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Update(string titel, string notes, DateTime startDate, DateTime endDate, string subject, string assignment, string accountemail)
        {
            if (Titel != titel || Notes != notes || StartDate != startDate || EndDate != endDate ||
                AccountEmail != accountemail)
            {
                Titel = titel;
                Notes = notes;
                StartDate = startDate;
                EndDate = endDate;
                AccountEmail = accountemail;
                return true;
            }
            else
            {
                return false;
            }
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
