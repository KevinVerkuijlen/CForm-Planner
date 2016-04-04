using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AlarmSystem
{
    [Serializable]
    public class Alarm
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
    }
}
