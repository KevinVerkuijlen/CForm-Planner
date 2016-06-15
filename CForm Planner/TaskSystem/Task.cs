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
        public int ID { get; private set; }
        public string Titel { get; private set; }
        public string Notes { get; private set; }
        public int HourDuration { get; private set; }
        public int MinDuration { get; private set; }
        public bool Completed { get; private set; }
        public string AccountEmail { get; private set; }

        public Task(string titel, string notes, int hourDuration, int minDuration, bool completed, string accountEmail)
        {
            if (titel == null || titel == "")
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (notes == null || notes == "")
            {
                throw new ArgumentNullException("notes", "notes is empty");
            }
            if (hourDuration <= 0 && minDuration <=0)
            {
                throw new ArgumentNullException("duration", "duration needs to be greater than zero");
            }
            Titel = titel;
            Notes = notes;
            HourDuration = hourDuration;
            MinDuration = minDuration;
            Completed = completed;
            AccountEmail = accountEmail;
        }

        public Task(int id, string titel, string notes, int hourDuration, int minDuration, bool completed, string accountEmail)
        {
            if (titel == null || titel == "")
            {
                throw new ArgumentNullException("titel", "titel is empty");
            }
            if (notes == null || notes == "")
            {
                throw new ArgumentNullException("notes", "notes is empty");
            }
            if (hourDuration <= 0 && minDuration <= 0)
            {
                throw new ArgumentNullException("duration", "duration needs to be greater than zero");
            }
            ID = id;
            Titel = titel;
            Notes = notes;
            HourDuration = hourDuration;
            MinDuration = minDuration;
            Completed = completed;
            AccountEmail = accountEmail;
        }

        public bool Update(string titel, string notes, int hourDuration, int minDuration, bool completed, string accountEmail)
        {
            if (Titel != titel || Notes != notes || HourDuration != hourDuration || MinDuration != minDuration || Completed != completed || AccountEmail != accountEmail)
            {
                Titel = titel;
                Notes = notes;
                HourDuration = hourDuration;
                MinDuration = minDuration;
                Completed = completed;
                AccountEmail = accountEmail;
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
                    && this.HourDuration == other.HourDuration
                    && this.MinDuration == other.MinDuration
                    && this.AccountEmail == other.AccountEmail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Titel.GetHashCode() ^ Notes.GetHashCode() ^ AccountEmail.GetHashCode();
        }
    }
}
