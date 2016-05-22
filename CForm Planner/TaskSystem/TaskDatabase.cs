using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.TaskSystem.TaskForms
{
    public class TaskDatabase
    {
        public void InsertTask(string titel, string notes, int hourDuration, int minDuration, bool completed, string email)
        {
            OracleParameter[] insertParameter =
            {
                new OracleParameter("iTITEL", titel),
                new OracleParameter("iNOTE", notes),
                new OracleParameter("iHOURDURATION", hourDuration), 
                new OracleParameter("iMINDURATION", minDuration), 
                new OracleParameter("iCOMPLETED", Convert.ToInt32(completed)),
                new OracleParameter("iMAIL", email)
            };
            DatabaseManager.ExecuteInsertQuery("InsertTask", insertParameter);
        }

        public bool DeleteTask(Task task)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                            new OracleParameter("iTITEL", task.Titel),
                            new OracleParameter("iNOTE", task.Notes),
                            new OracleParameter("iMAIL", task.Accountemail)
                        };
                DatabaseManager.ExecuteDeleteQuery("DeleteTask", deleteParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateTask(string oldTitel, string oldNotes, string oldEmail, string newTitel, string newNotes, int hourDuration, 
            int minDuration, bool completed)
        {
            try
            {
                OracleParameter[] updateParameter =
            {
                new OracleParameter("oTITEL", oldTitel),
                new OracleParameter("oNOTE", oldNotes),
                new OracleParameter("oMAIL", oldEmail),
                new OracleParameter("nTITEL", newTitel),
                new OracleParameter("nNOTE", newNotes),
                new OracleParameter("nHOURDURATION", hourDuration),
                new OracleParameter("nMINDURATION", minDuration),  
                new OracleParameter("nCOMPLETED", Convert.ToInt32(completed))
            };
                DatabaseManager.ExecuteInsertQuery("UpdateTask", updateParameter);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public bool GetTask(Task task)
        {
            OracleParameter[] checkParameter =
            {
                new OracleParameter("TITEL", task.Titel),
                new OracleParameter("NOTE", task.Notes),
                new OracleParameter("EMAILADDRESS", task.Accountemail)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTask"],
                checkParameter);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Task> GetTasks(string mail)
        {
            List<Task> loaded = new List<Task>();
            OracleParameter[] checkParameter =
            {
                        new OracleParameter("mail", mail)
                    };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllTasks"],
                checkParameter);
            foreach (DataRow reader in dt.Rows)
            {
                string titel = (String)reader["TITEL"];
                string note = (String)reader["NOTE"];
                int hourDuration = Convert.ToInt32(reader["HOUR_DURATION"]);
                int minDuration = Convert.ToInt32(reader["MIN_DURATION"]);
                bool completed = Convert.ToBoolean(reader["COMPLETED"]);
                string email = (String)reader["EMAILADDRESS"];
                loaded.Add(new Task(titel, note, hourDuration, minDuration, completed, email));
            }
            return loaded;
        }
    }
}
