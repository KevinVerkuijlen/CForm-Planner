using System;
using CForm_Planner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.TaskSystem;

namespace CFormPlannerTest
{
    [TestClass]
    public class TaskAdministrationTest
    {
        private Administration Administration { get; set; }
        private TaskAdministration TaskAdministration { get; set; }
        private Task test = new Task("ToDo test", "testing", false, "");


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
            Assert.IsTrue(TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.Completed, testTask.Accountemail));

            //test for a dubbel
            try
            {
                TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.Completed, testTask.Accountemail);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Task already exist in the ToDo list");
            }

            //add local and database
            Task test3Task = new Task(test.Titel + "testing", test.Notes+"Testing", false,  "Test@Unit.com");
            Assert.AreNotEqual(testTask, test3Task);
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "testing", test.Notes + "Testing", false, "Test@Unit.com"));

            try
            {
                TaskAdministration.AddTask(test.Titel + "testing", test.Notes + "Testing", false, "Test@Unit.com");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Task already exist in the ToDo list");
            }
            Assert.IsTrue(TaskAdministration.RemoveTask(new Task(test.Titel + "testing", test.Notes + "Testing", false, "Test@Unit.com")));

            CollectionAssert.AllItemsAreUnique(TaskAdministration.Todo);

        }

        [TestMethod]
        public void Test_UpdateTask()
        {
            TaskAdministration.Todo.Clear();

            Task testTask = test;
            Assert.IsTrue(TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.Completed, testTask.Accountemail));

            try
            {
                TaskAdministration.ChangeTask(test, "this is a test", "testing", true);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old Task doesn't exist in the ToDo list");
            }

            Task TestDBTask = new Task(test.Titel + "testing", test.Notes + "Testing", false, "Test@Unit.com");
            Assert.IsTrue(TaskAdministration.AddTask(TestDBTask.Titel , TestDBTask.Notes, false, "Test@Unit.com"));

            Assert.IsTrue(TaskAdministration.ChangeTask(TestDBTask, "test 123", "456", true));
            Assert.AreEqual(TestDBTask.Titel, "test 123");

            try
            {
                TaskAdministration.ChangeTask(TestDBTask, TestDBTask.Titel, TestDBTask.Notes, TestDBTask.Completed);
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
            Assert.IsTrue(TaskAdministration.AddTask(testTask.Titel, testTask.Notes, testTask.Completed, testTask.Accountemail));
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
            Task TestDBTask = new Task(test.Titel + "db testing", test.Notes + "db Testing", false, "Test@Unit.com");
            Assert.IsTrue(TaskAdministration.AddTask(TestDBTask.Titel, TestDBTask.Notes, false, "Test@Unit.com"));

            Assert.IsTrue(TaskAdministration.RemoveTask(TestDBTask));
            Assert.IsTrue(TaskAdministration.GetTask(TestDBTask));


        }

        [TestMethod]
        public void Test_CleanTasks()
        {
            TaskAdministration.Todo.Clear();
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel, test.Notes, test.Completed, "Test@Unit.com"));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "a", "notes", true, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "b", "something", false, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "c", "something something",false, "Test@Unit.com"));

            TaskAdministration.CleanTasks(new Account("Tester", "Unit", "Test@Unit.com"));

            foreach (Task Task in TaskAdministration.Todo)
            {
                Assert.IsTrue(Task.Accountemail != "");
            }
            Assert.AreEqual(TaskAdministration.Todo.Count, 2);


        }

        [TestMethod]
        public void Test_EmptyTaskToUser()
        {
            TaskAdministration.Todo.Clear();
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel+"empty", test.Notes, test.Completed, "Test@Unit.com"));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "a", "notes", true, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "b", "something", false, ""));
            Assert.IsTrue(TaskAdministration.AddTask(test.Titel + "D", "something something", false, "Test@Unit.com"));

            TaskAdministration.EmptyTasksToUser(new Account("Tester", "Unit", "Test@Unit.com"));
            foreach (Task Task in TaskAdministration.Todo)
            {
                Assert.IsTrue(Task.Accountemail != "");
            }
            Assert.AreEqual(TaskAdministration.Todo.Count, 4);

        }
    }
}
