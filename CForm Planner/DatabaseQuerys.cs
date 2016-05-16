using System.Collections.Generic;

namespace CForm_Planner
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            //Account Querys
            Query["GetAccount"] = "SELECT * FROM ACCOUNT WHERE EMAILADDRESS = :mail";
            Query["Login"] = "SELECT * FROM ACCOUNT WHERE EMAILADDRESS = :mail AND PASSWORD = :pass";
            Query["InsertAccount"] = "INSERTACCOUNT";
            Query["UpdateAccount"] = "UPDATEACCOUNT";
            //Query["GetFriends"] = "SELECT * FROM ACCOUNT WHERE EMAILADDRESS = :mail";

            //Calendar Querys
            //ALTER SESSION SET NLS_DATE_FORMAT ='DD-MM-YYYY HH24:MI:SS'
            Query["InsertCalendarEvent"] = "INSERTCALENDAREVENT";
            Query["InsertSchoolEvent"] = "INSERTSCHOOLEVENT";
            Query["InsertGameEvent"] = "INSERTGAMEEVENT";
            Query["DeleteCalendarEvent"] = "DELETECALENDAREVENT";
            Query["UpdateSchoolEvent"] = "UPDATESCHOOLEVENT";
            Query["UpdateGameEvent"] = "UPDATEGAMEEVENT";
            Query["UpdateCalendarEvent"] = "UPDATECALENDAREVENT";
            Query["GetCalendarEvent"] = "SELECT C.*, S.SUBJECT, S.ASSIGNMENT, G.GAMENAME  FROM CALENDAREVENT C " +
                                  "left join SCHOOLEVENT S on C.ID = S.CALENDAREEVENTID " +
                                  "left join GAMEEVENT G on C.ID = G.CALENDAREEVENTID "  +
                                  "WHERE TITEL = :titel AND NOTE = :note AND STARTDATE = TO_DATE(:startdate, 'DD-MM-YYYY HH24:MI:SS') AND ENDDATE = TO_DATE(:enddate, 'DD-MM-YYYY HH24:MI:SS') AND EMAILADDRESS =:mail";
            Query["GetAllCalendarEvent"] = "SELECT C.*, S.SUBJECT, S.ASSIGNMENT, G.GAMENAME " +
                                  "FROM CALENDAREVENT C " +
                                  "left join SCHOOLEVENT S on C.ID = S.CALENDAREEVENTID " +
                                  "left join GAMEEVENT G on C.ID = G.CALENDAREEVENTID "+
                                  "WHERE C.EMAILADDRESS = :mail";

            //Alarm Querys
            Query["InsertAlarm"] = "INSERTALARM";
            Query["DeleteAlarm"] = "DELETEALARM";
            Query["UpdateAlarm"] = "UPDATEALARM";
            Query["GetAlarm"] = "SELECT * FROM ALARM WHERE TIME = :TIME AND EMAILADDRESS = :MAIL";
            Query["GetAllAlarms"] = "SELECT * FROM ALARM WHERE EMAILADDRESS = :mail";

            //Note Querys
            Query["InsertNote"] = "INSERTNOTE";
            Query["DeleteNote"] = "DELETENOTE";
            Query["UpdateNote"] = "UPDATENOTE";
            Query["GetNote"] = "SELECT * FROM NOTES WHERE INFORMATION = :NOTE AND EMAILADDRESS = :MAIL";
            Query["GetAllNotes"] = "SELECT * FROM NOTES WHERE EMAILADDRESS = :mail";

            //Task Querys
            Query["InsertTask"] = "INSERTTASK";
            Query["DeleteTask"] = "DELETETASK";
            Query["UpdateTask"] = "UPDATETASK";
            Query["GetTask"] = "SELECT * FROM TASK WHERE TITEL = :TITEL AND NOTE = :NOTE AND EMAILADDRESS = :MAIL";
            Query["GetAllTasks"] = "SELECT * FROM TASK WHERE EMAILADDRESS = :mail";

            //Unit test
            Query["DeleteTester"] = "DELETETESTER";
        }
    }
}
