using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AgendaSystem
{
    public class CUSchoolEventDatabase : I_CU_CalendarEvent
    {
        private CalendarEventDatabase calendarEventDatabase = new CalendarEventDatabase();

        public void InsertCalendarEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent is SchoolEvent)
            {
                SchoolEvent schoolEvent = (SchoolEvent) calendarEvent;
                try
                {
                    CalendarEvent CEvent = calendarEventDatabase.CheckCalendarDatabase(schoolEvent.Titel,
                        schoolEvent.StartDate, schoolEvent.EndDate, schoolEvent.AccountEmail);
                    OracleParameter[] insertSchoolParameter =
                    {
                        new OracleParameter("iSUBJECT", schoolEvent.Subject),
                        new OracleParameter("iASSIGNMENT", schoolEvent.Assignment),
                        new OracleParameter("iID", CEvent.ID)
                    };
                    DatabaseManager.ExecuteInsertQuery("InsertSchoolEvent", insertSchoolParameter);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UpdateCalendarEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent is SchoolEvent)
            {
                SchoolEvent schoolEvent = (SchoolEvent) calendarEvent;
                try
                {
                    OracleParameter[] updateSchoolParameter =
                    {
                        new OracleParameter("oldID", schoolEvent.ID),

                        new OracleParameter("nSUBJECT", schoolEvent.Subject),
                        new OracleParameter("nASSIGNMENT", schoolEvent.Assignment)
                    };
                    DatabaseManager.ExecuteInsertQuery("UpdateSchoolEvent", updateSchoolParameter);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
