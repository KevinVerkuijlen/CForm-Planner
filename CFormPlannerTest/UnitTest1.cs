using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;
using CForm_Planner.AlarmSystem;
using CForm_Planner.NoteSystem;
using CForm_Planner.TaskSystem;

namespace CFormPlannerTest
{
    [TestClass]
    public class UnitTest1
    {
        Administration administration= new Administration();
        CalendarEventAdministration calendarEventAdministration = new CalendarEventAdministration();
        AlarmAdministration alarmAdministration = new AlarmAdministration();
        NoteAdministration noteAdministartion = new NoteAdministration();
        TaskAdministration taskAdministration = new TaskAdministration();

        [TestMethod]
        public void Account_Test()
        {

        }

        [TestMethod]
        public void Calendar_Test()
        {
            CalendarEvent testEvent = new CalendarEvent("testEvent","t",DateTime.Now, DateTime.Now,"");
            CalendarEvent test2Event = testEvent;
            Assert.AreEqual(testEvent, test2Event);
            Assert.IsTrue(calendarEventAdministration.AddCalendarEvent("testEvent", "t", DateTime.Now, DateTime.Now, "", "", "", ""));

            CalendarEvent test3Event = new CalendarEvent("test2Event", "tt", DateTime.Now, DateTime.Now, "");
            Assert.AreNotEqual(testEvent, test3Event);
            Assert.IsTrue(calendarEventAdministration.AddCalendarEvent("test2Event", "tt", DateTime.Now, DateTime.Now, "", "", "", ""));

            SchoolEvent testSchool = new SchoolEvent("testSchool", "t", DateTime.Now, DateTime.Now, "unit","test", "");
            SchoolEvent test2School = testSchool;
            Assert.AreEqual(testEvent, test2Event);
            Assert.IsTrue(calendarEventAdministration.AddCalendarEvent("testSchool", "t", DateTime.Now, DateTime.Now, "unit", "test", "", ""));

            SchoolEvent test3School = new SchoolEvent("test2School", "tt", DateTime.Now, DateTime.Now, "unit", "test", "");
            Assert.AreNotEqual(testSchool, test3School);
            Assert.AreNotEqual(testEvent, testSchool);
            Assert.IsTrue(calendarEventAdministration.AddCalendarEvent("test2School", "tt", DateTime.Now, DateTime.Now, "unit", "test","", ""));

            GameEvent testGame = new GameEvent("testGame", "t", DateTime.Now, DateTime.Now, "Game","");
            GameEvent test2Game = testGame;
            Assert.AreEqual(testEvent, test2Event);
            Assert.IsTrue(calendarEventAdministration.AddCalendarEvent("testGame", "t", DateTime.Now, DateTime.Now,"", "", "Game",""));

            GameEvent test3Game = new GameEvent("test2Game", "tt", DateTime.Now, DateTime.Now, "Game", "");
            Assert.AreNotEqual(testGame, test3Game);
            Assert.AreNotEqual(testSchool, testGame);
            Assert.AreNotEqual(testEvent, testGame);
            Assert.IsTrue(calendarEventAdministration.AddCalendarEvent("test2Game", "t", DateTime.Now, DateTime.Now, "", "", "Game", ""));

            CollectionAssert.AllItemsAreUnique(calendarEventAdministration.Agenda);

            /*   calendarEventAdministration.ChangeCalendarEvent(testEvent,"This is to test the update Event", "t t t t t ", DateTime.Now, DateTime.Now, "", "", "", "");
               calendarEventAdministration.ChangeCalendarEvent(test3School,"This is to test the update Event for school", "tt", DateTime.Now, DateTime.Now, "unit", "test","", "");
               calendarEventAdministration.ChangeCalendarEvent(testGame, "This is to test the update Event for Game", "qwertyujnbvfrtyui", DateTime.Now, DateTime.Now, "", "", "Game", "");

               CollectionAssert.AllItemsAreUnique(calendarEventAdministration.Agenda);
           
            calendarEventAdministration.RemoveCalendarEvent(new CalendarEvent("test2Event", "tt", DateTime.Now, DateTime.Now, ""));
            calendarEventAdministration.RemoveCalendarEvent(testSchool);
            calendarEventAdministration.RemoveCalendarEvent(test3Game);   
              */
        }

        [TestMethod]
        public void Alarm_Test()
        {
            Alarm testAlarm = new Alarm(DateTime.Now, false, "");
            Alarm test2Alarm = testAlarm;
            Assert.AreEqual(testAlarm, test2Alarm);
            Assert.IsTrue(alarmAdministration.AddAlarm(testAlarm.Alarmtime, testAlarm.AlarmSet, testAlarm.AccountEmail));

            Alarm test3Alarm = new Alarm(DateTime.Now.AddHours(1), false, "");
            Assert.AreNotEqual(testAlarm, test3Alarm);
            Assert.IsTrue(alarmAdministration.AddAlarm(test3Alarm.Alarmtime, test3Alarm.AlarmSet, test3Alarm.AccountEmail));

            CollectionAssert.AllItemsAreUnique(alarmAdministration.Alarm_list);
        }

        [TestMethod]
        public void Note_Test()
        {

        }

        [TestMethod]
        public void Task_Test()
        {

        }
    }
}
