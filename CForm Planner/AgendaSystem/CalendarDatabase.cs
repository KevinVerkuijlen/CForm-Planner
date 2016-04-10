using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.AgendaSystem
{
    public class CalendarDatabase
    {
        private Database db = new Database();

        public void InsertCalendarEvent(CalendarEvent calendarEvent)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                this.db.Command.ExecuteNonQuery();

                this.db.Query = "INSERT_CALENDAREVENT";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iTITEL",OracleDbType.Varchar2).Value =  calendarEvent.Titel;
                this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = calendarEvent.Notes;
                this.db.Command.Parameters.Add("iSTARTDATE", OracleDbType.Date).Value = calendarEvent.StartDate;
                this.db.Command.Parameters.Add("iENDDATE", OracleDbType.Date).Value = calendarEvent.EndDate;
                this.db.Command.Parameters.Add("iMAIL",OracleDbType.Varchar2).Value =  calendarEvent.AccountEmail;
                this.db.Command.ExecuteNonQuery();

                if (calendarEvent.GetType() == typeof(SchoolEvent))
                {
                    SchoolEvent schoolEvent = (SchoolEvent)calendarEvent;

                    this.db.Query = "INSERT_SCHOOLEVENT";
                    this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.db.Command.Parameters.Add("iTITEL", OracleDbType.Varchar2).Value = schoolEvent.Titel;
                    this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = schoolEvent.Notes;
                    this.db.Command.Parameters.Add("iSTARTDATE", OracleDbType.Date).Value = schoolEvent.StartDate;
                    this.db.Command.Parameters.Add("iENDDATE", OracleDbType.Date).Value = schoolEvent.EndDate;
                    this.db.Command.Parameters.Add("iSUBJECT", OracleDbType.Varchar2).Value = schoolEvent.Subject;
                    this.db.Command.Parameters.Add("iASSIGNMENT", OracleDbType.Varchar2).Value = schoolEvent.Assignment;
                    this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = schoolEvent.AccountEmail;                 
                    this.db.Command.ExecuteNonQuery();
                }
                if (calendarEvent.GetType() == typeof(GameEvent))
                {
                    GameEvent gameEvent = (GameEvent)calendarEvent;
                    this.db.Query = "INSERT_GAMEEVENT";
                    this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.db.Command.Parameters.Add("iTITEL", OracleDbType.Varchar2).Value = gameEvent.Titel;
                    this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = gameEvent.Notes;
                    this.db.Command.Parameters.Add("iSTARTDATE", OracleDbType.Date).Value = gameEvent.StartDate;
                    this.db.Command.Parameters.Add("iENDDATE", OracleDbType.Date).Value = gameEvent.EndDate;
                    this.db.Command.Parameters.Add("iGAMENAME", OracleDbType.Varchar2).Value = gameEvent.GameName;
                    this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = gameEvent.AccountEmail;
                    this.db.Command.ExecuteNonQuery();
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public void DeleteCalendarEvent(CalendarEvent calendarEvent)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                this.db.Command.ExecuteNonQuery();

                this.db.Query = "DELETE_CALENDAREVENT";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iTITEL", OracleDbType.Varchar2).Value = calendarEvent.Titel;
                this.db.Command.Parameters.Add("iSTARTDATE", OracleDbType.Date).Value = calendarEvent.StartDate;
                this.db.Command.Parameters.Add("iENDDATE", OracleDbType.Date).Value = calendarEvent.EndDate;
                this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = calendarEvent.Notes;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = calendarEvent.AccountEmail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public void UpdateCalendarEvent(CalendarEvent oldCalendarEvent, CalendarEvent newCalendarEvent)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "ALTER SESSION SET NLS_DATE_FORMAT ='DD-MM-YYYY HH24:MI:SS'";
                this.db.Command.ExecuteNonQuery();

                if (oldCalendarEvent.GetType() == typeof(SchoolEvent) && newCalendarEvent.GetType() == typeof(SchoolEvent))
                {
                    SchoolEvent oldSchoolEvent = (SchoolEvent)oldCalendarEvent;
                    SchoolEvent newSchoolEvent = (SchoolEvent)newCalendarEvent;

                    this.db.Query = "alter table SCHOOLEVENT disable constraint fk_Calendar_School";
                    this.db.Command.ExecuteNonQuery();

                    this.db.Query = "UPDATE_SCHOOLEVENT";
                    this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.db.Command.Parameters.Add("oTITEL", OracleDbType.Varchar2).Value = oldSchoolEvent.Titel;
                    this.db.Command.Parameters.Add("oSTARTDATE", OracleDbType.Date).Value = oldSchoolEvent.StartDate;
                    this.db.Command.Parameters.Add("oENDDATE", OracleDbType.Date).Value = oldSchoolEvent.EndDate;
                    this.db.Command.Parameters.Add("oNOTE", OracleDbType.Varchar2).Value = oldSchoolEvent.Notes;
                    this.db.Command.Parameters.Add("oSUBJECT", OracleDbType.Varchar2).Value = oldSchoolEvent.Subject;
                    this.db.Command.Parameters.Add("oASSIGNMENT", OracleDbType.Varchar2).Value = oldSchoolEvent.Assignment;
                    this.db.Command.Parameters.Add("oMAIL", OracleDbType.Varchar2).Value = oldSchoolEvent.AccountEmail;
                    this.db.Command.Parameters.Add("nTITEL", OracleDbType.Varchar2).Value = newSchoolEvent.Titel;
                    this.db.Command.Parameters.Add("nSTARTDATE", OracleDbType.Date).Value = newSchoolEvent.StartDate;
                    this.db.Command.Parameters.Add("nENDDATE", OracleDbType.Date).Value = newSchoolEvent.EndDate;
                    this.db.Command.Parameters.Add("nNOTE", OracleDbType.Varchar2).Value = newSchoolEvent.Notes;
                    this.db.Command.Parameters.Add("nSUBJECT", OracleDbType.Varchar2).Value = newSchoolEvent.Subject;
                    this.db.Command.Parameters.Add("nASSIGNMENT", OracleDbType.Varchar2).Value = newSchoolEvent.Assignment;
                    this.db.Command.Parameters.Add("nMAIL", OracleDbType.Varchar2).Value = newSchoolEvent.AccountEmail;
                    this.db.Command.ExecuteNonQuery();
                }
                if (oldCalendarEvent.GetType() == typeof(GameEvent) && newCalendarEvent.GetType() == typeof(GameEvent))
                {
                    GameEvent oldGameEvent = (GameEvent)oldCalendarEvent;
                    GameEvent newGameEvent = (GameEvent)newCalendarEvent;

                    this.db.Query = "alter table GAMEEVENT disable constraint fk_Calendar_Game";
                    this.db.Command.ExecuteNonQuery();

                    this.db.Query = "UPDATE_GAMEEVENT";
                    this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.db.Command.Parameters.Add("oTITEL", OracleDbType.Varchar2).Value = oldGameEvent.Titel;
                    this.db.Command.Parameters.Add("oSTARTDATE", OracleDbType.Date).Value = oldGameEvent.StartDate;
                    this.db.Command.Parameters.Add("oENDDATE", OracleDbType.Date).Value = oldGameEvent.EndDate;
                    this.db.Command.Parameters.Add("oNOTE", OracleDbType.Varchar2).Value = oldGameEvent.Notes;
                    this.db.Command.Parameters.Add("oGAMENAME", OracleDbType.Varchar2).Value = oldGameEvent.GameName;
                    this.db.Command.Parameters.Add("oMAIL", OracleDbType.Varchar2).Value = oldGameEvent.AccountEmail;
                    this.db.Command.Parameters.Add("nTITEL", OracleDbType.Varchar2).Value = newGameEvent.Titel;
                    this.db.Command.Parameters.Add("nSTARTDATE", OracleDbType.Date).Value = newGameEvent.StartDate;
                    this.db.Command.Parameters.Add("nENDDATE", OracleDbType.Date).Value = newGameEvent.EndDate;
                    this.db.Command.Parameters.Add("nNOTE", OracleDbType.Varchar2).Value = newGameEvent.Notes;
                    this.db.Command.Parameters.Add("nGAMENAME", OracleDbType.Varchar2).Value = newGameEvent.GameName;
                    this.db.Command.Parameters.Add("nMAIL", OracleDbType.Varchar2).Value = newGameEvent.AccountEmail;
                    this.db.Command.ExecuteNonQuery();
                }

                this.db.Query = "UPDATE_CALENDAREVENT";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("oTITEL", OracleDbType.Varchar2).Value = oldCalendarEvent.Titel;
                this.db.Command.Parameters.Add("oSTARTDATE", OracleDbType.Date).Value = oldCalendarEvent.StartDate;
                this.db.Command.Parameters.Add("oENDDATE", OracleDbType.Date).Value = oldCalendarEvent.EndDate;
                this.db.Command.Parameters.Add("oNOTE", OracleDbType.Varchar2).Value = oldCalendarEvent.Notes;
                this.db.Command.Parameters.Add("oMAIL", OracleDbType.Varchar2).Value = oldCalendarEvent.AccountEmail;
                this.db.Command.Parameters.Add("nTITEL", OracleDbType.Varchar2).Value = newCalendarEvent.Titel;
                this.db.Command.Parameters.Add("nSTARTDATE", OracleDbType.Date).Value = newCalendarEvent.StartDate;
                this.db.Command.Parameters.Add("nENDDATE", OracleDbType.Date).Value = newCalendarEvent.EndDate;
                this.db.Command.Parameters.Add("nNOTE", OracleDbType.Varchar2).Value = newCalendarEvent.Notes;
                this.db.Command.Parameters.Add("nMAIL", OracleDbType.Varchar2).Value = newCalendarEvent.AccountEmail;
                this.db.Command.ExecuteNonQuery();

                this.db.Query = "alter table SCHOOLEVENT enable constraint fk_Calendar_School";
                this.db.Command.ExecuteNonQuery();
                this.db.Query = "alter table GAMEEVENT enable constraint fk_Calendar_Game";
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public CalendarEvent GetCalendarEvent()
        {
            return null;
        }

        public List<CalendarEvent> GetAllCalendarEvent(Account account)
        {
            List<CalendarEvent> agenda = new List<CalendarEvent>();
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT C.*, S.SUBJECT, S.ASSIGNMENT, G.GAMENAME "+
                                  "FROM CALENDAREVENT C "+
                                  "left join SCHOOLEVENT S on C.TITEL = S.TITEL AND C.NOTE = S.NOTE AND C.STARTDATE = S.STARTDATE AND C.ENDDATE = S.ENDDATE AND C.EMAILADDRESS = S.EMAILADDRESS "+
                                  "left join GAMEEVENT G on C.TITEL = G.TITEL AND C.NOTE = G.NOTE AND C.STARTDATE = G.STARTDATE AND C.ENDDATE = G.ENDDATE AND C.EMAILADDRESS = G.EMAILADDRESS "+
                                  "WHERE C.EMAILADDRESS = :mail";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", account.EmailAdress));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string titel =(String)reader["TITEL"];
                    string notes = (String)reader["NOTE"];
                    DateTime startDate = (DateTime)reader["STARTDATE"];
                    DateTime endDate = (DateTime)reader["ENDDATE"];
                    string email = (String)reader["EMAILADDRESS"];
                    string subject = (String)reader["SUBJECT"];
                    string assignment = (String)reader["ASSIGNMENT"];
                    string gameName = (String)reader["GAMENAME"];
                    if (subject != "" && assignment != "")
                    {
                        agenda.Add(new SchoolEvent(titel, notes, startDate, endDate, subject, assignment, email));
                    }
                    else
                    {
                        if (gameName != "")
                        {
                            agenda.Add(new GameEvent(titel, notes, startDate, endDate, gameName, email));
                        }
                        else
                        {
                            agenda.Add(new CalendarEvent(titel, notes, startDate, endDate, email));
                        }
                    }                 
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.CloseConnection();
            }
            return agenda;
        }
    }
}
