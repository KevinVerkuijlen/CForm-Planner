using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CForm_Planner.AlarmSystem
{
    public class AlarmAdministration
    {
        public List<Alarm> Alarm_list = new List<Alarm>();

        public void AddAlarm(Alarm alarm)
        {
            int check = CheckForAlarm(alarm);
            if (check == -1)
            {
                Alarm_list.Add(alarm);
            }
            else
            {
                throw new PlannerExceptions("Alarm already exist in the alrm list");
            }
        }

        public void RemoveAlarm(Alarm alarm)
        {
            int check = CheckForAlarm(alarm);
            if (check >= 0)
            {
                Alarm_list.Remove(alarm);
            }
            else
            {
                throw new PlannerExceptions("Alar doesn't exist in the alarm list");
            }
        }

        public void ChangeAlarm(Alarm oldAlarm, Alarm newAlarm)
        {
            int oldCheck = CheckForAlarm(oldAlarm);
            int newCheck = CheckForAlarm(newAlarm);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Alarm_list.RemoveAt(oldCheck);
                Alarm_list.Insert(oldCheck, newAlarm);
            }
            else
            {
                throw new PlannerExceptions("The old alarm doesn't exist in the alarm list or the new alarm already exist in the alarm list");
            }
        }

        public int CheckForAlarm(Alarm alarm)
        {
            int check = -1;
            foreach (Alarm a in Alarm_list)
            {
                if (a.Alarmtime.ToString("HH:mm") == alarm.Alarmtime.ToString("HH:mm") && a.AlarmSet == alarm.AlarmSet)
                {
                    check = Alarm_list.IndexOf(a);
                }
            }
            return check;
        }
        
    }
}
