using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventAdministration
    {
        public CalendarDatabase calendarDatabase = new CalendarDatabase();
        public List<CalendarEvent> Agenda = new List<CalendarEvent>();

        public bool AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email)
        {
           CalendarEvent calendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);
           if (subject != "" && assignment != "")
           {
               calendarEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);
           }
           else if (gamename != "")
           {
               calendarEvent = new GameEvent(titel, notes, startdate, enddate, gamename, email);
           }
            int check = CheckForCalendarEvent(calendarEvent);
            if (check == -1)
            {
                if (calendarEvent.AccountEmail != "")
                {
                    CalendarEvent databaseCheck = calendarDatabase.GetCalendarEvent(calendarEvent);
                    if (databaseCheck == null)
                    {
                        Agenda.Add(calendarEvent);
                        calendarDatabase.InsertCalendarEvent(calendarEvent);
                        return true;
                    }
                    else
                    {
                        throw new PlannerExceptions("the Appiontment "+titel +" already exist in agenda, please reload your data");
                    }
                }
                else
                {
                    Agenda.Add(calendarEvent);
                    return true;
                }              
            }
            else
            {
                throw new PlannerExceptions("Appiontment already exist in agenda");
            }
        }

        public bool RemoveCalendarEvent(CalendarEvent calendarEvent)
        {
            int check = CheckForCalendarEvent(calendarEvent);
            if (check >= 0)
            {
                Agenda.Remove(calendarEvent);
                if (calendarEvent.AccountEmail != "")
                {
                    calendarDatabase.DeleteCalendarEvent(calendarEvent);
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Appiontment doesn't exist in agenda");
            }
        }

        public bool ChangeCalendarEvent(CalendarEvent oldCalendarEvent, string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email)
        {
            CalendarEvent newCalendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);
            if (subject != "" && assignment != "")
            {
                newCalendarEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);
            }
            else if (gamename != "")
            {
                newCalendarEvent = new GameEvent(titel, notes, startdate, enddate, gamename, email);
            }
            int oldCheck = CheckForCalendarEvent(oldCalendarEvent);
            int newCheck = CheckForCalendarEvent(newCalendarEvent);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Agenda.RemoveAt(oldCheck);
                Agenda.Insert(oldCheck, newCalendarEvent);
                if (oldCalendarEvent.AccountEmail!=""&& newCalendarEvent.AccountEmail != "")
                {
                    calendarDatabase.UpdateCalendarEvent(oldCalendarEvent, newCalendarEvent);
                }
                return true;
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

        public void MergeCalendar(Account user)
        {
            if (user != null)
            {
                List<CalendarEvent> loaded = calendarDatabase.GetAllCalendarEvent(user);
                this.Agenda = Agenda.Union(loaded).Distinct().ToList();
            }
        }

        public void UploadCalendar(Account user)
        {
            if (user != null)
            {
                foreach (CalendarEvent c in Agenda)
                {
                    if (c.AccountEmail != "")
                    {
                        CalendarEvent databaseCheck = calendarDatabase.GetCalendarEvent(c);
                        if (databaseCheck == null)
                        {
                            calendarDatabase.InsertCalendarEvent(c);
                        }
                        else
                        {
                            if (databaseCheck != c)
                            {
                                calendarDatabase.UpdateCalendarEvent(databaseCheck, c);
                            }
                        }
                    }
                }
            }
        }


        //om te laten herhalen moet de start en end op dezelfde dag staan
        public void RepeatCalendarEventEachDay(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email, int days)
        {
            for (int i = 1; i < days + 1; i++)
            {
                AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), subject, assignment, gamename, email);
            }
        }

        public void RepeatCalendarEventEachWorkDay(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email, int days)
        {
            for (int i = 1; i < days; i++)
            {
                DayOfWeek check = startdate.AddDays(i).DayOfWeek;
                if (check != DayOfWeek.Saturday)
                {
                    if (check != DayOfWeek.Sunday)
                    {
                        AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), subject, assignment, gamename, email);
                    }
                }
            }
        }

        public void RepeatCalendarEventEachDayInWeek(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email, int weeks)
        {
            for (int i = 1; i < weeks; i++)
            {
                AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7), subject, assignment, gamename, email);
            }
        }

    }   
}
