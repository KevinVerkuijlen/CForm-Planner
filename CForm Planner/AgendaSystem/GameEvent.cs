using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    public class GameEvent: CalendarEvent
    {
        public string GameName { get; set; }

        public GameEvent(string titel, string notes, DateTime startDate, DateTime endDate, string gameName, string accountemail)
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
            if (gameName == null)
            {
                throw new ArgumentNullException("gameEvent", "gameEvent is empty");
            }
            this.GameName = gameName;
        }
    }
}
