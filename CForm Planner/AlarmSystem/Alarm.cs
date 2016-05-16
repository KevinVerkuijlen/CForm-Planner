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
        public DateTime Alarmtime { get; private set; }
        public bool AlarmSet { get; private set; }
        public string AccountEmail { get; private set; }

        public Alarm(DateTime alarmtime, bool alarmSet, string accountemail)
        {
            if (alarmtime == null)
            {
                throw new ArgumentNullException("alarmtime", "alarmtime is empty");
            }
            Alarmtime = alarmtime;
            AlarmSet = alarmSet;
            AccountEmail = accountemail;
        }

        public bool Update(DateTime alarmtime, bool alarmSet, string accountemail)
        {
            if (Alarmtime != alarmtime || AlarmSet != alarmSet || AccountEmail != accountemail)
            {
                Alarmtime = alarmtime;
                AlarmSet = alarmSet;
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
