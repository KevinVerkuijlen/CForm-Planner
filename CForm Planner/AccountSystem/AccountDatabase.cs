using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms.VisualStyles;
using CForm_Planner.AlarmSystem;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AccountSystem
{
    public class AccountDatabase
    {

        private string Encrypt(string password)
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

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
                        new OracleParameter("iPASS", Encrypt(password))
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

        public Account LoginAccount(string email, string password)
        {
            Account account = null;
            try
            {
                OracleParameter[] loginParameter =
                {
                    new OracleParameter("mail", email),
                    new OracleParameter("pass", Encrypt(password))
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["Login"],
                    loginParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    string name = (string)reader["NAME"];
                    string lastname = (string)reader["LASTNAME"];
                    string mail = (string)reader["EMAILADDRESS"];
                    account = new Account(name, lastname, mail);
                }
                return account;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAccount(string name, string lastname, string password, string email)
        {
            try
            {
                OracleParameter[] updateParameter =
                {
                    new OracleParameter("iNAME", name),
                    new OracleParameter("iLASTNAME", lastname),
                    new OracleParameter("iPASS", Encrypt(password)),
                    new OracleParameter("OLDMAIL", email)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateAccount"], updateParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Account> GetFriends(string mail)
        {
            List<Account> friends = new List<Account>();
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("mail", mail),
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetFriends"],
                    checkParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    string name = (string)reader["NAME"];
                    string lastname = (string)reader["LASTNAME"];
                    string email = (string)reader["EMAILADDRESS"];
                    friends.Add(new Account(name, lastname, email));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return friends;
        }

        public List<Account> GetPendingFriends(string mail)
        {
            List<Account> pendingFriends = new List<Account>();
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("mail", mail)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetPendingFriends"],
                    checkParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    string name = (string)reader["NAME"];
                    string lastname = (string)reader["LASTNAME"];
                    string email = (string)reader["EMAILADDRESS"];
                    pendingFriends.Add(new Account(name, lastname, email));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pendingFriends;
        }

        public List<Account> SearchFriends(string name)
        {
            List<Account> foundAccounts = new List<Account>();
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("name", name)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["SearchFriend"],
                    checkParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    string friendName = (string)reader["NAME"];
                    string lastname = (string)reader["LASTNAME"];
                    string email = (string)reader["EMAILADDRESS"];
                    foundAccounts.Add(new Account(friendName, lastname, email));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return foundAccounts;
        }

        public bool ManageFriend(string usermail, string friendmail, string query)
        {
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("iMAIL", usermail),
                    new OracleParameter("fMAIL", friendmail),
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query[query], checkParameter);
                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("ORA-00001"))
                {
                    throw new PlannerExceptions("You already asked this person to be friends");
                }
                else
                {
                    throw;
                }
            }
        }       
    }
}
