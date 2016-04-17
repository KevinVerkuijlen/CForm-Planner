using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    [Serializable]
    public class SchoolEvent : CalendarEvent
    {
        public string Subject { get; set; }
        public string Assignment { get; set; }

        public SchoolEvent(string titel, string notes, DateTime startDate, DateTime endDate, string subject, string assignment, string accountemail)
            : base(titel, notes, startDate, endDate, accountemail)
        {
            if (titel == null)
            {
                throw new ArgumentNullException("titel", "title is empty");
            }
            if (notes == null)
            {
                throw new ArgumentNullException("notes", "notes is empty");
            }
            if (startDate == null)
            {
                throw new ArgumentNullException("startdate", "startdate is empty");
            }
            if (endDate == null)
            {
                throw new ArgumentNullException("enddate", "enddate is empty");
            }
            if (subject == null)
            {
                throw new ArgumentNullException("subject", "subject is empty");
            }
            if (assignment == null)
            {
                throw new ArgumentNullException("assignment", "assignment is empty");
            }
            this.Subject = subject;
            this.Assignment = assignment;
        }

        public override bool Equals(object obj)
        {
            if (obj is SchoolEvent)
            {
                SchoolEvent other = ((SchoolEvent)obj);
                return this.Titel == other.Titel
                    && this.StartDate == other.StartDate
                    && this.EndDate == other.EndDate
                    && this.Notes == other.Notes
                    && this.Subject ==  other.Subject
                    && this.Assignment == other.Assignment
                    && this.AccountEmail == other.AccountEmail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Titel.GetHashCode() ^ StartDate.GetHashCode() ^ EndDate.GetHashCode() ^ Notes.GetHashCode() ^ Subject.GetHashCode() ^ Assignment.GetHashCode() ^ AccountEmail.GetHashCode();
        }
    }
}
