using System;
using CForm_Planner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CForm_Planner.AccountSystem;
using CForm_Planner.NoteSystem;

namespace CFormPlannerTest
{
    [TestClass]
    public class NoteAdministrationTest
    {
        private NoteAdministration NoteAdministration { get; set; }
        Note test = new Note("testing", "Test@Unit.com");

        [TestInitialize]
        public void Setup()
        {
            NoteAdministration = new NoteAdministration();
        }

        [TestMethod]
        public void Test_AddNote()
        {
            //Add local
            Note testNote = test;
            Note test2Note = testNote;
            Assert.AreEqual(testNote, test2Note);
            Assert.IsTrue(NoteAdministration.AddNote(testNote.Information, testNote.Accountemail));

            //test for a dubbel
            try
            {
                NoteAdministration.AddNote(testNote.Information, testNote.Accountemail);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Note already exist in the note list");
            }

            //add local and database
            Note test3Note = new Note(test.Information + "testing", "Test@Unit.com");
            Assert.AreNotEqual(testNote, test3Note);
            Assert.IsTrue(NoteAdministration.AddNote(test3Note.Information, test3Note.Accountemail));

            try
            {
                NoteAdministration.AddNote(test3Note.Information, test3Note.Accountemail);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Note already exist in the note list");
            }
            Assert.IsTrue(NoteAdministration.RemoveNote(new Note(test.Information, "Test@Unit.com")));

            CollectionAssert.AllItemsAreUnique(NoteAdministration.Notes);

        }

        [TestMethod]
        public void Test_UpdateNote()
        {
            NoteAdministration.Notes.Clear();

            NoteAdministration.AddNote(test.Information, test.Accountemail);
            Assert.IsTrue(NoteAdministration.ChangeNote(test, "this is a test"));
            Assert.AreEqual(test.Information, "this is a test");

            try
            {
                NoteAdministration.ChangeNote(test, "this is a test");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old note doesn't exist in the note list");
            }

            Note TestDBNote = new Note("tester", "Test@Unit.com");
            NoteAdministration.AddNote(TestDBNote.Information, TestDBNote.Accountemail);
            Assert.IsTrue(NoteAdministration.ChangeNote(TestDBNote, "test 123"));
            Assert.AreEqual(TestDBNote.Information, "test 123");

            try
            {
                NoteAdministration.ChangeNote(new Note("testing", "Test@Unit.com"), TestDBNote.Information);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "The old note doesn't exist in the note list");
            }

        }

        [TestMethod]
        public void Test_DeleteNote()
        {
            NoteAdministration.Notes.Clear();
            NoteAdministration.AddNote(test.Information, test.Accountemail);
            Assert.IsTrue(NoteAdministration.RemoveNote(test));

            try
            {
                NoteAdministration.RemoveNote(test);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is PlannerExceptions);
                Assert.AreEqual(exception.Message, "Note doesn't exist in the note list");
            }

            //Database test 
            NoteAdministration.AddNote("tester", "Test@Unit.com");
            Assert.IsTrue(NoteAdministration.RemoveNote(new Note("tester", "Test@Unit.com")));
            NoteDatabase noteDatabase = new NoteDatabase();
            Assert.IsTrue(noteDatabase.GetNote(new Note("tester", "Test@Unit.com")));

        }

        [TestMethod]
        public void Test_CleanNote()
        {
            NoteAdministration.Notes.Clear();
            Assert.IsTrue(NoteAdministration.AddNote(test.Information, "Test@Unit.com"));
            Assert.IsTrue(NoteAdministration.AddNote(test.Information+"a", ""));
            Assert.IsTrue(NoteAdministration.AddNote(test.Information + "b", ""));
            Assert.IsTrue(NoteAdministration.AddNote(test.Information + "c", "Test@Unit.com"));

            NoteAdministration.CleanNotes(new Account("Tester", "Unit", "Test@Unit.com"));

            foreach (Note note in NoteAdministration.Notes)
            {
                Assert.IsTrue(note.Accountemail != "");
            }
            Assert.AreEqual(NoteAdministration.Notes.Count, 2);

        }

        [TestMethod]
        public void Test_EmptyNoteToUser()
        {
            NoteAdministration.Notes.Clear();
            Assert.IsTrue(NoteAdministration.AddNote(test.Information+"e", "Test@Unit.com"));
            Assert.IsTrue(NoteAdministration.AddNote(test.Information + "a", ""));
            Assert.IsTrue(NoteAdministration.AddNote(test.Information + "b", ""));
            Assert.IsTrue(NoteAdministration.AddNote(test.Information + "d", "Test@Unit.com"));

            NoteAdministration.EmptyNotesToUser(new Account("Tester", "Unit", "Test@Unit.com"));
            foreach (Note note in NoteAdministration.Notes)
            {
                Assert.IsTrue(note.Accountemail != "");
            }
            Assert.AreEqual(NoteAdministration.Notes.Count, 4);
        }
    }
}

