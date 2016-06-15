using System;
using CForm_Planner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.TaskSystem;
using CForm_Planner.TaskSystem.TaskForms;

namespace CFormPlannerTest
{
    [TestClass]
    public class TaskAdministrationTest
    {
        private Administration Administration { get; set; }
        private TaskAdministration TaskAdministration { get; set; }
        private Task test = new Task("ToDo test", "testing", 1, 1, false, "");


        [TestInitialize]
        public void Setup()
        {
            Administration = new Administration();
            TaskAdministration = new TaskAdministration();
        }

        [TestMethod]
        public void Test_AddTask()
        {
            //Add local
            Task testTask = test;
            Task test2Task = testTask;
            Assert.AreEqual(testTask, test2Task);
            Assert.IsTrue(TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.HourDuration, testTask.MinDuration, testTask.Completed, testTask.AccountEmail));

            //test for a dubbel
            try
            {
                TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.HourDuration, testTask.MinDuration, testTask.Completed, testTask.AccountEmail);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Task already exist in the ToDo list");
            }

            //add local and database
            Task test3Task = new Task(test.Titel + "testing", test.Notes+"Testing", testTask.HourDuration+1, testTask.MinDuration+1, false,  "Test@Unit.com");
            Assert.AreNotEqual(testTask, test3Task);
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "testing", test.Notes + "Testing", testTask.HourDuration + 1, testTask.MinDuration + 1, false, "Test@Unit.com"));

            try
            {
                TaskAdministration.AddTask(test.Titel + "testing", test.Notes + "Testing", testTask.HourDuration + 1, testTask.MinDuration + 1, false, "Test@Unit.com");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Task already exist in the ToDo list");
            }
            Assert.IsTrue(TaskAdministration.RemoveTask(new Task(test.Titel + "testing", test.Notes + "Testing", testTask.HourDuration + 1, testTask.MinDuration + 1, false, "Test@Unit.com")));

            CollectionAssert.AllItemsAreUnique(TaskAdministration.Todo);

        }

        [TestMethod]
        public void Test_UpdateTask()
        {
            TaskAdministration.Todo.Clear();

            Task testTask = test;
            Assert.IsTrue(TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.HourDuration, testTask.MinDuration, testTask.Completed, testTask.AccountEmail));

            try
            {
                TaskAdministration.ChangeTask(test, "this is a test", "testing", 6, 6, true);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old Task doesn't exist in the ToDo list");
            }

            Task TestDBTask = new Task(test.Titel + "testing", test.Notes + "Testing", 4, 4, false, "Test@Unit.com");
            Assert.IsTrue(TaskAdministration.AddTask(TestDBTask.Titel , TestDBTask.Notes, 4, 4, false, "Test@Unit.com"));

            Assert.IsTrue(TaskAdministration.ChangeTask(TestDBTask, "test 123", "456", 9,9, true));
            Assert.AreEqual(TestDBTask.Titel, "test 123");

            try
            {
                TaskAdministration.ChangeTask(TestDBTask, TestDBTask.Titel, TestDBTask.Notes, TestDBTask.HourDuration, TestDBTask.MinDuration, TestDBTask.Completed);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old Task doesn't exist in the ToDo list");

            }

        }

        [TestMethod]
        public void Test_DeleteTask()
        {
            TaskAdministration.Todo.Clear();
            Task testTask = test;
            Assert.IsTrue(TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.HourDuration, testTask.MinDuration, testTask.Completed, testTask.AccountEmail));
            Assert.IsTrue(TaskAdministration.RemoveTask(testTask));

            try
            {
                TaskAdministration.RemoveTask(test);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Task doesn't exist in the ToDo list");
            }

            //Database test 
            Task TestDBTask = new Task(test.Titel + "db testing", test.Notes + "db Testing", 7, 7, false, "Test@Unit.com");
            Assert.IsTrue(TaskAdministration.AddTask(TestDBTask.Titel, TestDBTask.Notes, 7, 7, false, "Test@Unit.com"));

            Assert.IsTrue(TaskAdministration.RemoveTask(TestDBTask));
            TaskDatabase taskDatabase = new TaskDatabase();
            Assert.IsNotNull(taskDatabase.GetTask(TestDBTask));


        }

        [TestMethod]
        public void Test_CleanTasks()
        {
            TaskAdministration.Todo.Clear();
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel, test.Notes, 21, 21, test.Completed, "Test@Unit.com"));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "a", "notes", 22, 22, true, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "b", "something", 23, 23, false, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "c", "something something", 24, 24, false, "Test@Unit.com"));

            TaskAdministration.CleanTasks(new Account("Tester", "Unit", "Test@Unit.com"));

            foreach (Task Task in TaskAdministration.Todo)
            {
                Assert.IsTrue(Task.AccountEmail != "");
            }
            Assert.AreEqual(TaskAdministration.Todo.Count, 2);


        }

        [TestMethod]
        public void Test_EmptyTaskToUser()
        {
            TaskAdministration.Todo.Clear();
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel+"empty", test.Notes, 31, 31, test.Completed, "Test@Unit.com"));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "a", "notes", 32, 32, true, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "b", "something", 33, 33, false, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "D", "something something", 34, 34, false, "Test@Unit.com"));

            TaskAdministration.EmptyTasksToUser(new Account("Tester", "Unit", "Test@Unit.com"));
            foreach (Task Task in TaskAdministration.Todo)
            {
                Assert.IsTrue(Task.AccountEmail != "");
            }
            Assert.AreEqual(TaskAdministration.Todo.Count, 4);

        }
    }
}
