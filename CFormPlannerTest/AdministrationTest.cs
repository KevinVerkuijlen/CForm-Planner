using System;
using System.Data;
using CForm_Planner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;
using CForm_Planner.AlarmSystem;
using CForm_Planner.NoteSystem;
using CForm_Planner.TaskSystem;
using Oracle.ManagedDataAccess.Client;

namespace CFormPlannerTest
{
    [TestClass]
    public class AdministrationTest
    {
        private Administration Administration { get; set; }

        [TestInitialize]
        public void Setup()
        { 
            Administration = new Administration();
        }

        [TestMethod]
        public void Test_Register()
        {
            Assert.IsTrue(Administration.Register("Tester", "Unit", "Test@Unit.com", "T"));

            try
            {
                Administration.Register("Tester 2", "Unit", "Test@Unit.com", "Test");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "This email adress is already being used by an account");
            }
        }

        [TestMethod]
        public void Test_Login()
        {
            Administration.LoginAccount("Test@Unit.com", "T");
            Assert.IsNotNull(Administration.User);

            try
            {
                Administration.LoginAccount("Test@Unit.com", "Testing");
            }
            catch (Exception exception)
            {                
                Assert.IsTrue(exception is PlannerExceptions);
            }
        }

        [TestMethod]
        public void Test_LogOut()
        {
            Administration.LoginAccount("Test@Unit.com", "T");
            Assert.IsNotNull(Administration.User);

            Administration.LogoutAccount();
            Assert.IsNull(Administration.User);

            try
            {
                Administration.LogoutAccount();
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "User is not logged in");
            }

        }

        

        [TestMethod]
        public void Test_AccountUpdate()
        {
            Administration.LoginAccount("Test@Unit.com", "T");
            Assert.IsNotNull(Administration.User);
            Assert.IsTrue(Administration.UpdateAccount("Unit","test","T"));

            Assert.AreEqual(Administration.User.Name, "Unit");
            Assert.AreEqual(Administration.User.LastName, "test");

            Administration.LogoutAccount();
            try
            {
                Administration.UpdateAccount("Tester", "Unit", "T");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "User is not logged in");
            }
        }

        [TestMethod]
        public void Cleanup()
        {
            DatabaseManager.ExecuteDeleteQuery("DeleteTester", null);
        }

    }
}
