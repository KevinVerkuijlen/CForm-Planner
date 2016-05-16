using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    [Serializable]
    public class GameEvent: CalendarEvent
    {
        public string GameName { get; set; }

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

        public override bool Update(string titel, string notes, DateTime startDate, DateTime endDate, string gamename, string accountemail)
        {
            if (Titel != titel || Notes != notes || StartDate != startDate || EndDate != endDate ||
                GameName != gamename || AccountEmail != accountemail)
            {
                GameName = gamename;
                return base.Update(titel, notes, startDate, endDate, gamename, accountemail);
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
