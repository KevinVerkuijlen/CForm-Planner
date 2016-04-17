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
        public string Titel { get; protected set; }
        public string Notes { get; protected set; }
        public bool Completed { get; protected set; }
        public string Accountemail { get; set; }

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
            this.Titel = titel;
            this.Notes = notes;
            this.Completed = completed;
            this.Accountemail = accountEmail;
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
