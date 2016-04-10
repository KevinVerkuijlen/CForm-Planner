using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CForm_Planner.AccountSystem
{
    public class AccountDatabase
    {
        private Database db = new Database();

        public Account GetAccount(string mail)
        {
            Account check = null;
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM ACCOUNT WHERE EMAILADDRESS = :mail";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", mail));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (String)reader["NAME"];
                    string lastname = (String)reader["LASTNAME"];
                    string email = (String)reader["EMAILADDRESS"];
                    string password = (String)reader["PASSWORD"];
                    check = new Account(name, lastname, email, password);
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
            return check;
        }

        public Account Login(string mail, string pass)
        {
            Account login = null;
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM ACCOUNT WHERE EMAILADDRESS = :mail AND PASSWORD = :pass";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", mail));
                this.db.Command.Parameters.Add(new OracleParameter(":pass", pass));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (String)reader["NAME"];
                    string lastname = (String)reader["LASTNAME"];
                    string email = (String)reader["EMAILADDRESS"];
                    string password = (String)reader["PASSWORD"];
                    login = new Account(name, lastname, email, password);
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
            return login;
        }

        public void InsertAccount(Account newaccount)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "INSERT_ACCOUNT";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = newaccount.EmailAdress;
                this.db.Command.Parameters.Add("iNAME", OracleDbType.Varchar2).Value = newaccount.Name;
                this.db.Command.Parameters.Add("iLASTNAME", OracleDbType.Varchar2).Value = newaccount.LastName;
                this.db.Command.Parameters.Add("iPASS", OracleDbType.Varchar2).Value = newaccount.Password;
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

        public void UpdateAccount(Account oldaccount, Account changedaccount)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "UPDATE_ACCOUNT";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iNAME", OracleDbType.Varchar2).Value = changedaccount.Name;
                this.db.Command.Parameters.Add("iLASTNAME", OracleDbType.Varchar2).Value = changedaccount.LastName;
                this.db.Command.Parameters.Add("iPASS",OracleDbType.Varchar2).Value =  changedaccount.Password;
                this.db.Command.Parameters.Add("OLDMAIL", OracleDbType.Varchar2).Value = oldaccount.EmailAdress;
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

    /*    public List<Account> GetFriends(Account account)
        {
            List<Account> Friends = new List<Account>();
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM ACCOUNT WHERE EMAILADDRESS = :mail";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", account.EmailAdress));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (String)reader["NAME"];
                    string lastname = (String)reader["LASTNAME"];
                    string email = (String)reader["EMAILADDRESS"];
                    string password = (String)reader["PASSWORD"];
                    Friends.Add(new Account(name, lastname, email, password));
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {

            }
            return Friends;
        }*/
    }
}
