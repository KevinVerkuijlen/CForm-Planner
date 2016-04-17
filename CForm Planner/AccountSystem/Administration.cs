using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AccountSystem
{
    public class Administration
    {
        private AccountDatabase accountDatabase = new AccountDatabase();
        public Account user = null;

        public void Register(string name, string lastname, string email, string password)
        {
            Account newAccount = new Account(name, lastname, email, password); 
            Account check = accountDatabase.GetAccount(newAccount.EmailAdress);
            if (check == null)
            {
                accountDatabase.InsertAccount(newAccount);
            }
            else
            {
                throw new PlannerExceptions("This email adress is already being used by an account");
            }
        }

        public void LoginAccount(string email, string password)
        {
            Account userAccount = accountDatabase.Login(email, password);
            if (userAccount != null)
            {
                this.user = userAccount;
            }
        }   

        public void LogoutAccount()
        {
            if (user != null)
            {
                this.user = null;
            }
        }

        public void UpdateAccount(string name, string lastname, string email, string password)
        {
            Account account = new Account(name, lastname, email, password); 
            if (user != null && account != null)
            {
                accountDatabase.UpdateAccount(user, account);
                user = account;
            }
        }
    }
}
