using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.NoteSystem
{
    public class NoteAdministration
    {
        public List<Note> Notes = new List<Note>();
        private NoteDatabase NoteDatabase { get; set; }

        public NoteAdministration()
        {
            NoteDatabase = new NoteDatabase();
        }

        public bool AddNote(string information, string accountemail)
        {
            Note note = new Note(information, accountemail);
            if (Notes.Contains(note) == false)
            {
                if (note.AccountEmail != "")
                {
                    try
                    {
                        if (NoteDatabase.GetNote(note) == null)
                        {
                            bool insert = NoteDatabase.InsertNote(information, accountemail);
                            Notes.Add(NoteDatabase.GetNote(note));
                            return insert;
                        }
                        else
                        {
                            throw new PlannerExceptions("Note already exist in the database note list");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                throw new PlannerExceptions("Note already exist in the note list");
            }
            Notes.Add(note);
            return true;
        }

        public bool RemoveNote(Note note)
        {
            if (Notes.Contains(note))
            {
                Notes.Remove(note);
                if (note.AccountEmail != "")
                {
                    NoteDatabase.DeleteNote(note);
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Note doesn't exist in the note list");
            }
        }

        public bool ChangeNote(Note oldNote, string information)
        {
            if (Notes.Contains(oldNote))
            {
                if (Notes.Contains(new Note(information, oldNote.AccountEmail)) == false)
                {
                    if (oldNote.AccountEmail != "")
                    {
                        try
                        {
                            NoteDatabase.UpdateNote(oldNote.ID, information, oldNote.AccountEmail);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    oldNote.Update(information, oldNote.AccountEmail);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions(
                        "The new note already exist in the note list");
                }
            }
            else
            {
                throw new PlannerExceptions(
                    "The old note doesn't exist in the note list");
            }
        }


        public void MergeNotes(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<Note> loaded = NoteDatabase.GetNotes(user.EmailAdress);
                    this.Notes = Notes.Union(loaded).Distinct().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UploadNotes(Account user)
        {
            if (user != null)
            {
                foreach (Note n in Notes)
                {
                    if (n.AccountEmail != "")
                    {
                        try
                        {
                            if (NoteDatabase.GetNote(n)== null)
                            {
                                NoteDatabase.InsertNote(n.Information, n.AccountEmail);
                            }
                            else
                            {
                                NoteDatabase.UpdateNote(n.ID, n.Information, n.AccountEmail);
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

        public void CleanNotes(Account user)
        {
            foreach (Note note in Notes.ToList())
            {
                if (note.AccountEmail == "" || note.AccountEmail != user.EmailAdress)
                {
                    RemoveNote(note);
                }
            }
        }

        public void EmptyNotesToUser(Account user)
        {
            foreach (Note note in Notes.ToList())
            {
                if (note.AccountEmail == "")
                {
                    note.Update(note.Information,user.EmailAdress);
                    NoteDatabase.InsertNote(note.Information, user.EmailAdress);
                    Notes.Add(NoteDatabase.GetNote(note));
                    Notes.Remove(note);
                }
            }
        }
    }
}
