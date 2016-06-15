using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AgendaSystem
{
    public class CUCalendarDatabase: I_CU_CalendarEvent
    {
        public void InsertCalendarEvent(CalendarEvent calendarEvent)
        {
            try
            {
                OracleParameter[] insertParameter =
                {
                    new OracleParameter("iTITEL", calendarEvent.Titel),
                    new OracleParameter("iNOTE", calendarEvent.Notes),
                    new OracleParameter("iSTARTDATE", calendarEvent.StartDate),
                    new OracleParameter("iENDDATE", calendarEvent.EndDate),
                    new OracleParameter("iMAIL", calendarEvent.AccountEmail)
                };
                DatabaseManager.ExecuteInsertQuery("InsertCalendarEvent", insertParameter);
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

                OracleParameter[] updateParameter =
                {
                    new OracleParameter("oldID", calendarEvent.ID),
                    new OracleParameter("nTITEL", calendarEvent.Titel),
                    new OracleParameter("nNOTE", calendarEvent.Notes),
                    new OracleParameter("nSTARTDATE", calendarEvent.StartDate),
                    new OracleParameter("nENDDATE", calendarEvent.EndDate),
                };
                DatabaseManager.ExecuteInsertQuery("UpdateCalendarEvent", updateParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
