using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.NoteSystem
{
    public class NoteDatabase
    {
        public bool InsertNote(string information, string accountemail)
        {
            try
            {
                OracleParameter[] insertParameter =
                {
                    new OracleParameter("iNOTE", information),
                    new OracleParameter("iMAIL", accountemail)
                };
                DatabaseManager.ExecuteInsertQuery("InsertNote", insertParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNote(Note note)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                            new OracleParameter("iID", note.ID)
                };
                DatabaseManager.ExecuteInsertQuery("DeleteNote", deleteParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNote(int id, string information, string accountemail)
        {
            try
            {
                OracleParameter[] updateParameter =
                           {
                            new OracleParameter("iID", id),
                            new OracleParameter("nNOTE", information)
            };
                DatabaseManager.ExecuteInsertQuery("UpdateNote", updateParameter);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }         
        }

        public Note GetNote(Note note)
        {
            Note found = null;
            try
            {
                
                OracleParameter[] checkParameter =
                            {
                                new OracleParameter("NOTE", note.Information),
                                new OracleParameter("MAIL", note.AccountEmail)
                            };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetNote"],
                    checkParameter);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reader in dt.Rows)
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string information = (String)reader["INFORMATION"];
                        string email = (String)reader["EMAILADDRESS"];
                        found = new Note(id, information, email);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return found;
        }

        public List<Note> GetNotes(string mail)
        {
            List<Note> loaded = new List<Note>();
            OracleParameter[] checkParameter =
            {
                        new OracleParameter("mail", mail)
                    };
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllNotes"],
                checkParameter);
            foreach (DataRow reader in dt.Rows)
            {
                int id = Convert.ToInt32(reader["ID"]);
                string information = (String)reader["INFORMATION"];
                string email = (String)reader["EMAILADDRESS"];
                loaded.Add(new Note(id, information, email));
            }
            return loaded;
        }
    }
}
