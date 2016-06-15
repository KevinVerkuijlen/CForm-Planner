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
        public bool InsertTask(string titel, string notes, int hourDuration, int minDuration, bool completed, string email)
        {
            try
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
                return true; 
            }
            catch (Exception)
            {
                
                throw;
            }            
        }

        public bool DeleteTask(Task task)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                            new OracleParameter("iID", task.ID)
                        };
                DatabaseManager.ExecuteDeleteQuery("DeleteTask", deleteParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateTask(int id, string newTitel, string newNotes, int hourDuration, 
            int minDuration, bool completed)
        {
            try
            {
                OracleParameter[] updateParameter =
            {
                new OracleParameter("iID", id),
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

        public Task GetTask(Task task)
        {
            Task found = null;
            OracleParameter[] checkParameter =
            {
                new OracleParameter("TITEL", task.Titel),
                new OracleParameter("EMAILADDRESS", task.AccountEmail)
            };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTask"],
                checkParameter);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow reader in dt.Rows)
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string titel = (String) reader["TITEL"];
                    string note = (String) reader["NOTE"];
                    int hourDuration = Convert.ToInt32(reader["HOUR_DURATION"]);
                    int minDuration = Convert.ToInt32(reader["MIN_DURATION"]);
                    bool completed = Convert.ToBoolean(reader["COMPLETED"]);
                    string email = (String) reader["EMAILADDRESS"];
                    found = new Task(id, titel, note, hourDuration, minDuration, completed, email);
                }
            }
            return found;
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
                int id = Convert.ToInt32(reader["ID"]);
                string titel = (String)reader["TITEL"];
                string note = (String)reader["NOTE"];
                int hourDuration = Convert.ToInt32(reader["HOUR_DURATION"]);
                int minDuration = Convert.ToInt32(reader["MIN_DURATION"]);
                bool completed = Convert.ToBoolean(reader["COMPLETED"]);
                string email = (String)reader["EMAILADDRESS"];
                loaded.Add(new Task(id, titel, note, hourDuration, minDuration, completed, email));
            }
            return loaded;
        }
    }
}
