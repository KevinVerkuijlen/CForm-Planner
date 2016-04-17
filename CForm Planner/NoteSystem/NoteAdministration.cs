using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.NoteSystem
{
    public class NoteAdministration
    {
        private NoteDatabase noteDatabase = new NoteDatabase();
        public List<Note> Notes = new List<Note>();

        public void AddNote(string information, string accountemail)
        {
            Note note = new Note(information, accountemail);
            int check = CheckForNote(note);
            if (check == -1)
            {
                if (note.Accountemail != "")
                {
                    Note databaseCheck = noteDatabase.GetNote(note);
                    if (databaseCheck == null)
                    {
                        Notes.Add(note);
                        noteDatabase.InsertNote(note);
                    }
                    else
                    {
                        throw new PlannerExceptions("Note already exist, please reload your data");
                    }
                }
                else
                {
                    Notes.Add(note);
                }
            }
            else
            {
                throw new PlannerExceptions("Note already exist in the note list");
            }
        }

        public void RemoveNote(Note note)
        {
            int check = CheckForNote(note);
            if (check >= 0)
            {
                Notes.Remove(note);
                if (note.Accountemail != "")
                {
                    noteDatabase.DeleteNote(note);
                }
            }
            else
            {
                throw new PlannerExceptions("Note doesn't exist in the note list");
            }
        }

        public void ChangeNote(Note oldNote, string information, string accountemail)
        {
            Note newNote = new Note(information, accountemail);
            int oldCheck = CheckForNote(oldNote);
            int newCheck = CheckForNote(newNote);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Notes.RemoveAt(oldCheck);
                Notes.Insert(oldCheck, newNote);
                if (oldNote.Accountemail !="" && newNote.Accountemail != "")
                {
                    noteDatabase.UpdateNote(oldNote, newNote);
                }
            }
            else
            {
                throw new PlannerExceptions("The old note doesn't exist in the note list or the new note already exist in the note list");
            }
        }

        public void LinkNote()
        {

        }

        public int CheckForNote(Note note)
        {
            int check = -1;
            foreach (Note n in Notes)
            {
                if (n.Information == note.Information)
                {
                    check = Notes.IndexOf(n);
                }
            }
            return check;
        }

        public void MergeNotes(Account user)
        {
            if (user != null)
            {
                List<Note> loaded = noteDatabase.GetAllNotes(user);
                this.Notes = Notes.Union(loaded).Distinct().ToList();
            }
        }

        public void UploadTasks(Account user)
        {
            if (user != null)
            {
                foreach (Note n in Notes)
                {
                    if (n.Accountemail != "")
                    {
                        Note databaseCheck = noteDatabase.GetNote(n);
                        if (databaseCheck == null)
                        {
                            noteDatabase.InsertNote(n);
                        }
                        else
                        {
                            if (databaseCheck != n)
                            {
                                noteDatabase.UpdateNote(databaseCheck, n);
                            }
                        }
                    }
                }
            }
        }
    }
}
