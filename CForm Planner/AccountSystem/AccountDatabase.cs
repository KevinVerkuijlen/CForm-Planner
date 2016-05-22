using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AccountSystem
{
    public class AccountDatabase
    {
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

        public Account LoginAccount(string email, string password)
        {
            Account account = null;
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
                    new OracleParameter("iPASS", password),
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
    }
}
