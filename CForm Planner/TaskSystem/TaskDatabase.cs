using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.TaskSystem
{
    public class TaskDatabase
    {
        private Database db = new Database();

        public void InsertTask(Task task)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "INSERT_TASK";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iTITEL", OracleDbType.Varchar2).Value = task.Titel;
                this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = task.Notes;
                int insertCompleted = 0;
                if (task.Completed == true)
                {
                    insertCompleted = 1;
                }
                else
                {
                    if (task.Completed == false)
                    {
                        insertCompleted = 0;
                    }
                }
                this.db.Command.Parameters.Add("iCOMPLETED", OracleDbType.Int32).Value = insertCompleted;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value =  task.Accountemail;
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

        public void DeleteTask(Task task)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "DELETE_TASK";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iTITEL", OracleDbType.Varchar2).Value = task.Titel;
                this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = task.Notes;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = task.Accountemail;
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

        public void UpdateTask(Task oldTask, Task newTask)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "UPDATE_TASK";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("oTITEL", OracleDbType.Varchar2).Value = oldTask.Titel;
                this.db.Command.Parameters.Add("oNOTE", OracleDbType.Varchar2).Value = oldTask.Notes;
                this.db.Command.Parameters.Add("oMAIL", OracleDbType.Varchar2).Value = oldTask.Accountemail;
                this.db.Command.Parameters.Add("nTITEL", OracleDbType.Varchar2).Value = newTask.Titel;
                this.db.Command.Parameters.Add("nNOTE", OracleDbType.Varchar2).Value = newTask.Notes;                
                int insertCompleted = 0;
                if (newTask.Completed == true)
                {
                    insertCompleted = 1;
                }
                else
                {
                    if (newTask.Completed == false)
                    {
                        insertCompleted = 0;
                    }
                }
                this.db.Command.Parameters.Add("nCOMPLETED", OracleDbType.Int32).Value = insertCompleted;
                this.db.Command.Parameters.Add("nMAIL", OracleDbType.Varchar2).Value = newTask.Accountemail;
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

        public Task GetTask(Task check)
        {
            Task task = null;
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM TASK WHERE TITEL = :TITEL AND NOTE = :NOTE AND EMAILADDRESS = :MAIL";
                this.db.Command.Parameters.Add(":TITEL", OracleDbType.Varchar2).Value = check.Titel;
                this.db.Command.Parameters.Add(":NOTE", OracleDbType.Varchar2).Value = check.Notes;
                this.db.Command.Parameters.Add(":MAIL", OracleDbType.Varchar2).Value = check.Accountemail;

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string titel = (String)reader["TITEL"];
                    string note = (String)reader["NOTE"];
                    int Rcompleted = Convert.ToInt32(reader["COMPLETED"]);
                    bool completed = false;
                    if (Rcompleted == 1)
                    {
                        completed = true;
                    }
                    else
                    {
                        if (Rcompleted == 0)
                        {
                            completed = false;
                        }
                    }
                    string email = (String)reader["EMAILADDRESS"];
                    task = new Task(titel, note, completed, email);
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
            return task;
        }

        public List<Task> GetAllTasks(Account account)
        {
            List<Task> todo = new List<Task>();
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM TASK WHERE EMAILADDRESS = :mail";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", account.EmailAdress));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string titel = (String)reader["TITEL"];
                    string note = (String)reader["NOTE"];
                    int Rcompleted = Convert.ToInt32(reader["COMPLETED"]);
                    bool completed = false;
                    if(Rcompleted == 1)
                    {
                        completed = true;
                    }
                    else{
                        if(Rcompleted == 0)
                        {
                            completed = false;
                        }
                    }
                    string email = (String)reader["EMAILADDRESS"];
                    todo.Add(new Task(titel,note,completed,email));
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
            return todo;
        }
    }
}
