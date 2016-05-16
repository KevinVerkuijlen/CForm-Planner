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
        public string Information { get; private set; }
        public string Accountemail { get; private set; }

        public Note(string information, string accountemail)
        {
            if (information == null)
            {
                throw new ArgumentNullException("information", "information is empty");
            }
            Information = information;
            Accountemail = accountemail;
        }

        public bool Update(string information, string accountemail)
        {
            if (Information != information || Accountemail != accountemail)
            {
                Information = information;
                Accountemail = accountemail;
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
                    && this.Accountemail == other.Accountemail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Information.GetHashCode() ^ Accountemail.GetHashCode();
        }
    }
}
