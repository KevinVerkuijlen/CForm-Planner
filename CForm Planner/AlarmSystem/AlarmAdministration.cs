using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.AlarmSystem
{
    public class AlarmAdministration
    {
        private AlarmDatabase alarmDatabase = new AlarmDatabase();
        public List<Alarm> Alarm_list = new List<Alarm>();

        public bool AddAlarm(DateTime alarmtime, bool alarmset, string email)
        {
            Alarm alarm = new Alarm(alarmtime, alarmset, email);
            int check = CheckForAlarm(alarm);
            if (check == -1)
            {
                if (alarm.AccountEmail != "")
                {
                    Alarm databaseCheck = alarmDatabase.GetAlarm(alarm);
                    if (databaseCheck == null)
                    {
                        Alarm_list.Add(alarm);
                        alarmDatabase.InsertAlarm(alarm);
                        return true;
                    }
                    else
                    {
                        throw new PlannerExceptions("Alarm already exist, please reload your data");
                    }
                }
                else
                {
                    Alarm_list.Add(alarm);
                    return true;
                }
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
                if (alarm.AccountEmail != "")
                {
                    alarmDatabase.DeleteAlarm(alarm);
                }
            }
            else
            {
                throw new PlannerExceptions("Alar doesn't exist in the alarm list");
            }
        }

        public void ChangeAlarm(Alarm oldAlarm, DateTime alarmtime, bool alarmset, string email)
        {
            Alarm newAlarm = new Alarm(alarmtime, alarmset, email);
            int oldCheck = CheckForAlarm(oldAlarm);
            int newCheck = CheckForAlarm(newAlarm);
            if (oldCheck >= 0 && newCheck == -1)
            {
                Alarm_list.RemoveAt(oldCheck);
                Alarm_list.Insert(oldCheck, newAlarm);
                if (oldAlarm.AccountEmail !="" && newAlarm.AccountEmail != "")
                {
                    alarmDatabase.UpdateAlarm(oldAlarm,newAlarm);
                }
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

        public void MergeAlarms(Account user)
        {
            if (user != null)
            {
                List<Alarm> loaded = alarmDatabase.GetAllAlarms(user);
                this.Alarm_list = Alarm_list.Union(loaded).Distinct().ToList();
            }
        }

        public void UploadAlarms(Account user)
        {
            if (user != null)
            {
                foreach (Alarm a in Alarm_list)
                {
                    if (a.AccountEmail != "")
                    {
                        Alarm databaseCheck = alarmDatabase.GetAlarm(a);
                        if (databaseCheck == null)
                        {
                            alarmDatabase.InsertAlarm(a);
                        }
                        else
                        {
                            if (databaseCheck != a)
                            {
                                alarmDatabase.UpdateAlarm(databaseCheck, a);
                            }
                        }
                    }
                }
            }
        }
    }
}
