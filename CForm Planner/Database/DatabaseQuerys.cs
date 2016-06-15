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
            Query["Login"] = "SELECT * FROM ACCOUNT WHERE UPPER(EMAILADDRESS) = UPPER(:mail) AND PASSWORD = :pass";
            Query["InsertAccount"] = "INSERTACCOUNT";
            Query["UpdateAccount"] = "UPDATEACCOUNT";
            Query["GetFriends"] = "SELECT A.EMAILADDRESS, A.NAME, A.LASTNAME FROM ACCOUNT A " +
                                  "LEFT JOIN friend F " +
                                  "ON A.EMAILADDRESS = F.FRIENDADDRESS " +
                                  "WHERE F.EMAILADDRESS = :mail AND STATUS = 1 " +
                                  "UNION " +
                                  "SELECT A.EMAILADDRESS, A.NAME, A.LASTNAME FROM ACCOUNT A " +
                                  "LEFT JOIN friend F " +
                                  "ON A.EMAILADDRESS = F.EMAILADDRESS " +
                                  "WHERE F.FRIENDADDRESS = :mail AND STATUS = 1 ";
            Query["GetPendingFriends"] = "SELECT A.EMAILADDRESS, A.NAME, A.LASTNAME FROM ACCOUNT A, FRIEND F WHERE F.EMAILADDRESS = A.EMAILADDRESS AND F.FRIENDADDRESS = :mail AND STATUS = 0";
            Query["SearchFriend"] =
                "SELECT EMAILADDRESS, NAME, LASTNAME FROM ACCOUNT WHERE UPPER(EMAILADDRESS) LIKE UPPER('%'||:name||'%') OR UPPER(NAME) LIKE UPPER('%'||:name||'%') OR UPPER(LASTNAME) LIKE UPPER('%'||:name||'%')";
            Query["InsertFriend"] = "INSERTFRIEND";
            Query["DeleteFriend"] = "DELETEFRIEND";
            Query["AcceptFriend"] = "ACCEPTFRIEND";
            Query["DeclineFriend"] = "DECLINEFRIEND";


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
                                        "left join GAMEEVENT G on C.ID = G.CALENDAREEVENTID " +
                                        "WHERE TITEL = :titel AND STARTDATE = TO_DATE(:startdate, 'DD-MM-YYYY HH24:MI:SS') AND ENDDATE = TO_DATE(:enddate, 'DD-MM-YYYY HH24:MI:SS') AND EMAILADDRESS =:mail";
            Query["GetAllCalendarEvent"] = "SELECT C.*, S.SUBJECT, S.ASSIGNMENT, G.GAMENAME " +
                                           "FROM CALENDAREVENT C " +
                                           "left join SCHOOLEVENT S on C.ID = S.CALENDAREEVENTID " +
                                           "left join GAMEEVENT G on C.ID = G.CALENDAREEVENTID " +
                                           "WHERE C.EMAILADDRESS = :mail";
            Query["GetGames"] = "SELECT NAME FROM GAME";
            Query["GetRaids"] = "SELECT NAME FROM RAIDS WHERE GAMENAME = :Game";

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
            Query["GetTask"] = "SELECT * FROM TASK WHERE TITEL = :TITEL AND EMAILADDRESS = :MAIL";
            Query["GetAllTasks"] = "SELECT * FROM TASK WHERE EMAILADDRESS = :mail";

            //Unit test
            Query["DeleteTester"] = "DELETETESTER";
        }
    }
}
