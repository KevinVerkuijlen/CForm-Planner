using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;


namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventAdministration
    {
        public List<CalendarEvent> Agenda { get; set; }
        private CalendarEventDatabase CalendarEventDatabase { get; set; }

        public CalendarEventAdministration()
        {
            Agenda = new List<CalendarEvent>();
            CalendarEventDatabase = new CalendarEventDatabase();
        }

        public bool AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string email)
        {
            CalendarEvent calendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);
            if (Agenda.Contains(calendarEvent) == false)
            {
                Agenda.Add(calendarEvent);
                if (calendarEvent.AccountEmail != "")
                {
                    try
                    {
                        int checkDB = CalendarEventDatabase.CheckCalendarDatabase(titel, notes, startdate, enddate, email);
                        if (checkDB == 0)
                        {
                            bool insert = CalendarEventDatabase.InsertCalendarEvent(titel, notes, startdate, enddate, email);
                            return insert;
                        }
                        else
                        {
                            throw new PlannerExceptions("Event already exist");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    return true;
                }              
            }
            else
            {
                throw new PlannerExceptions("Appiontment already exist in agenda");
            }
        }

        public bool AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string email)
        {
            SchoolEvent schoolEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);
            if (Agenda.Contains(schoolEvent) == false)
            {
                Agenda.Add(schoolEvent);
                if (schoolEvent.AccountEmail != "")
                {
                    try
                    {
                        int checkDB = CalendarEventDatabase.CheckCalendarDatabase(titel, notes, startdate, enddate, email);
                        if (checkDB == 0)
                        {
                            bool insert = CalendarEventDatabase.InsertCalendarEvent(titel, notes, startdate, enddate, subject, assignment, email);
                            return insert;
                        }
                        else
                        {
                            throw new PlannerExceptions("Event already exist");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new PlannerExceptions("Appiontment already exist in agenda");
            }
        }

        public bool AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string gamename, string email)
        {
            GameEvent calendarEvent = new GameEvent(titel, notes, startdate, enddate, gamename, email);
            if (Agenda.Contains(calendarEvent) == false)
            {
                Agenda.Add(calendarEvent);
                if (calendarEvent.AccountEmail != "")
                {
                    try
                    {
                        int checkDB = CalendarEventDatabase.CheckCalendarDatabase(titel, notes, startdate, enddate, email);
                        if (checkDB == 0)
                        {
                            bool insert = CalendarEventDatabase.InsertCalendarEvent(titel, notes, startdate, enddate, gamename, email);
                            return insert;
                        }
                        else
                        {
                            throw new PlannerExceptions("Event already exist");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
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
            if (Agenda.Contains(calendarEvent))
            {
                Agenda.Remove(calendarEvent);
                if (calendarEvent.AccountEmail != "")
                {
                    int id = CalendarEventDatabase.CheckCalendarDatabase(calendarEvent.Titel, calendarEvent.Notes, calendarEvent.StartDate,
                        calendarEvent.EndDate, calendarEvent.AccountEmail);
                    CalendarEventDatabase.DeleteCalendarEvent(id);
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Appiontment doesn't exist in agenda");
            }
        }

        public bool ChangeCalendarEvent(CalendarEvent oldCalendarEvent, string titel, string notes, DateTime startdate,
            DateTime enddate, string email)
        {
            CalendarEvent newCalendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);

            if (Agenda.Contains(oldCalendarEvent))
            {
                if (Agenda.Contains(newCalendarEvent) == false)
                {

                    if (email != "")
                    {
                        CalendarEventDatabase.UpdateCalendarEvent(oldCalendarEvent, titel, notes, startdate, enddate, email);
                    }
                    oldCalendarEvent.Update(titel, notes, startdate, enddate, email);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions("The new appiontment already exist in the agenda");
                }
            }
            else
            {
                throw new PlannerExceptions("The old appointment doesn't exist in the agenda");
            }
        }

        public bool ChangeCalendarEvent(SchoolEvent oldSchoolEvent, string titel, string notes, DateTime startdate,
            DateTime enddate, string subject, string assignment, string email)
        {
            SchoolEvent newSchoolEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);

            if (Agenda.Contains(oldSchoolEvent))
            {
                if (Agenda.Contains(newSchoolEvent) == false)
                {

                    if (email != "")
                    {
                        CalendarEventDatabase.UpdateCalendarEvent(oldSchoolEvent, titel, notes, startdate, enddate, subject,
                            assignment, email);
                    }
                    oldSchoolEvent.Update(titel, notes, startdate, enddate, subject, assignment, email);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions("The new appiontment already exist in the agenda");
                }
            }
            else
            {
                throw new PlannerExceptions("The old appointment doesn't exist in the agenda");
            }
        }

        public bool ChangeCalendarEvent(GameEvent oldGameEvent, string titel, string notes, DateTime startdate, DateTime enddate, string gamename, string email)
        {
            GameEvent newGameEvent =  new GameEvent(titel, notes, startdate, enddate, gamename, email);
            
            if (Agenda.Contains(oldGameEvent))
            {
                if (Agenda.Contains(newGameEvent) == false)
                {
                    if (email != "")
                    {
                        CalendarEventDatabase.UpdateCalendarEvent(oldGameEvent, titel, notes, startdate, enddate, gamename, email);
                    }
                    oldGameEvent.Update(titel, notes, startdate, enddate, gamename, email);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions("The new appiontment already exist in the agenda");
                }
            }
            else
            {
                throw new PlannerExceptions("The old appointment doesn't exist in the agenda");
            }
        }

        

        public void MergeCalendar(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<CalendarEvent> loaded = CalendarEventDatabase.GetCalendarEvents(user.EmailAdress);
                    this.Agenda = Agenda.Union(loaded).Distinct().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
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
                        CalendarEvent check = CalendarEventDatabase.GetCalendarEvent(c);
                        if (check == null)
                        {
                            if (c.GetType() == typeof(SchoolEvent))
                            {
                                SchoolEvent schoolEvent = (SchoolEvent) c;
                                CalendarEventDatabase.InsertCalendarEvent(schoolEvent.Titel, schoolEvent.Notes,
                                    schoolEvent.StartDate, schoolEvent.EndDate, schoolEvent.Subject,
                                    schoolEvent.Assignment, schoolEvent.AccountEmail);
                            }
                            else if (c.GetType() == typeof(GameEvent))
                            {
                                GameEvent gameEvent = (GameEvent) c;
                                CalendarEventDatabase.InsertCalendarEvent(gameEvent.Titel, gameEvent.Notes,
                                    gameEvent.StartDate, gameEvent.EndDate, gameEvent.GameName, gameEvent.AccountEmail);
                            }
                            else
                            {
                                CalendarEventDatabase.InsertCalendarEvent(c.Titel, c.Notes, c.StartDate, c.EndDate,
                                    c.AccountEmail);
                            }
                        }
                    }
                }
            }
        }

        public void CleanCalendar(Account user)
        {
            foreach (CalendarEvent calendarEvent in Agenda.ToList())
            {
                if (calendarEvent.AccountEmail == "" || calendarEvent.AccountEmail != user.EmailAdress)
                {
                    RemoveCalendarEvent(calendarEvent);
                }
            }
        }

        public void EmptyCalendarToUser(Account user)
        {
            foreach (CalendarEvent calendarEvent in Agenda.ToList())
            {
                if (calendarEvent.AccountEmail == "")
                {
                    if (calendarEvent.GetType() == typeof(SchoolEvent))
                    {
                        SchoolEvent schoolEvent = (SchoolEvent) calendarEvent;
                        CalendarEventDatabase.InsertCalendarEvent(schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate,
                            schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, user.EmailAdress);
                        schoolEvent.Update(schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate,
                            schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, user.EmailAdress);
                    }
                    else if (calendarEvent.GetType() == typeof(GameEvent))
                    {
                        GameEvent GameEvent = (GameEvent) calendarEvent;
                        CalendarEventDatabase.InsertCalendarEvent(GameEvent.Titel, GameEvent.Notes, GameEvent.StartDate,
                            GameEvent.EndDate, GameEvent.GameName, user.EmailAdress);
                        GameEvent.Update(GameEvent.Titel, GameEvent.Notes, GameEvent.StartDate,
                            GameEvent.EndDate, GameEvent.GameName, user.EmailAdress);
                    }
                    else
                    {
                        CalendarEventDatabase.InsertCalendarEvent(calendarEvent.Titel, calendarEvent.Notes, calendarEvent.StartDate, calendarEvent.EndDate,  user.EmailAdress);
                        calendarEvent.Update(calendarEvent.Titel, calendarEvent.Notes, calendarEvent.StartDate, calendarEvent.EndDate, user.EmailAdress);
                    }
                }
            }
        }

        //om te laten herhalen moet de start en end op dezelfde dag staan
        public void RepeatCalendarEventEachDay(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email, int days)
        {
            for (int i = 1; i < days + 1; i++)
            {
                if (subject != "" && assignment != "")
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), subject, assignment,
                         email);
                }
                else if (gamename != "")
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i),
                        gamename, email);
                }
                else
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), email);
                }
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
                        if (subject != "" && assignment != "")
                        {
                            AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), subject, assignment,
                                 email);
                        }
                        else if (gamename != "")
                        {
                            AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i),
                                gamename, email);
                        }
                        else
                        {
                            AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), email);
                        }
                    }
                }
            }
        }

        public void RepeatCalendarEventEachDayInWeek(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email, int weeks)
        {
            for (int i = 1; i < weeks; i++)
            {
                if (subject != "" && assignment != "")
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7), subject, assignment,
                         email);
                }
                else if (gamename != "")
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7),
                        gamename, email);
                }
                else
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7), email);
                }
            }
        }

    }   
}
