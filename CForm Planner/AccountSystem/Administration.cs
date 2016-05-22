using System;
using System.Data;

namespace CForm_Planner.AccountSystem
{
    public class Administration
    {
        public Account User = null;
        private AccountDatabase AccountDatabase { get; set; }

        public Administration()
        {
            AccountDatabase = new AccountDatabase();
        }

        public bool Register(string name, string lastname, string email, string password)
        {
            try
            {
               bool registerd = AccountDatabase.Register(name, lastname, email, password);
               return registerd;
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
                Account account = AccountDatabase.LoginAccount(email, password);
                if (account != null)
                {
                    User = account;
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
                bool updated = AccountDatabase.UpdateAccount(name, lastname, password, User.EmailAdress);
                return updated;
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
