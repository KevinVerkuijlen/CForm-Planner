using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AccountSystem
{
    [Serializable]
    public class Account
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public List<Account>FriendsList { get; private set; }

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
        }

        public void UpdateUser(string name, string lastname)
        {
            this.Name = name;
            this.LastName = lastname;
        }
    }
}
