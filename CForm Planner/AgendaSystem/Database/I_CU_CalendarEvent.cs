using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AgendaSystem
{
    public interface I_CU_CalendarEvent
    {
        void InsertCalendarEvent(CalendarEvent calendarEvent);
        void UpdateCalendarEvent(CalendarEvent calendarEvent);
    }
}
