using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventAdministration
    {
        public List<CalendarEvent> Agenda = new List<CalendarEvent>();

        public void test()
        {
            Agenda.Add(new CalendarEvent("test", "testtest", DateTime.Now, DateTime.Now, ""));
            Agenda.Add(new SchoolEvent("school","test",DateTime.Now, DateTime.Now, "software","project",""));
            Agenda.Add(new GameEvent("mini cacpot","3 tickets", DateTime.Now, DateTime.Now, "FFXIV",""));
        }
    }
}
