using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AccountSystem
{
    public class Administration
    {
        public Account User = null;

        public bool Register(string name, string lastname, string email, string password)
        {
            try
            {
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("mail", email)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAccount"],
                    loginParameter);
                if (dt.Rows.Count == 0)
                {
                    OracleParameter[] registerParameter =
                    {
                        new OracleParameter("iMAIL", email),
                        new OracleParameter("iNAME", name),
                        new OracleParameter("iLASTNAME", lastname),
                        new OracleParameter("iPASS", password)
                    };
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertAccount"], registerParameter);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions("This email adress is already being used by an account");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LoginAccount(string email, string password)
        {
            try
            {
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("mail", email),
                    new OracleParameter("pass", password)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["Login"],
                    loginParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    string name = (string) reader["NAME"];
                    string lastname = (string) reader["LASTNAME"];
                    string mail = (string) reader["EMAILADDRESS"];
                    this.User = new Account(name, lastname, mail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool LogoutAccount()
        {
            if (this.User != null)
            {
                this.User = null;
                return true;
            }
            else
            {
                throw new PlannerExceptions("User is not logged in");
            }
        }

        public bool UpdateAccount(string name, string lastname, string password)
        {
            if (User != null)
            {
                User.UpdateUser(name, lastname);
                try
                {
                    OracleParameter[] updateParameter =
                    {
                    new OracleParameter("iNAME", name),
                    new OracleParameter("iLASTNAME", lastname),
                    new OracleParameter("iPASS", password),
                    new OracleParameter("OLDMAIL", User.EmailAdress)
                };
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateAccount"], updateParameter);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new PlannerExceptions("User is not logged in");
            }
        }

        public void AddFriend()
        {
            
        }

        public void RemoveFriend()
        {
            
        }

        public void GetFriends()
        {
            
        }

        public void SearchFriends()
        {
            
        }

    }
}
