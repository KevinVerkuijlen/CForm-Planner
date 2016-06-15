using System;
using CForm_Planner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.AgendaSystem;
using CForm_Planner.NoteSystem;

namespace CFormPlannerTest
{
    [TestClass]
    public class CalendarAdministrationTest
    {
        private Administration Administration { get; set; }
        private CalendarEventAdministration CalendarEventAdministration { get; set; }
        private DateTime TestTime = new DateTime(1, 1, 1, 1, 1, 1);

        [TestInitialize]
        public void Setup()
        {
            Administration = new Administration();
            CalendarEventAdministration = new CalendarEventAdministration();
        }

        [TestMethod]
        public void Test_AddCalenderEvent()
        {
            CalendarEvent testEvent = new CalendarEvent("testEvent", "t", TestTime, TestTime, "");
            CalendarEvent test2Event = testEvent;
            Assert.AreEqual(testEvent, test2Event);
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testEvent", "t", TestTime, TestTime, null, null, null, ""));
            Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(testEvent));

            try
            {
                CalendarEventAdministration.AddCalendarEvent("testEvent", "t", TestTime, TestTime, null, null, null, "");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment already exist in agenda");
            }

            CalendarEvent testDBEvent = new CalendarEvent("testDBEvent", "test", TestTime, TestTime, "Test@Unit.com");
            Assert.AreNotEqual(testEvent, testDBEvent);
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBEvent", "test", TestTime, TestTime, null, null, null, "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(testDBEvent));

            try
            {
                CalendarEventAdministration.AddCalendarEvent("testDBEvent", "tt", TestTime, TestTime,
                     null, null, null, "Test@Unit.com");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment already exist in agenda");
            }

