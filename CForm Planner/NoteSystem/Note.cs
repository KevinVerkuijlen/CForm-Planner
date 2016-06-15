using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.NoteSystem
{
    [Serializable]
    public class Note
    {
        public int ID { get; private set; }
        public string Information { get; private set; }
        public string AccountEmail { get; private set; }

        public Note(string information, string accountEmail)
        {
            if (information == null)
            {
                throw new ArgumentNullException("information", "information is empty");
            }
            Information = information;
            AccountEmail = accountEmail;
        }

        public Note(int id, string information, string accountEmail)
        {
            if (information == null)
            {
                throw new ArgumentNullException("information", "information is empty");
            }
            ID = id;
            Information = information;
            AccountEmail = accountEmail;
        }

        public bool Update(string information, string accountemail)
        {
            if (Information != information || AccountEmail != accountemail)
            {
                Information = information;
                AccountEmail = accountemail;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Note)
            {
                Note other = ((Note)obj);
                return this.Information == other.Information
                    && this.AccountEmail == other.AccountEmail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Information.GetHashCode() ^ AccountEmail.GetHashCode();
        }
    }
}
