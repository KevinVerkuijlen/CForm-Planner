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

        public void AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string email)
        {
            CalendarEvent calendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);
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
                    }
                    else
                    {
                        throw new PlannerExceptions("Appiontment already exist in agenda, please reload your data");
                    }
                }
                else
                {
                    Agenda.Add(calendarEvent);
                }              
            }
            else
            {
                throw new PlannerExceptions("Appiontment already exist in agenda");
            }
        }

        public void AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string email)
        {
            SchoolEvent calendarEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);
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
                    }
                    else
                    {
                        throw new PlannerExceptions("Appiontment already exist in agenda, please reload your data");
                    }
                }
                else
                {
                    Agenda.Add(calendarEvent);
                }
            }
            else
            {
                throw new PlannerExceptions("Appiontment already exist in agenda");
            }
        }

        public void AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string gamename, string email)
        {
            GameEvent calendarEvent = new GameEvent(titel, notes, startdate, enddate, gamename, email);
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
                    }
                    else
                    {
                        throw new PlannerExceptions("Appiontment already exist in agenda, please reload your data");
                    }
                }
                else
                {
                    Agenda.Add(calendarEvent);
                }
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
                if (calendarEvent.AccountEmail != "")
                {
                    calendarDatabase.DeleteCalendarEvent(calendarEvent);
                }
            }
            else
            {
                throw new PlannerExceptions("Appiontment doesn't exist in agenda");
            }
        }

        public void ChangeCalendarEvent(CalendarEvent oldCalendarEvent, string titel, string notes, DateTime startdate, DateTime enddate, string email)
        {
            CalendarEvent newCalendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);
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
            }
            else
            {
                throw new PlannerExceptions("The old appointment doesn't exist in the agenda or the new appiontment already exist in the agenda");
            }
        }

        public void ChangeCalendarEvent(CalendarEvent oldCalendarEvent, string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string email)
        {
            SchoolEvent newCalendarEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);
            int oldCheck = CheckForCalendarEvent(oldCalendarEvent);
            int newCheck = CheckForCalendarEvent(newCalendarEvent);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Agenda.RemoveAt(oldCheck);
                Agenda.Insert(oldCheck, newCalendarEvent);
                if (oldCalendarEvent.AccountEmail != "" && newCalendarEvent.AccountEmail != "")
                {
                    calendarDatabase.UpdateCalendarEvent(oldCalendarEvent, newCalendarEvent);
                }
            }
            else
            {
                throw new PlannerExceptions("The old appointment doesn't exist in the agenda or the new appiontment already exist in the agenda");
            }
        }

        public void ChangeCalendarEvent(CalendarEvent oldCalendarEvent, string titel, string notes, DateTime startdate, DateTime enddate, string gamename, string email)
        {
            GameEvent newCalendarEvent = new GameEvent(titel, notes, startdate, enddate, gamename, email);
            int oldCheck = CheckForCalendarEvent(oldCalendarEvent);
            int newCheck = CheckForCalendarEvent(newCalendarEvent);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Agenda.RemoveAt(oldCheck);
                Agenda.Insert(oldCheck, newCalendarEvent);
                if (oldCalendarEvent.AccountEmail != "" && newCalendarEvent.AccountEmail != "")
                {
                    calendarDatabase.UpdateCalendarEvent(oldCalendarEvent, newCalendarEvent);
                }
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

    }   
}