            SchoolEvent testSchool = new SchoolEvent("testSchool", "t", TestTime, TestTime, "unit", "test", "");
            SchoolEvent test2School = testSchool;
            Assert.AreEqual(testSchool, test2School);
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testSchool", "t", TestTime, TestTime, "unit", "test", null, ""));
            Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(testSchool));

            try
            {
                CalendarEventAdministration.AddCalendarEvent("testSchool", "t", TestTime, TestTime, "unit",
                    "test", null, "");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment already exist in agenda");
            }

            SchoolEvent testDBSchool = new SchoolEvent("testDBSchool", "tt", TestTime, TestTime, "unit", "test", "Test@Unit.com");
            Assert.AreNotEqual(testSchool, testDBSchool);
            Assert.AreNotEqual(testEvent, testDBSchool);
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBSchool", "tt", TestTime, TestTime, "unit", "test", null, "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(testDBSchool));

            try
            {
                CalendarEventAdministration.AddCalendarEvent("testDBSchool", "tt", TestTime, TestTime, "unit",
                    "test", null, "Test@Unit.com");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment already exist in agenda");
            }

            GameEvent testGame = new GameEvent("testGame", "t", TestTime, TestTime, "Game", "");
            GameEvent test2Game = testGame;
            Assert.AreEqual(testGame, test2Game);
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testGame", "t", TestTime, TestTime, null, null, "Game", ""));
            Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(testGame));

            try
            {
                CalendarEventAdministration.AddCalendarEvent("testGame", "t", TestTime, TestTime, null, null, "Game", "");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment already exist in agenda");
            }

            GameEvent testDBGame = new GameEvent("testDBGame", "tt", TestTime, TestTime, "Game", "Test@Unit.com");
            Assert.AreNotEqual(testGame, testDBGame);
            Assert.AreNotEqual(testSchool, testGame);
            Assert.AreNotEqual(testEvent, testGame);
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBGame", "tt", TestTime, TestTime, null, null, "Game", "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(testDBGame));

            try
            {
                CalendarEventAdministration.AddCalendarEvent("testDBGame", "t", TestTime, TestTime, null, null, "Game", "Test@Unit.com");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment already exist in agenda");
            }

            CollectionAssert.AllItemsAreUnique(CalendarEventAdministration.Agenda);

        }

        [TestMethod]
        public void Test_UpdateCalenderEvent()
        {
            CalendarEventAdministration.Agenda.Clear();

            CalendarEvent testEvent = new CalendarEvent("testEvent", "t", TestTime, TestTime, "");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testEvent", "t", TestTime, TestTime, null, null, null, ""));

            Assert.IsTrue(CalendarEventAdministration.ChangeCalendarEvent(testEvent,"This is to test the update Event", "t t t t t ", TestTime, TestTime, null, null, null));

            try
            {
                CalendarEventAdministration.ChangeCalendarEvent(testEvent, "This is to test the update Event", "t t t t t ", TestTime, TestTime, null, null, null);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message,"The old appointment doesn't exist in the agenda");
            }

            CalendarEvent testDBEvent = new CalendarEvent("testDBUpdateEvent", "tt", TestTime, TestTime, "Test@Unit.com");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBUpdateEvent", "tt", TestTime, TestTime, null, null, null, "Test@Unit.com"));

            Assert.IsTrue(CalendarEventAdministration.ChangeCalendarEvent(testDBEvent, "This is to test the update database Event",
                "t t t ", TestTime, TestTime, null, null, null),"a");

            try
            {
                CalendarEventAdministration.ChangeCalendarEvent(testDBEvent, "This is to test the update database Event",
                               "t t t ", TestTime, TestTime, null, null, null);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old appointment doesn't exist in the agenda");
            }

            SchoolEvent testSchool = new SchoolEvent("testSchool", "t", TestTime, TestTime, "unit", "test", "");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testSchool", "t", TestTime, TestTime, "unit", "test", null, ""));

            Assert.IsTrue(CalendarEventAdministration.ChangeCalendarEvent(testSchool,"This is to test the update Event for school", "tt", TestTime, TestTime, "unit", "test", null));

            try
            {
                CalendarEventAdministration.ChangeCalendarEvent(testSchool, "This is to test the update Event for school", "tt", TestTime, TestTime, "unit", "test", null);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old appointment doesn't exist in the agenda");
            }
            
            SchoolEvent testDBSchool = new SchoolEvent("testDBUpdateSchool", "tt", TestTime, TestTime, "unit", "test", "Test@Unit.com");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBUpdateSchool", "tt", TestTime, TestTime, "unit", "test", null, "Test@Unit.com"));

            Assert.IsTrue(CalendarEventAdministration.ChangeCalendarEvent(testDBSchool, "This is to test the update database school Event",
                               "t t t ", TestTime, TestTime, "unit test", "unit test", null),"b");

            try
            {
                CalendarEventAdministration.ChangeCalendarEvent(testDBSchool, "This is to test the update database school Event",
                               "t t t ", TestTime, TestTime, "unit test", "unit test", null);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old appointment doesn't exist in the agenda");
            }

            GameEvent testGame = new GameEvent("testGame", "t", TestTime, TestTime, "Game", "");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testGame", "t", TestTime, TestTime, null, null, "Game", ""));

            Assert.IsTrue(CalendarEventAdministration.ChangeCalendarEvent(testGame, "This is to test the update Event for Game", "qwertyujnbvfrtyui", TestTime, TestTime, null, null, "Game"));

            try
            {
                CalendarEventAdministration.ChangeCalendarEvent(testGame, "This is to test the update Event for Game", "qwertyujnbvfrtyui", TestTime, TestTime, null, null, "Game");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old appointment doesn't exist in the agenda");
            }

            GameEvent testDBGame = new GameEvent("testDBUpdateGame", "tt", TestTime, TestTime, "Game", "Test@Unit.com");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBUpdateGame", "tt", TestTime, TestTime, null, null, "Game", "Test@Unit.com"));

            Assert.IsTrue(CalendarEventAdministration.ChangeCalendarEvent(testDBGame, "This is to test the update Event for Game in database", "test", TestTime, TestTime, null, null, "Game"),"c");

            try
            {
                CalendarEventAdministration.ChangeCalendarEvent(testDBGame, "This is to test the update Event for Game in database", "test", TestTime, TestTime, null, null, "Game");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old appointment doesn't exist in the agenda");
            }

            CollectionAssert.AllItemsAreUnique(CalendarEventAdministration.Agenda);

           
            
        }

        [TestMethod]
        public void Test_DeleteCalenderEvent()
        {
            CalendarEvent testEvent = new CalendarEvent("testEvent", "t", TestTime, TestTime, "");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testEvent", "t", TestTime, TestTime, null, null, null, ""));

            Assert.IsTrue(CalendarEventAdministration.RemoveCalendarEvent(testEvent));

            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(testEvent);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment doesn't exist in agenda");
            }

            CalendarEvent testDBEvent = new CalendarEvent("testDBDeleteEvent", "tt", TestTime, TestTime, "Test@Unit.com");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBDeleteEvent", "tt", TestTime, TestTime, null, null, null, "Test@Unit.com"));

            Assert.IsTrue(CalendarEventAdministration.RemoveCalendarEvent(testDBEvent));

            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(testDBEvent);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment doesn't exist in agenda");
            }

            SchoolEvent testSchool = new SchoolEvent("testSchool", "t", TestTime, TestTime, "unit", "test", "");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testSchool", "t", TestTime, TestTime, "unit", "test", null, ""));

            Assert.IsTrue(CalendarEventAdministration.RemoveCalendarEvent(testSchool));

            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(testSchool);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment doesn't exist in agenda");
            }

            SchoolEvent testDBSchool = new SchoolEvent("testDBDeleteSchool", "tt", TestTime, TestTime, "unit", "test", "Test@Unit.com");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBDeleteSchool", "tt", TestTime, TestTime, "unit", "test", null, "Test@Unit.com"));

            Assert.IsTrue(CalendarEventAdministration.RemoveCalendarEvent(testDBSchool));

            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(testDBSchool);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment doesn't exist in agenda");
            }

            GameEvent testGame = new GameEvent("testGame", "t", TestTime, TestTime, "Game", "");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testGame", "t", TestTime, TestTime, null, null, "Game", ""));

            Assert.IsTrue(CalendarEventAdministration.RemoveCalendarEvent(testGame));

            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(testGame);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment doesn't exist in agenda");
            }

            GameEvent testDBGame = new GameEvent("testDBDeleteGame", "tt", TestTime, TestTime, "Game", "Test@Unit.com");
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testDBDeleteGame", "tt", TestTime, TestTime, null, null, "Game", "Test@Unit.com"));

            Assert.IsTrue(CalendarEventAdministration.RemoveCalendarEvent(testDBGame));

            try
            {
                CalendarEventAdministration.RemoveCalendarEvent(testDBGame);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Appiontment doesn't exist in agenda");
            }
        }

        [TestMethod]
        public void Test_RepeatCalenderEvent()
        {
            int repeat = 10;
            
            CalendarEventAdministration.RepeatCalendarEventEachDay("testEvent", "t", TestTime, TestTime, "","","","", repeat);

            for (int i = 1; i < repeat + 1; i++)
            {
                Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(new CalendarEvent("testEvent", "t", TestTime.AddDays(i), TestTime.AddDays(i), "")));
            }

            CalendarEventAdministration.RepeatCalendarEventEachWorkDay("testSchool", "t", TestTime, TestTime, "unit test", "unit test","", "",repeat);

            for (int i = 1; i < repeat; i++)
            {
                DayOfWeek check = TestTime.AddDays(i).DayOfWeek;
                if (check != DayOfWeek.Saturday)
                {
                    if (check != DayOfWeek.Sunday)
                    {
                        Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(new SchoolEvent("testEvent", "t", TestTime.AddDays(i), TestTime.AddDays(i), "unit test", "unit test", "")));
                    }
                }
            }
            
            CalendarEventAdministration.RepeatCalendarEventEachDayInWeek("testGame", "t", TestTime, TestTime,"","","unit test", "", repeat);
            for (int i = 1; i < repeat; i++)
            {
                Assert.IsTrue(CalendarEventAdministration.Agenda.Contains(new GameEvent("testGame", "t", TestTime.AddDays(i * 7), TestTime.AddDays(i * 7), "unit test", "")));
            }
        }

        [TestMethod]
        public void Test_CleanCalenderEvent()
        {
            CalendarEventAdministration.Agenda.Clear();
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testEvent", "t", TestTime, TestTime, null, null, null, ""));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testcleanEvent", "t", TestTime, TestTime, null, null, null, "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testSchool", "t", TestTime, TestTime, "unit test", "unit test", null, ""));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testcleanSchool", "t", TestTime, TestTime, "unit test", "unit test", null, "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testGame", "t", TestTime, TestTime, null, null, "unit test", ""));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testcleanGame", "t", TestTime, TestTime, null, null, "unit test", "Test@Unit.com"));

            CalendarEventAdministration.CleanCalendar(new Account("Tester", "Unit", "Test@Unit.com"));

            foreach (CalendarEvent calendarEvent in CalendarEventAdministration.Agenda)
            {
                Assert.IsTrue(calendarEvent.AccountEmail != "");
            }
            Assert.AreEqual(CalendarEventAdministration.Agenda.Count, 3);
        }

        [TestMethod]
        public void Test_EmptyCalenderEventToUser()
        {
            CalendarEventAdministration.Agenda.Clear();
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testEvent", "t", TestTime, TestTime, null, null, null, ""));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testemptyEvent", "t", TestTime, TestTime, null, null, null, "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testSchool", "t", TestTime, TestTime, "unit test", "unit test", null, ""));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testemptySchool", "t", TestTime, TestTime, "unit test", "unit test", null, "Test@Unit.com"));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testGame", "t", TestTime, TestTime, null, null, "unit test", ""));
            Assert.IsTrue(CalendarEventAdministration.AddCalendarEvent("testemptyGame", "t", TestTime, TestTime, null, null, "unit test", "Test@Unit.com"));

            CalendarEventAdministration.EmptyCalendarToUser(new Account("Tester", "Unit", "Test@Unit.com"));
            foreach (CalendarEvent calendarEvent in CalendarEventAdministration.Agenda)
            {
                Assert.IsTrue(calendarEvent.AccountEmail != "");
            }
            Assert.AreEqual(CalendarEventAdministration.Agenda.Count, 6);
        }
    }
}

