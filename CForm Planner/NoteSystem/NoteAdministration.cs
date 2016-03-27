using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.NoteSystem
{
    public class NoteAdministration
    {
        public List<Note> Notes = new List<Note>();

        public void AddNote(Note note)
        {
            int check = CheckForNote(note);
            if (check == -1)
            {
                Notes.Add(note);
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
            }
            else
            {
                throw new PlannerExceptions("Note doesn't exist in the note list");
            }
        }

        public void ChangeNote(Note oldNote, Note newNote)
        {
            int oldCheck = CheckForNote(oldNote);
            int newCheck = CheckForNote(newNote);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Notes.RemoveAt(oldCheck);
                Notes.Insert(oldCheck, newNote);
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
    }
}
