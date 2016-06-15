using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AccountSystem
{
    [Serializable]
    public class Account
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string Display { get; set; }
        public List<Account>FriendsList { get; private set; }
        //Het was niet gelukt om het karakter onderdeel op tijd toe te voegen
        //voor het game propsal onderdeel 
        // public List<Character> Characters { get; private set; }

        public Account(string name, string lastname, string emailadress)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name", "name is empty");
            }
            if (lastname == null)
            {
                throw new ArgumentNullException("lastname", "lastname is empty");
            }
            if (emailadress == null)
            {
                throw new ArgumentNullException("emailadress","emailadress is empty");
            }
            this.Name = name;
            this.LastName = lastname;
            this.EmailAdress = emailadress;
            Display = this.ToString();
            FriendsList = new List<Account>();
           // Characters = new List<Character>();
        }

        public void UpdateUser(string name, string lastname)
        {
            this.Name = name;
            this.LastName = lastname;
        }

        public void MergeFriends(List<Account> friends)
        {
            if (FriendsList == null)
            {
                FriendsList = friends;
            }
            else
            {
                FriendsList = FriendsList.Union(friends).Distinct().ToList();
            }
        }

        public void AddFriend(Account Friend)
        {
            if (FriendsList.Contains(Friend)==false)
            {
                FriendsList.Add(Friend);
            }
        }

        public void RemoveFriend(Account Friend)
        {
            if (FriendsList.Contains(Friend))
            {
                FriendsList.Remove(Friend);
            }
        }

      /*  public void MergeCharacters(List<Character> characters )
        {
            if (Characters == null)
            {
                Characters = characters;
            }
            else
            {
                Characters = Characters.Union(characters).Distinct().ToList();
            }
        }*/


        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                Account other = ((Account)obj);
                return this.Name == other.Name
                    && this.LastName == other.LastName
                    && this.EmailAdress == other.EmailAdress;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ LastName.GetHashCode() ^ EmailAdress.GetHashCode();
        }

        public override string ToString()
        {
            return Name + ", " + LastName + " @ " + EmailAdress;
        }
    }
}
