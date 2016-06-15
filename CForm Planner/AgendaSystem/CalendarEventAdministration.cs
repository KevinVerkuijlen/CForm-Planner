using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;
using CForm_Planner.AgendaSystem.Database;
using CForm_Planner.GameSystem;


namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventAdministration
    {
        public static List<CalendarEvent> Agenda { get; set; }
        private CalendarEventDatabase CalendarEventDatabase { get; set; }

        public CalendarEventAdministration()
        {
            Agenda = new List<CalendarEvent>();
            CalendarEventDatabase = new CalendarEventDatabase();
        }

        public bool AddCalendarEvent(string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename, string email)
        {
            CalendarEvent calendarEvent = new CalendarEvent(titel, notes, startdate, enddate, email);
            if (subject != null && assignment != null)
            {
                calendarEvent = new SchoolEvent(titel, notes, startdate, enddate, subject, assignment, email);
            }
            else if (gamename != null)
            {
                calendarEvent = new GameEvent(titel, notes, startdate, enddate, gamename, email);
            }
            if (Agenda.Contains(calendarEvent) == false)
            {             
                if (calendarEvent.AccountEmail != "")
                {
                    try
                    {
                        if (CalendarEventDatabase.CheckCalendarDatabase(titel, startdate, enddate, email) == null)
                        {
                            CalendarEventDatabase.InsertCalendarEvent(calendarEvent);
                            Agenda.Add(CalendarEventDatabase.CheckCalendarDatabase(titel, startdate, enddate, email));
                            return true;
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
            if (Agenda.Contains(calendarEvent))
            {
                Agenda.Remove(calendarEvent);
                if (calendarEvent.AccountEmail != "")
                {
                    CalendarEvent deleteEvent = CalendarEventDatabase.CheckCalendarDatabase(calendarEvent.Titel, calendarEvent.StartDate,
                        calendarEvent.EndDate, calendarEvent.AccountEmail);
                    if (deleteEvent != null)
                    {
                        CalendarEventDatabase.DeleteCalendarEvent(deleteEvent.ID);
                    }
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Appiontment doesn't exist in agenda");
            }
        }

        public bool ChangeCalendarEvent(CalendarEvent oldCalendarEvent, string titel, string notes, DateTime startdate, DateTime enddate, string subject, string assignment, string gamename)
        {
            CalendarEvent calendarEvent = new CalendarEvent(oldCalendarEvent.ID, titel, notes, startdate, enddate, oldCalendarEvent.AccountEmail);
            if (subject != null && assignment != null)
            {
                calendarEvent = new SchoolEvent(oldCalendarEvent.ID, titel, notes, startdate, enddate, subject, assignment, oldCalendarEvent.AccountEmail);
            }
            else if (gamename != null)
            {
                calendarEvent = new GameEvent(oldCalendarEvent.ID, titel, notes, startdate, enddate, gamename, oldCalendarEvent.AccountEmail);
            }
            if (Agenda.Contains(oldCalendarEvent))
            {
                if (Agenda.Contains(calendarEvent) == false)
                {

                    if (oldCalendarEvent.AccountEmail != "")
                    {
                        CalendarEventDatabase.UpdateCalendarEvent(calendarEvent);
                    }
                    oldCalendarEvent.Update(calendarEvent);
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
                    Agenda = Agenda.Union(loaded).Distinct().ToList();
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
                        if (CalendarEventDatabase.CheckCalendarDatabase(c.Titel, c.StartDate, c.EndDate, c.AccountEmail) == null)
                        {
                            if (c.GetType() == typeof(SchoolEvent))
                            {
                                SchoolEvent schoolEvent = (SchoolEvent) c;
                                CalendarEventDatabase.InsertCalendarEvent(schoolEvent);
                            }
                            else if (c.GetType() == typeof(GameEvent))
                            {
                                GameEvent gameEvent = (GameEvent) c;
                                CalendarEventDatabase.InsertCalendarEvent(gameEvent);
                            }
                            else
                            {
                                CalendarEventDatabase.InsertCalendarEvent(c);
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
                        CalendarEventDatabase.InsertCalendarEvent(new SchoolEvent(schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate,
                            schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, user.EmailAdress));
                        Agenda.Remove(schoolEvent);
                        Agenda.Add(CalendarEventDatabase.CheckCalendarDatabase(schoolEvent.Titel, schoolEvent.StartDate,
                            schoolEvent.EndDate, user.EmailAdress));
                    }
                    else if (calendarEvent.GetType() == typeof(GameEvent))
                    {
                        GameEvent GameEvent = (GameEvent) calendarEvent;
                        CalendarEventDatabase.InsertCalendarEvent(new GameEvent(GameEvent.Titel, GameEvent.Notes, GameEvent.StartDate,
                            GameEvent.EndDate, GameEvent.GameName, user.EmailAdress));
                        Agenda.Remove(GameEvent);
                        Agenda.Add(CalendarEventDatabase.CheckCalendarDatabase(GameEvent.Titel, GameEvent.StartDate,
                            GameEvent.EndDate, user.EmailAdress));
                    }
                    else
                    {
                        CalendarEventDatabase.InsertCalendarEvent(new CalendarEvent(calendarEvent.Titel, calendarEvent.Notes, calendarEvent.StartDate, calendarEvent.EndDate,  user.EmailAdress));
                        Agenda.Remove(calendarEvent);
                        Agenda.Add(CalendarEventDatabase.CheckCalendarDatabase(calendarEvent.Titel, calendarEvent.StartDate,
                            calendarEvent.EndDate, user.EmailAdress));
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
                    AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), subject, assignment, null,
                         email);
                }
                else if (gamename != "")
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), null, null,
                        gamename, email);
                }
                else
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), null, null, null, email);
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
                            AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), subject, assignment, null,
                                 email);
                        }
                        else if (gamename != "")
                        {
                            AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), null, null,
                                gamename, email);
                        }
                        else
                        {
                            AddCalendarEvent(titel, notes, startdate.AddDays(i), enddate.AddDays(i), null, null, null, email);
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
                    AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7), subject, assignment, null,
                         email);
                }
                else if (gamename != "")
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7), null, null,
                        gamename, email);
                }
                else
                {
                    AddCalendarEvent(titel, notes, startdate.AddDays(i*7), enddate.AddDays(i*7), null, null, null, email);
                }
            }
        }

        public List<string> GetGames()
        {
            return CalendarEventDatabase.GamesList();
        }
        
        public List<string> GetRaids(string game)
        {
            return CalendarEventDatabase.RaidsList(game);
        }

        public List<Proposal> GameProposal(string players, string game, string raid, int days, int start, int end)
        {
            return CalendarEventDatabase.GameProposal(players, game, raid, days, start, end);
        }
    }   
}
