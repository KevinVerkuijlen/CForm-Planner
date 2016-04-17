using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AlarmSystem
{
    [Serializable]
    public class Alarm : IComparable<Alarm>
    {
        public DateTime Alarmtime { get; set; }
        public bool AlarmSet { get; set; }
        public string AccountEmail { get; set; }

        public Alarm(DateTime alarmtime, bool alarmSet, string accountemail)
        {
            if (alarmtime == null)
            {
                throw new ArgumentNullException("alarmtime", "alarmtime is empty");
            }
            this.Alarmtime = alarmtime;
            this.AlarmSet = alarmSet;
            this.AccountEmail = accountemail;
        }

        public override bool Equals(object obj)
        {
            if (obj is Alarm)
            {
                Alarm other = ((Alarm)obj);
                return this.Alarmtime == other.Alarmtime
                    && this.AccountEmail == other.AccountEmail;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Alarmtime.GetHashCode() ^ AccountEmail.GetHashCode();
        }

        public int CompareTo(Alarm other)
        {
            if (this.Alarmtime < other.Alarmtime)
            {
                return -1;
            }
            else if(this.Alarmtime > other.Alarmtime)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
