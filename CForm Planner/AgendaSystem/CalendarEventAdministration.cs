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

        public void AddCalendarEvent(CalendarEvent calendarEvent)
        {
            int check = CheckForCalendarEvent(calendarEvent);
            if (check == -1)
            {
                Agenda.Add(calendarEvent);
            }
            else
            {
                throw new PlannerExceptions("Appiontment already exist in agenda");
            }
        }

        public void RemoveCalendarEvent(CalendarEvent calendarEvent)
        {
            int check = CheckForCalendarEvent(calendarEvent);
            if (check >= 0)
            {
                Agenda.Remove(calendarEvent);
            }
            else
            {
                throw new PlannerExceptions("Appiontment doesn't exist in agenda");
            }
        }

        public void ChangeCalendarEvent(CalendarEvent oldCalendarEvent, CalendarEvent newCalendarEvent)
        {
            int oldCheck = CheckForCalendarEvent(oldCalendarEvent);
            int newCheck = CheckForCalendarEvent(newCalendarEvent);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Agenda.RemoveAt(oldCheck);
                Agenda.Insert(oldCheck, newCalendarEvent);
            }
            else
            {
                throw new PlannerExceptions("The old appointment doesn't exist in the agenda or the new appiontment already exist in the agenda");
            }
        }

        public int CheckForCalendarEvent(CalendarEvent calendarEvent)
        {
            int check = -1;
            foreach (CalendarEvent c in Agenda)
            {

                if (c.Titel == calendarEvent.Titel && c.Notes == calendarEvent.Notes && c.StartDate == calendarEvent.StartDate && c.EndDate == calendarEvent.EndDate)
                {
                    check = Agenda.IndexOf(c);
                }
            }
            return check;
        }
    }
}
