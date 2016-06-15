using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AgendaSystem.Database
{
    public class CUGameEventDatabase : I_CU_CalendarEvent
    {
        private CalendarEventDatabase calendarEventDatabase = new CalendarEventDatabase();

        public void InsertCalendarEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent is GameEvent)
            {
                GameEvent gameEvent = (GameEvent) calendarEvent;
                try
                {
                    CalendarEvent CEvent = calendarEventDatabase.CheckCalendarDatabase(gameEvent.Titel,
                        gameEvent.StartDate, gameEvent.EndDate, gameEvent.AccountEmail);
                    OracleParameter[] insertGameParameter =
                    {
                        new OracleParameter("iGAMENAME", gameEvent.GameName),
                        new OracleParameter("iId", CEvent.ID)
                    };
                    DatabaseManager.ExecuteInsertQuery("InsertGameEvent", insertGameParameter);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UpdateCalendarEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent is GameEvent)
            {
                GameEvent gameEvent = (GameEvent)calendarEvent;
                try
                {

                    OracleParameter[] updateGameParameter =
                {
                    new OracleParameter("oldID", gameEvent.ID),

                    new OracleParameter("nGAMENAME", gameEvent.GameName),
                };
                    DatabaseManager.ExecuteInsertQuery("UpdateGameEvent", updateGameParameter);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
