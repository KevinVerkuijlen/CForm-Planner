using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventDatabase
    {
        public bool InsertCalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string email)
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
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertCalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string subject,
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
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertCalendarEvent(string titel, string notes, DateTime startDate, DateTime endDate, string gamename, string email)
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
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCalendarEvent(int id)
        {
            try
            {
                OracleParameter[] deleteParameter =
                        {
                            new OracleParameter("iID", id)
                        };
                DatabaseManager.ExecuteDeleteQuery("DeleteCalendarEvent", deleteParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCalendarEvent(CalendarEvent oldCalendarEvent, string newTitel, string newNotes, DateTime newStartDate,
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
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCalendarEvent(SchoolEvent oldSchoolevent, string newTitel, string newNotes, DateTime newStartDate,
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
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCalendarEvent(GameEvent oldGameEvent, string newTitel, string newNotes, DateTime newStartDate,
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
                return true;
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

        public CalendarEvent GetCalendarEvent(CalendarEvent calendarEvent)
        {
            CalendarEvent found = null;

            OracleParameter[] checkParameter =
                {
                    new OracleParameter("TITEL", calendarEvent.Titel),
                    new OracleParameter("NOTE", calendarEvent.Notes),
                    new OracleParameter("STARTDATE", calendarEvent.StartDate.ToString("dd/MM/yyyy HH:mm:ss")),
                    new OracleParameter("ENDDATE", calendarEvent.EndDate.ToString("dd/MM/yyyy HH:mm:ss")),
                    new OracleParameter("EMAIL", calendarEvent.AccountEmail)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetCalendarEvent"],
                    checkParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    string titel = (String) reader["TITEL"];
                    string notes = (String) reader["NOTE"];
                    DateTime startDate = (DateTime) reader["STARTDATE"];
                    DateTime endDate = (DateTime) reader["ENDDATE"];
                    string email = (String) reader["EMAILADDRESS"];
                    if (reader["SUBJECT"] != DBNull.Value && reader["ASSIGNMENT"] != DBNull.Value)
                    {
                        string subject = (String) reader["SUBJECT"];
                        string assignment = (String) reader["ASSIGNMENT"];
                        found = new SchoolEvent(titel, notes, startDate, endDate, subject, assignment, email);
                    }
                    else if (reader["GAMENAME"] != DBNull.Value)
                    {
                        string gameName = (String) reader["GAMENAME"];
                        found = new GameEvent(titel, notes, startDate, endDate, gameName, email);
                    }
                    else
                    {
                        found = new CalendarEvent(titel, notes, startDate, endDate, email);
                    }                   
                }
            return found;
        }

        public
            List<CalendarEvent> GetCalendarEvents(string mail)
        {
            List<CalendarEvent> loaded = new List<CalendarEvent>();
            OracleParameter[] checkParameter =
            {
                        new OracleParameter("mail", mail)
                    };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllCalendarEvent"],
                checkParameter);
            foreach (DataRow reader in dt.Rows)
            {
                CalendarEvent calendarEvent = null;
                string titel = (String)reader["TITEL"];
                string notes = (String)reader["NOTE"];
                DateTime startDate = (DateTime)reader["STARTDATE"];
                DateTime endDate = (DateTime)reader["ENDDATE"];
                string email = (String)reader["EMAILADDRESS"];
                if (reader["SUBJECT"] != DBNull.Value && reader["ASSIGNMENT"] != DBNull.Value)
                {
                    string subject = (String)reader["SUBJECT"];
                    string assignment = (String)reader["ASSIGNMENT"];
                    calendarEvent = new SchoolEvent(titel, notes, startDate, endDate, subject, assignment, email);
                }
                else if (reader["GAMENAME"] != DBNull.Value)
                {
                    string gameName = (String)reader["GAMENAME"];
                    calendarEvent = new GameEvent(titel, notes, startDate, endDate, gameName, email);
                }
                else
                {
                    calendarEvent = new CalendarEvent(titel, notes, startDate, endDate, email);
                }
                loaded.Add(calendarEvent);
            }
            return loaded;
        }
    }
}
