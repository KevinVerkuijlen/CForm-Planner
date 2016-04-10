using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.TaskSystem
{
    public class TaskAdministration
    {
        private TaskDatabase taskDatabase = new TaskDatabase();
        public List<Task> Todo = new List<Task>();

        public void AddTask(Task task)
        {
            int check = CheckForTask(task);
            if (check == -1)
            {
                Todo.Add(task);
                if (task.Accountemail != "")
                {
                    taskDatabase.InsertTask(task);
                }
            }
            else
            {
                throw new PlannerExceptions("Task already exist in the ToDo list");
            }
        }

        public void RemoveTask(Task task)
        {
            int check = CheckForTask(task);
            if (check >= 0)
            {
                Todo.Remove(task);
                if (task.Accountemail != "")
                {
                    taskDatabase.DeleteTask(task);
                }
            }
            else
            {
                throw new PlannerExceptions("Task doesn't exist in the ToDo list");
            }
        }

        public void ChangeTask(Task oldTask, Task newTask)
        {
            int oldCheck = CheckForTask(oldTask);
            int newCheck = CheckForTask(newTask);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Todo.RemoveAt(oldCheck);
                Todo.Insert(oldCheck, newTask);
                if (oldTask.Accountemail != "" && newTask.Accountemail != "")
                {
                    taskDatabase.UpdateTask(oldTask, newTask);
                }
            }
            else
            {
                throw new PlannerExceptions("The old Task doesn't exist in the ToDo list or the new Task already exist in the ToDo list");
            }
        }

        public void TaskToCalendar()
        {

        }

        public int CheckForTask(Task task)
        {
            int check = -1;
            foreach (Task t in Todo)
            {

                if (t.Titel == task.Titel && t.Notes == task.Notes && t.Completed == task.Completed)
                {
                    check = Todo.IndexOf(t);
                }
                else
                {
                    if (t.Titel == task.Titel && t.Notes == task.Notes && t.Completed != task.Completed)
                    {
                        return check;
                    }
                }
            }
            return check;
        }
    }
}
