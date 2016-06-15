using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public bool AddFriend(string email, Account friend)
        {
            if (User != null && friend != null)
            {
                bool insert = AccountDatabase.ManageFriend(email, friend.EmailAdress, "InsertFriend");
                return insert;
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }

        public bool RemoveFriend(string email, Account friend)
        {
            if (User != null)
            {
                bool remove = AccountDatabase.ManageFriend(email, friend.EmailAdress, "DeleteFriend");
                User.RemoveFriend(friend);
                return remove;
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }

        public bool AcceptFriend(string email, Account friend)
        {
            if (User != null)
            {
                bool accept = AccountDatabase.ManageFriend(email, friend.EmailAdress, "AcceptFriend");
                User.AddFriend(friend);
                return accept;
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }


        public bool DeclineFriend(string email, Account friend)
        {
            if (User != null)
            {
                bool decline = AccountDatabase.ManageFriend(email, friend.EmailAdress, "DeclineFriend");
                return decline;
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }

        public void GetFriends(string email)
        {
            if (User != null)
            {
                List<Account> friends = AccountDatabase.GetFriends(email);
                User.MergeFriends(friends);
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }

        public List<Account> GetPendingFriends(string email)
        {
            if (User != null)
            {
                List<Account> pending = AccountDatabase.GetPendingFriends(email);
                return pending;
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }

        public List<Account> SearchFriends(string name)
        {
            if (User != null)
            {
                List<Account> result = AccountDatabase.SearchFriends(name);
                if (result.Contains(User))
                {
                    result.Remove(User);
                }
                return result;
            }
            else
            {
                throw new ArgumentException("User is not logged in, so can't get any friends");
            }
        }

    }
}
