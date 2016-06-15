using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace CForm_Planner.AgendaSystem
{
    [Serializable]
    public class GameEvent: CalendarEvent
    {
        public string GameName { get; private set; }

        public GameEvent(string titel, string notes, DateTime startDate, DateTime endDate, string gameName, string accountemail)
            : base(titel,notes,startDate,endDate,accountemail)
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
            if (gameName == null)
            {
                throw new ArgumentNullException("gameEvent", "gameEvent is empty");
            }
            this.GameName = gameName;
        }

        public GameEvent(int id, string titel, string notes, DateTime startDate, DateTime endDate, string gameName, string accountemail)
            : base(id, titel, notes, startDate, endDate, accountemail)
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
            if (gameName == null)
            {
                throw new ArgumentNullException("gameEvent", "gameEvent is empty");
            }
            this.GameName = gameName;
        }

        public override bool Update(CalendarEvent calendarEvent)
        {
            GameEvent gameEvent = (GameEvent) calendarEvent;
            if (Titel != gameEvent.Titel || Notes != gameEvent.Notes || StartDate != gameEvent.StartDate || EndDate != gameEvent.EndDate ||
                GameName != gameEvent.GameName || AccountEmail != gameEvent.AccountEmail)
            {
                GameName = gameEvent.GameName;
                return base.Update(gameEvent);
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is GameEvent)
            {
                GameEvent other = ((GameEvent)obj);
                return this.Titel == other.Titel
                    && this.StartDate == other.StartDate
                    && this.EndDate == other.EndDate
                    && this.Notes == other.Notes
                    && this.GameName == other.GameName
                    && this.AccountEmail == other.AccountEmail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Titel.GetHashCode() ^ StartDate.GetHashCode() ^ EndDate.GetHashCode() ^ Notes.GetHashCode() ^ GameName.GetHashCode() ^ AccountEmail.GetHashCode();
        }
    }
}
