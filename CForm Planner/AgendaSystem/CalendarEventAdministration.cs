using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;
using Oracle.ManagedDataAccess.Client;


namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventAdministration
    {
        public List<CalendarEvent> Agenda { get; set; }

        public CalendarEventAdministration()
        {
           Agenda = new List<CalendarEvent>();
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
                        int checkDB = CheckCalendarDatabase(titel, notes, startdate, enddate, email);
                        if (checkDB == 0)
                        {
                            InsertCalendarEvent(titel, notes, startdate, enddate, email);
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
                        int checkDB = CheckCalendarDatabase(titel, notes, startdate, enddate, email);
                        if (checkDB == 0)
                        {
                            InsertCalendarEvent(titel, notes, startdate, enddate, subject, assignment, email);
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
                        int checkDB = CheckCalendarDatabase(titel, notes, startdate, enddate, email);
                        if (checkDB == 0)
                        {
                            InsertCalendarEvent(titel, notes, startdate, enddate, gamename, email);
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
                    int id = CheckCalendarDatabase(calendarEvent.Titel, calendarEvent.Notes, calendarEvent.StartDate,
                        calendarEvent.EndDate, calendarEvent.AccountEmail);
                    OracleParameter[] deleteParameter =
                        {
                            new OracleParameter("iID", id)
                        };
                    DatabaseManager.ExecuteDeleteQuery("DeleteCalendarEvent", deleteParameter);
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
                        UpdateCalendarEvent(oldCalendarEvent, titel, notes, startdate, enddate, email);
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
                        UpdateCalendarEvent(oldSchoolEvent, titel, notes, startdate, enddate, subject,
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
                        UpdateCalendarEvent(oldGameEvent, titel, notes, startdate, enddate, gamename, email);
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

        public void InsertCalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string email)
        {
            try
            {
                OracleParameter[] insertParameter =
                                {
                    new OracleParameter("iTITEL", titel),
                    new OracleParameter("iNOTE", notes),
                    new OracleParameter("iSTARTDATE", startDate),
                    new OracleParameter("iENDDATE", endDate),
                    new OracleParameter("iMAIL", email),
                };
                DatabaseManager.ExecuteInsertQuery("InsertCalendarEvent", insertParameter);
            }
            catch (Exception e)
            {
                string a = e.Message;
                throw;
            }
        }

        public void InsertCalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string subject,
            string assignment, string email)
        {
            InsertCalendarEvent(titel, notes, startDate, endDate, email);

            try
            {
                int id = CheckCalendarDatabase(titel, notes, startDate, endDate, email);
                OracleParameter[] insertSchoolParameter =
                {
                new OracleParameter("iSUBJECT", subject),
                new OracleParameter("iASSIGNMENT", assignment),
                new OracleParameter("iID", id)
            };
                DatabaseManager.ExecuteInsertQuery("InsertSchoolEvent", insertSchoolParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertCalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string gamename, string email)
        {
            InsertCalendarEvent(titel, notes, startDate, endDate, email);

            try
            {
                int id = CheckCalendarDatabase(titel, notes, startDate, endDate, email);
                OracleParameter[] insertGameParameter =
                {
                    new OracleParameter("iGAMENAME", gamename),
                    new OracleParameter("iId", id)
                };
                DatabaseManager.ExecuteInsertQuery("InsertGameEvent", insertGameParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    

        public void UpdateCalendarEvent(CalendarEvent oldCalendarEvent, string newTitel, string newNotes, DateTime newStartDate,
            DateTime newEndDate, string newEmail)
        {
            
            try
            {
                int oldID = CheckCalendarDatabase(oldCalendarEvent.Titel, oldCalendarEvent.Notes,
                        oldCalendarEvent.StartDate, oldCalendarEvent.EndDate,
                        oldCalendarEvent.AccountEmail);

                OracleParameter[] updateParameter =
                {
                    new OracleParameter("oldID", oldID),
                    new OracleParameter("nTITEL", newTitel),
                    new OracleParameter("nNOTE", newNotes),
                    new OracleParameter("nSTARTDATE", newStartDate),
                    new OracleParameter("nENDDATE", newEndDate),
                };
                DatabaseManager.ExecuteInsertQuery("UpdateCalendarEvent", updateParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCalendarEvent(SchoolEvent oldSchoolevent, string newTitel, string newNotes, DateTime newStartDate,
            DateTime newEndDate, string newSubject, string newAssignment, string newEmail)
        {
            UpdateCalendarEvent(oldSchoolevent, newTitel, newNotes, newStartDate, newEndDate, newEmail);

            int oldID = CheckCalendarDatabase(newTitel, newNotes, newStartDate, newEndDate, newEmail);
            try
            {
                OracleParameter[] updateSchoolParameter =
                {

                    new OracleParameter("oSUBJECT", oldSchoolevent.Subject),
                    new OracleParameter("oASSIGNMENT", oldSchoolevent.Assignment),
                    new OracleParameter("oldID", oldID),

                    new OracleParameter("nSUBJECT", newSubject),
                    new OracleParameter("nASSIGNMENT", newAssignment)
                };
                DatabaseManager.ExecuteInsertQuery("UpdateSchoolEvent", updateSchoolParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCalendarEvent(GameEvent oldGameEvent, string newTitel, string newNotes, DateTime newStartDate,
            DateTime newEndDate, string newGamename, string newEmail)
        {
            UpdateCalendarEvent(oldGameEvent, newTitel, newNotes, newStartDate, newEndDate, newEmail);

            int oldID = CheckCalendarDatabase(newTitel, newNotes, newStartDate, newEndDate, newEmail);
            try
            {
                OracleParameter[] updateGameParameter =
                {
                    new OracleParameter("oGAMENAME", oldGameEvent.GameName),
                    new OracleParameter("oldID", oldID),

                    new OracleParameter("nGAMENAME", newGamename),
                };
                DatabaseManager.ExecuteInsertQuery("UpdateGameEvent", updateGameParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CheckCalendarDatabase(string titel, string notes, DateTime startdate, DateTime enddate, string email)
        {
            int ID = 0;
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("titel", titel),
                    new OracleParameter("note", notes),
                    new OracleParameter("startdate", startdate.ToString("dd/MM/yyyy HH:mm:ss")),
                    new OracleParameter("enddate", enddate.ToString("dd/MM/yyyy HH:mm:ss")),
                    new OracleParameter("mail", email)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetCalendarEvent"],
                    checkParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    ID = Convert.ToInt32(reader["ID"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ID;
        }

        public void MergeCalendar(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<CalendarEvent> loaded = new List<CalendarEvent>();
                    OracleParameter[] checkParameter =
                    {
                        new OracleParameter("mail", user.EmailAdress)
                    };
                    DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllCalendarEvent"],
                        checkParameter);
                    foreach (DataRow reader in dt.Rows)
                    {
                        CalendarEvent calendarEvent = null;
                        string titel = (String) reader["TITEL"];
                        string notes = (String) reader["NOTE"];
                        DateTime startDate = (DateTime) reader["STARTDATE"];
                        DateTime endDate = (DateTime) reader["ENDDATE"];
                        string email = (String) reader["EMAILADDRESS"];
                        if (reader["SUBJECT"] != DBNull.Value && reader["ASSIGNMENT"] != DBNull.Value)
                        {
                            string subject = (String) reader["SUBJECT"]; 
                            string assignment = (String) reader["ASSIGNMENT"];
                            calendarEvent = new SchoolEvent(titel, notes, startDate, endDate, subject, assignment, email);
                        }
                        else if (reader["GAMENAME"] != DBNull.Value)
                        {
                            string gameName = (String) reader["GAMENAME"];
                            calendarEvent = new GameEvent(titel, notes, startDate, endDate, gameName, email);
                        }
                        else
                        {
                            calendarEvent = new CalendarEvent(titel, notes, startDate, endDate, email);
                        }
                        loaded.Add(calendarEvent);
                    }
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
                        try
                        {
                            OracleParameter[] checkParameter =
                        {
                            new OracleParameter("TITEL", c.Titel),
                            new OracleParameter("NOTE", c.Notes),
                            new OracleParameter("STARTDATE", c.StartDate.ToString("dd/MM/yyyy HH:mm:ss")),
                            new OracleParameter("ENDDATE", c.EndDate.ToString("dd/MM/yyyy HH:mm:ss")),
                            new OracleParameter("EMAIL", c.AccountEmail)
                        };
                            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetCalendarEvent"],
                                checkParameter);
                            foreach (DataRow reader in dt.Rows)
                            {
                                if (reader["ID"] == DBNull.Value && reader["TITEL"] == DBNull.Value && reader["NOTE"] == DBNull.Value &&
                                    reader["STARTDATE"] == DBNull.Value && reader["ENDDATE"] == DBNull.Value && reader["EMAILADDRESS"] == DBNull.Value)
                                {
                                    if (c.GetType() == typeof(SchoolEvent))
                                    {
                                        SchoolEvent schoolEvent = (SchoolEvent) c;
                                        InsertCalendarEvent(schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate, schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, schoolEvent.AccountEmail);
                                    }
                                    else if (c.GetType() == typeof(GameEvent))
                                    {
                                        GameEvent gameEvent = (GameEvent) c;
                                        InsertCalendarEvent(gameEvent.Titel, gameEvent.Notes, gameEvent.StartDate, gameEvent.EndDate, gameEvent.GameName, gameEvent.AccountEmail);
                                    }
                                    else
                                    {
                                        InsertCalendarEvent(c.Titel, c.Notes, c.StartDate, c.EndDate, c.AccountEmail);
                                    }
                                }
                                else
                                {
                                    UpdateCalendarEvent(new CalendarEvent((string)reader["TITEL"], (string)reader["NOTE"], (DateTime)reader["STARTDATE"], (DateTime)reader["ENDDATE"], (string)reader["EMAILADDRESS"]), c.Titel, c.Notes, c.StartDate, c.EndDate, c.AccountEmail);

                                    if (c.GetType() == typeof(SchoolEvent))
                                    {
                                        SchoolEvent schoolEvent = (SchoolEvent)c;
                                        UpdateCalendarEvent(new SchoolEvent((string) reader["TITEL"], (string)reader["NOTE"], (DateTime)reader["STARTDATE"], (DateTime)reader["ENDDATE"], (string)reader["SUBJECT"], (string)reader["ASSIGNMENT"], (string)reader["EMAILADDRESS"]), schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate, schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, schoolEvent.AccountEmail);
                                    }
                                    else if (c.GetType() == typeof(GameEvent))
                                    {
                                        GameEvent gameEvent = (GameEvent)c;
                                        UpdateCalendarEvent(new GameEvent((string)reader["TITEL"], (string)reader["NOTE"], (DateTime)reader["STARTDATE"], (DateTime)reader["ENDDATE"], (string)reader["GAMENAME"], (string)reader["EMAILADDRESS"]), gameEvent.Titel, gameEvent.Notes, gameEvent.StartDate, gameEvent.EndDate, gameEvent.GameName, gameEvent.AccountEmail);
                                    }   
                                }
                            }
                        }
                        catch (Exception)
                        {
                            throw;
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
                        InsertCalendarEvent(schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate,
                            schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, user.EmailAdress);
                        schoolEvent.Update(schoolEvent.Titel, schoolEvent.Notes, schoolEvent.StartDate,
                            schoolEvent.EndDate, schoolEvent.Subject, schoolEvent.Assignment, user.EmailAdress);
                    }
                    else if (calendarEvent.GetType() == typeof(GameEvent))
                    {
                        GameEvent GameEvent = (GameEvent) calendarEvent;
                        InsertCalendarEvent(GameEvent.Titel, GameEvent.Notes, GameEvent.StartDate,
                            GameEvent.EndDate, GameEvent.GameName, user.EmailAdress);
                        GameEvent.Update(GameEvent.Titel, GameEvent.Notes, GameEvent.StartDate,
                            GameEvent.EndDate, GameEvent.GameName, user.EmailAdress);
                    }
                    else
                    {
                        InsertCalendarEvent(calendarEvent.Titel, calendarEvent.Notes, calendarEvent.StartDate, calendarEvent.EndDate,  user.EmailAdress);
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
