using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CForm_Planner.AgendaSystem.Database;
using CForm_Planner.GameSystem;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AgendaSystem
{
    public class CalendarEventDatabase
    {

        private static List<I_CU_CalendarEvent> cuCalendarEvents = new List<I_CU_CalendarEvent>()
        {
            new CUCalendarDatabase(),
        new CUSchoolEventDatabase(),
        new CUGameEventDatabase()
    };

        public void InsertCalendarEvent(CalendarEvent calendarEvent)
        {
            try
            {
                foreach (I_CU_CalendarEvent i in cuCalendarEvents)
                {
                    i.InsertCalendarEvent(calendarEvent);
                }
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

        public void UpdateCalendarEvent(CalendarEvent calendarEvent)
        {
            try
            {
                foreach (I_CU_CalendarEvent i in cuCalendarEvents)
                {
                    i.UpdateCalendarEvent(calendarEvent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CalendarEvent CheckCalendarDatabase(string titel, DateTime startdate, DateTime enddate, string email)
        {
            CalendarEvent calendarEvent = null;
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("titel", titel),
                    new OracleParameter("startdate", startdate.ToString("dd/MM/yyyy HH:mm:ss")),
                    new OracleParameter("enddate", enddate.ToString("dd/MM/yyyy HH:mm:ss")),
                    new OracleParameter("mail", email)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetCalendarEvent"],
                    checkParameter);
                if (dt.Rows.Count > 0)
                    foreach (DataRow reader in dt.Rows)
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string Titel = (String) reader["TITEL"];
                        string notes = (String) reader["NOTE"];
                        DateTime startDate = (DateTime) reader["STARTDATE"];
                        DateTime endDate = (DateTime) reader["ENDDATE"];
                        string Email = (String) reader["EMAILADDRESS"];
                        if (reader["SUBJECT"] != DBNull.Value && reader["ASSIGNMENT"] != DBNull.Value)
                        {
                            string subject = (String) reader["SUBJECT"];
                            string assignment = (String) reader["ASSIGNMENT"];
                            calendarEvent = new SchoolEvent(id, Titel, notes, startDate, endDate, subject, assignment,
                                Email);
                        }
                        else if (reader["GAMENAME"] != DBNull.Value)
                        {
                            string gameName = (String) reader["GAMENAME"];
                            calendarEvent = new GameEvent(id, Titel, notes, startDate, endDate, gameName, Email);
                        }
                        else
                        {
                            calendarEvent = new CalendarEvent(id, Titel, notes, startDate, endDate, Email);
                        }
                    }
            }
            catch (Exception)
            {
                throw;
            }
            return calendarEvent;
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
                int id = Convert.ToInt32(reader["ID"]);
                string titel = (String) reader["TITEL"];
                string notes = (String) reader["NOTE"];
                DateTime startDate = (DateTime) reader["STARTDATE"];
                DateTime endDate = (DateTime) reader["ENDDATE"];
                string email = (String) reader["EMAILADDRESS"];
                if (reader["SUBJECT"] != DBNull.Value && reader["ASSIGNMENT"] != DBNull.Value)
                {
                    string subject = (String) reader["SUBJECT"];
                    string assignment = (String) reader["ASSIGNMENT"];
                    calendarEvent = new SchoolEvent(id, titel, notes, startDate, endDate, subject, assignment, email);
                }
                else if (reader["GAMENAME"] != DBNull.Value)
                {
                    string gameName = (String) reader["GAMENAME"];
                    calendarEvent = new GameEvent(id, titel, notes, startDate, endDate, gameName, email);
                }
                else
                {
                    calendarEvent = new CalendarEvent(id, titel, notes, startDate, endDate, email);
                }
                loaded.Add(calendarEvent);
            }
            return loaded;
        }

        public List<string> GamesList()
        {
            List<string> Games = new List<string>();

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetGames"],
                null);
            foreach (DataRow reader in dt.Rows)
            {
                Games.Add((string)reader["NAME"]);
            }
            return Games;
        }

        public List<string> RaidsList(string game)
        {
            List<string> Raids = new List<string>();
            OracleParameter[] Parameter =
            {
                new OracleParameter(":Game", game)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetRaids"],
                Parameter);
            foreach (DataRow reader in dt.Rows)
            {
                Raids.Add((string)reader["NAME"]);
            }
            return Raids;
        }

        public List<Proposal> GameProposal(string players, string game, string raid, int days, int start, int end)
        {
            List<Proposal> proposals = new List<Proposal>();
            OracleParameter[] Parameter =
            {
                new OracleParameter("iPLAYERS", players),
                new OracleParameter("iGAME", game),
                new OracleParameter("iRAID", raid),
                new OracleParameter("iTODAY", DateTime.Now),
                new OracleParameter("iDAYS", days),
                new OracleParameter("iSTART", start),
                new OracleParameter("iEND", end), 
            };
            DataTable dt = DatabaseManager.ExecuteFunction("GameProposal", Parameter);
            foreach (DataRow reader in dt.Rows)
            {
                proposals.Add(new Proposal((DateTime)reader["LastEndTime"], (DateTime)reader["NextStartTime"], Convert.ToInt32(reader["TimeWindow"])));
            }
            return proposals;
        }
    }
}
