using System;
using CForm_Planner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.AlarmSystem;
using Oracle.ManagedDataAccess.Client;

namespace CFormPlannerTest
{
    [TestClass]
    public class AlarmAdministrationTest
    {
        private AlarmAdministration AlarmAdministration { get; set; }
        private Alarm test = new Alarm(new DateTime(1, 1, 1, 1, 1, 1), false, "");

        [TestInitialize]
        public void Setup()
        {
            AlarmAdministration = new AlarmAdministration();
        }

        [TestMethod]
        public void Test_AddAlarm()
        {
            //Add local
            Alarm testAlarm = test;
            Alarm test2Alarm = testAlarm;
            Assert.AreEqual(testAlarm, test2Alarm);
            Assert.IsTrue(AlarmAdministration.AddAlarm(testAlarm.Alarmtime, testAlarm.AlarmSet, testAlarm.AccountEmail));

            //test for a dubbel
            try
            {
                AlarmAdministration.AddAlarm(testAlarm.Alarmtime, testAlarm.AlarmSet, testAlarm.AccountEmail);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Alarm already exist in the alarm list");
            }

            //add local and database
            Alarm test3Alarm = new Alarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com");
            Assert.AreNotEqual(testAlarm, test3Alarm);
            Assert.IsTrue(AlarmAdministration.AddAlarm(test3Alarm.Alarmtime, test3Alarm.AlarmSet, test3Alarm.AccountEmail));
            try
            {
                AlarmAdministration.AddAlarm(test3Alarm.Alarmtime, test3Alarm.AlarmSet, test3Alarm.AccountEmail);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Alarm already exist in the alarm list");
            }
            Assert.IsTrue(AlarmAdministration.RemoveAlarm(new Alarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com")));

            CollectionAssert.AllItemsAreUnique(AlarmAdministration.Alarm_list);
        }

        [TestMethod]
        public void Test_UpdateAlarm()
        {
            AlarmAdministration.Alarm_list.Clear();

            AlarmAdministration.AddAlarm(test.Alarmtime, test.AlarmSet, test.AccountEmail);
            DateTime updatet = test.Alarmtime.AddHours(2);
            Assert.IsTrue(AlarmAdministration.ChangeAlarm(test, updatet, true));
            Assert.AreEqual(test.Alarmtime, updatet);
            Assert.AreEqual(test.AlarmSet, true);

            try
            {
                AlarmAdministration.ChangeAlarm(test, test.Alarmtime, test.AlarmSet);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old alarm doesn't exist in the alarm list");              
            }

            DateTime testDbTime = test.Alarmtime.AddHours(5);
            Alarm TestDBAlarm = new Alarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com");
            AlarmAdministration.AddAlarm(TestDBAlarm.Alarmtime, TestDBAlarm.AlarmSet, TestDBAlarm.AccountEmail);
            Assert.IsTrue(AlarmAdministration.ChangeAlarm(TestDBAlarm, testDbTime, true));
            Assert.AreEqual(TestDBAlarm.Alarmtime, testDbTime);
            Assert.AreEqual(TestDBAlarm.AlarmSet, true);

            try
            {
                AlarmAdministration.ChangeAlarm(new Alarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com"), test.Alarmtime, test.AlarmSet);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old alarm doesn't exist in the alarm list");
            }
        }

        [TestMethod]
        public void Test_DeleteAlarm()
        {
            AlarmAdministration.Alarm_list.Clear();
            AlarmAdministration.AddAlarm(test.Alarmtime, test.AlarmSet, test.AccountEmail);
            Assert.IsTrue(AlarmAdministration.RemoveAlarm(test));
            
            try
            {
                AlarmAdministration.RemoveAlarm(test);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Alarm doesn't exist in the alarm list");
            }

            //Database test 
            AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com");
            Assert.IsTrue(AlarmAdministration.RemoveAlarm(new Alarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com")));
            Assert.IsTrue(AlarmAdministration.GetAlarm(new Alarm(test.Alarmtime.AddHours(1), false, "Test@Unit.com")));
            
        }

        [TestMethod]
        public void Test_CleanAlarms()
        {
            AlarmAdministration.Alarm_list.Clear();
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime, false, "Test@Unit.com"));
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(1), false, ""));
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(2), false, ""));
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(3), false, "Test@Unit.com"));

            AlarmAdministration.CleanAlarms(new Account("Tester", "Unit", "Test@Unit.com"));

            foreach (Alarm alarm in AlarmAdministration.Alarm_list)
            {
                Assert.IsTrue(alarm.AccountEmail != "");
            }
            Assert.AreEqual(AlarmAdministration.Alarm_list.Count, 2);
        }

        [TestMethod]
        public void Test_EmptyAlarmsToUser()
        {
            AlarmAdministration.Alarm_list.Clear();
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddMinutes(10), false, "Test@Unit.com"));
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(1), false, ""));
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(2), false, ""));
            Assert.IsTrue(AlarmAdministration.AddAlarm(test.Alarmtime.AddHours(3).AddMinutes(10), false, "Test@Unit.com"));

            AlarmAdministration.EmptyAlarmsToUser(new Account("Tester", "Unit", "Test@Unit.com"));
            foreach (Alarm alarm in AlarmAdministration.Alarm_list)
            {
                Assert.IsTrue(alarm.AccountEmail != "");
            }
            Assert.AreEqual(AlarmAdministration.Alarm_list.Count, 4);
        }


    }
}
