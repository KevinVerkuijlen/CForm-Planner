using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AccountSystem
{
    public class Account
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }

        public Account(string name, string lastname, string emailadress, string password)
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
            if (password == null)
            {
                throw new ArgumentNullException("password","password is empty");
            }
            this.Name = name;
            this.LastName = lastname;
            this.EmailAdress = emailadress;
            this.Password = password;
        }
    }
}
