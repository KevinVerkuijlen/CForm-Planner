using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.NoteSystem
{
    public class NoteDatabase
    {
        private Database db = new Database();

        public void InsertNote(Note note)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "INSERT_NOTE";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = note.Information;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = note.Accountemail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public void DeleteNote(Note note)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "DELETE_NOTE";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iNOTE", OracleDbType.Varchar2).Value = note.Information;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = note.Accountemail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public void UpdateNote(Note oldNote, Note newNote)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "UPDATE_NOTE";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("oNOTE", OracleDbType.Varchar2).Value = oldNote.Information;
                this.db.Command.Parameters.Add("oMAIL", OracleDbType.Varchar2).Value = oldNote.Accountemail;
                this.db.Command.Parameters.Add("nNOTE", OracleDbType.Varchar2).Value = newNote.Information;
                this.db.Command.Parameters.Add("nMAIL", OracleDbType.Varchar2).Value = newNote.Accountemail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public Note GetNote(Note check)
        {
            Note note = null;
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM NOTES WHERE INFORMATION = :NOTE AND EMAILADDRESS = :MAIL";
                this.db.Command.Parameters.Add(":NOTE", OracleDbType.Varchar2).Value = check.Information;
                this.db.Command.Parameters.Add(":MAIL", OracleDbType.Varchar2).Value = check.Accountemail;

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string information = (String)reader["INFORMATION"];
                    string email = (String)reader["EMAILADDRESS"];
                    note = new Note(information, email);
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.CloseConnection();
            }
            return note;
        }

        public List<Note> GetAllNotes(Account account)
        {
            List<Note> Notes = new List<Note>();
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM NOTES WHERE EMAILADDRESS = :mail";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", account.EmailAdress));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string information = (String)reader["INFORMATION"];
                    string email = (String)reader["EMAILADDRESS"];
                    Notes.Add(new Note(information, email));
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.CloseConnection();
            }
            return Notes;
        }
    }
}
