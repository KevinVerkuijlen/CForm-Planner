using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using CForm_Planner.AccountSystem;
using CForm_Planner.TaskSystem.TaskForms;

namespace CForm_Planner.TaskSystem
{
    public class TaskAdministration
    {
        public List<Task> Todo = new List<Task>();
        private TaskDatabase TaskDatabase { get; set; }

        public TaskAdministration()
        {
            TaskDatabase = new TaskDatabase();   
        }

        public bool AddTask(string titel, string notes, int hourDuration, int minDuration, bool completed, string email)
        {
            Task task = new Task(titel, notes, hourDuration, minDuration, completed, email);
            if (Todo.Contains(task) == false)
            {
                if (task.Accountemail != "")
                {
                    try
                    {
                        if (TaskDatabase.GetTask(task))
                        {
                            Todo.Add(task);
                            TaskDatabase.InsertTask(titel, notes, hourDuration, minDuration, completed, email);
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
                    TaskDatabase.DeleteTask(task);
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Task doesn't exist in the ToDo list");
            }
        }

        public bool ChangeTask(Task oldTask, string titel, string notes, int hourDuration, int minDuration, bool completed)
        {
            if (Todo.Contains(oldTask))
            {
                if (Todo.Contains(new Task(titel, notes, hourDuration, minDuration,  completed, oldTask.Accountemail)) == false)
                {
                    if (oldTask.Accountemail != "")
                    {
                        try
                        {
                            TaskDatabase.UpdateTask(oldTask.Titel, oldTask.Notes, oldTask.Accountemail, titel, notes, hourDuration, minDuration, completed);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    oldTask.Update(titel, notes, hourDuration, minDuration, completed, oldTask.Accountemail);
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


        public void MergeTask(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<Task> loaded = TaskDatabase.GetTasks(user.EmailAdress);
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
                            if (TaskDatabase.GetTask(t) == false)
                            {
                                TaskDatabase.InsertTask(t.Titel, t.Notes, t.HourDuration, t.MinDuration, t.Completed, t.Accountemail);
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
                    task.Update(task.Titel, task.Notes, task.HourDuration, task.MinDuration, task.Completed, user.EmailAdress);
                    TaskDatabase.InsertTask(task.Titel, task.Notes, task.HourDuration, task.MinDuration, task.Completed, user.EmailAdress);
                }
            }
        }
    }
}
