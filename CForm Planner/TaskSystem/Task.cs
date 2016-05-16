using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.TaskSystem
{
    [Serializable]
    public class Task
    {
        public string Titel { get; private set; }
        public string Notes { get; private set; }
        public bool Completed { get; private set; }
        public string Accountemail { get; private set; }

        public Task(string titel, string notes, bool completed, string accountEmail)
        {
            if (titel == null || titel == "")
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (notes == null || notes == "")
            {
                throw new ArgumentNullException("notes", "notes is empty");
            }
            Titel = titel;
            Notes = notes;
            Completed = completed;
            Accountemail = accountEmail;
        }

        public bool Update(string titel, string notes, bool completed, string accountEmail)
        {
            if (Titel != titel || Notes != notes || Completed != completed || Accountemail != accountEmail)
            {
                Titel = titel;
                Notes = notes;
                Completed = completed;
                Accountemail = accountEmail;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Task)
            {
                Task other = ((Task)obj);
                return this.Titel == other.Titel
                    && this.Notes == other.Notes
                    && this.Accountemail == other.Accountemail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Titel.GetHashCode() ^ Notes.GetHashCode() ^ Accountemail.GetHashCode();
        }
    }
}
