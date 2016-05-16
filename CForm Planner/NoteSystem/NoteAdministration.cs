using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using CForm_Planner.AccountSystem;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.NoteSystem
{
    public class NoteAdministration
    {
        public List<Note> Notes = new List<Note>();

        public bool AddNote(string information, string accountemail)
        {
            Note note = new Note(information, accountemail);
            if (Notes.Contains(note) == false)
            {
                if (note.Accountemail != "")
                {
                    try
                    {
                        if (GetNote(note))
                        {
                            Notes.Add(note);
                            InsertNote(information, accountemail);
                            return true;
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
                else
                {
                    Notes.Add(note);
                    return true;
                }
            }
            else
            {
                throw new PlannerExceptions("Note already exist in the note list");
            }
        }

        public bool RemoveNote(Note note)
        {
            if (Notes.Contains(note))
            {
                Notes.Remove(note);
                if (note.Accountemail != "")
                {
                    try
                    {
                        OracleParameter[] deleteParameter =
                        {
                            new OracleParameter("iNOTE", note.Information),
                            new OracleParameter("iMAIL", note.Accountemail)
                        };
                        DatabaseManager.ExecuteInsertQuery("DeleteNote", deleteParameter);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
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
                if (Notes.Contains(new Note(information, oldNote.Accountemail)) == false)
                {
                    if (oldNote.Accountemail != "")
                    {
                        try
                        {
                            UpdateNote(oldNote.Information, oldNote.Accountemail, information, oldNote.Accountemail);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    oldNote.Update(information, oldNote.Accountemail);
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

        public void LinkNote()
        {

        }

        public void InsertNote(string information, string accountemail)
        {
            OracleParameter[] insertParameter =
                            {
                                new OracleParameter("iNOTE", information),
                                new OracleParameter("iMAIL", accountemail)
                            };
            DatabaseManager.ExecuteInsertQuery("InsertNote", insertParameter);
        }

        public void UpdateNote(string oldInformation, string oldAccountemail, string information, string accountemail)
        {
            OracleParameter[] updateParameter =
                           {
                            new OracleParameter("oNOTE", oldInformation),
                            new OracleParameter("oMAIL", oldAccountemail),
                            new OracleParameter("nNOTE", information)
            };
            DatabaseManager.ExecuteInsertQuery("UpdateNote", updateParameter);
        }

        public bool GetNote(Note note)
        {
            try
            {
                OracleParameter[] checkParameter =
                            {
                                new OracleParameter("NOTE", note.Information),
                                new OracleParameter("MAIL", note.Accountemail)
                            };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetNote"],
                    checkParameter);
                if (dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MergeNotes(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<Note> loaded = new List<Note>();
                    OracleParameter[] checkParameter =
                    {
                        new OracleParameter("mail", user.EmailAdress)
                    };
                    DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllNotes"],
                        checkParameter);
                    foreach (DataRow reader in dt.Rows)
                    {
                        string information = (String) reader["INFORMATION"];
                        string email = (String) reader["EMAILADDRESS"];
                        loaded.Add(new Note(information, email));
                    }
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
                    if (n.Accountemail != "")
                    {
                        try
                        {
                            if (GetNote(n))
                            {
                                InsertNote(n.Information, n.Accountemail);
                            }
                            else
                            {
                                UpdateNote(n.Information, n.Accountemail, n.Information, n.Accountemail);
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
                if (note.Accountemail == "" || note.Accountemail != user.EmailAdress)
                {
                    RemoveNote(note);
                }
            }
        }

        public void EmptyNotesToUser(Account user)
        {
            foreach (Note note in Notes.ToList())
            {
                if (note.Accountemail == "")
                {
                    note.Update(note.Information,user.EmailAdress);
                    InsertNote(note.Information, user.EmailAdress);
                }
            }
        }
    }
}
