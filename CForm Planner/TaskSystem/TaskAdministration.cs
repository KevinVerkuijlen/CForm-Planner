using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using CForm_Planner.AccountSystem;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.TaskSystem
{
    public class TaskAdministration
    {
        public List<Task> Todo = new List<Task>();

        public bool AddTask(string titel, string notes, bool completed, string email)
        {
            Task task = new Task(titel, notes, completed, email);
            if (Todo.Contains(task) == false)
            {
                if (task.Accountemail != "")
                {
                    try
                    {
                        if (GetTask(task))
                        {
                            Todo.Add(task);
                            InsertTask(titel, notes, completed, email);
                            return true;
                        }
                        else
                        {
                            throw new PlannerExceptions("Task already exist in the database ToDo list");
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    Todo.Add(task);
                    return true;
                }
            }
            else
            {
                throw new PlannerExceptions("Task already exist in the ToDo list");
            }
        }

        public bool RemoveTask(Task task)
        {
            if (Todo.Contains(task))
            {
                Todo.Remove(task);
                if (task.Accountemail != "")
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
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Task doesn't exist in the ToDo list");
            }
        }

        public bool ChangeTask(Task oldTask, string titel, string notes, bool completed)
        {
            if (Todo.Contains(oldTask))
            {
                if (Todo.Contains(new Task(titel, notes, completed, oldTask.Accountemail)) == false)
                {
                    if (oldTask.Accountemail != "")
                    {
                        try
                        {
                            UpdateTask(oldTask.Titel, oldTask.Notes, oldTask.Accountemail, titel, notes, completed,
                                oldTask.Accountemail);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    oldTask.Update(titel, notes, completed, oldTask.Accountemail);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions(
                        "Thenew Task already exist in the ToDo list");
                }
            }
            else
            {
                throw new PlannerExceptions(
                    "The old Task doesn't exist in the ToDo list");
            }
        }

        public void InsertTask(string titel, string notes, bool completed, string email)
        {
            OracleParameter[] insertParameter =
            {
                new OracleParameter("iTITEL", titel),
                new OracleParameter("iNOTE", notes),
                new OracleParameter("iCOMPLETED", Convert.ToInt32(completed)),
                new OracleParameter("iMAIL", email)
            };
            DatabaseManager.ExecuteInsertQuery("InsertTask", insertParameter);
        }

        public void UpdateTask(string oldTitel, string oldNotes, string oldEmail, string newTitel, string newNotes,
            bool completed, string newEmail)
        {
            OracleParameter[] updateParameter =
            {
                new OracleParameter("oTITEL", oldTitel),
                new OracleParameter("oNOTE", oldNotes),
                new OracleParameter("oMAIL", oldEmail),
                new OracleParameter("nTITEL", newTitel),
                new OracleParameter("nNOTE", newNotes),
                new OracleParameter("nCOMPLETED", Convert.ToInt32(completed))
            };
            DatabaseManager.ExecuteInsertQuery("UpdateTask", updateParameter);
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


        public void MergeTask(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<Task> loaded = new List<Task>();
                    OracleParameter[] checkParameter =
                    {
                        new OracleParameter("mail", user.EmailAdress)
                    };
                    DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllTasks"],
                        checkParameter);
                    foreach (DataRow reader in dt.Rows)
                    {
                        string titel = (String) reader["TITEL"];
                        string note = (String) reader["NOTE"];
                        bool completed = Convert.ToBoolean(reader["COMPLETED"]);
                        string email = (String) reader["EMAILADDRESS"];
                        loaded.Add(new Task(titel, note, completed, email));
                    }
                    this.Todo = Todo.Union(loaded).Distinct().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UploadTasks(Account user)
        {
            if (user != null)
            {
                foreach (Task t in Todo)
                {
                    if (t.Accountemail != "")
                    {
                        try
                        {
                            OracleParameter[] checkParameter =
                            {
                                new OracleParameter("TITEL", t.Titel),
                                new OracleParameter("NOTE", t.Notes),
                                new OracleParameter("EMAILADDRESS", t.Accountemail)
                            };
                            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTask"],
                                checkParameter);
                            foreach (DataRow reader in dt.Rows)
                            {
                                if (reader["TITEL"] == DBNull.Value && reader["NOTE"] == DBNull.Value &&
                                    reader["COMPLETED"] == DBNull.Value && reader["EMAILADDRESS"] == DBNull.Value)
                                {
                                    InsertTask(t.Titel, t.Notes, t.Completed, t.Accountemail);
                                }
                                else
                                {
                                    UpdateTask((string) reader["TITEL"], (string) reader["NOTE"],
                                        (string) reader["EMAILADDRESS"], t.Titel, t.Notes, t.Completed, t.Accountemail);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public void CleanTasks(Account user)
        {
            foreach (Task task in Todo.ToList())
            {
                if (task.Accountemail == "" || task.Accountemail != user.EmailAdress)
                {
                    RemoveTask(task);
                }
            }
        }

        public void EmptyTasksToUser(Account user)
        {
            foreach (Task task in Todo.ToList())
            {
                if (task.Accountemail == "")
                {
                    task.Update(task.Titel, task.Notes, task.Completed, user.EmailAdress);
                    InsertTask(task.Titel, task.Notes, task.Completed, user.EmailAdress);
                }
            }
        }
    }
}
