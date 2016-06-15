using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;


namespace CForm_Planner.AlarmSystem
{
    public class AlarmAdministration
    {
        public List<Alarm> Alarm_list = new List<Alarm>();
        private AlarmDatabase AlarmDatabase { get; set; }

        public AlarmAdministration()
        {
            AlarmDatabase = new AlarmDatabase();
        }

        public bool AddAlarm(DateTime alarmtime, bool alarmset, string email)
        {
            Alarm alarm = new Alarm(alarmtime, alarmset, email);
            if (Alarm_list.Contains(alarm) == false)
            {
                if (alarm.AccountEmail != "")
                {

                    try
                    {
                        if (AlarmDatabase.GetAlarm(alarm)== null)
                        {
                            bool insert = AlarmDatabase.InsertAlarm(alarmtime, alarmset, email);
                            Alarm_list.Add(AlarmDatabase.GetAlarm(alarm));
                            return insert;
                        }
                        else
                        {
                            throw new PlannerExceptions("Alarm already exist in the alarm list Database");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
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
                throw new PlannerExceptions("Alarm already exist in the alarm list");
            }
        }

        public bool RemoveAlarm(Alarm alarm)
        {
            if (Alarm_list.Contains(alarm))
            {
                Alarm_list.Remove(alarm);
                if (alarm.AccountEmail != "")
                {
                    AlarmDatabase.DeleteAlarm(alarm);
                }
                return true;
            }
            else
            {
                throw new PlannerExceptions("Alarm doesn't exist in the alarm list");
            }
        }

        public bool ChangeAlarm(Alarm oldAlarm, DateTime alarmtime, bool alarmset)
        {
            Alarm newAlarm = new Alarm(alarmtime, alarmset, oldAlarm.AccountEmail);
            if (Alarm_list.Contains(oldAlarm))
            {
                if (Alarm_list.Contains(newAlarm) == false)
                {
                    if (oldAlarm.AccountEmail != "" && newAlarm.AccountEmail != "")
                    {
                        try
                        {
                            AlarmDatabase.UpdateAlarm(oldAlarm.ID, alarmtime, alarmset);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    oldAlarm.Update(alarmtime, alarmset, oldAlarm.AccountEmail);
                    return true;
                }
                else
                {
                    throw new PlannerExceptions(
                        "The new alarm already exist in the alarm list");
                }
            }
            else
            {
                throw new PlannerExceptions(
                    "The old alarm doesn't exist in the alarm list");
            }
        }

        public bool AlarmOn(Alarm alarm)
        {
            if (alarm.AlarmSet == false)
            {
                alarm.On();
                if (alarm.AccountEmail != "")
                {
                    AlarmDatabase.UpdateAlarm(alarm.ID, alarm.Alarmtime, true);
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Alarm is already on");
            }
        }

        public bool AlarmOff(Alarm alarm)
        {
            if (alarm.AlarmSet)
            {
                alarm.Off();
                if (alarm.AccountEmail != "")
                {
                    AlarmDatabase.UpdateAlarm(alarm.ID, alarm.Alarmtime, false);
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Alarm is already off");
            }
        }

        public void MergeAlarms(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<Alarm> loaded = AlarmDatabase.GetAlarms(user.EmailAdress);
                    this.Alarm_list = Alarm_list.Union(loaded).Distinct().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
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
                        try
                        {
                            if (AlarmDatabase.GetAlarm(a)== null)
                            {
                                AlarmDatabase.InsertAlarm(a.Alarmtime, a.AlarmSet, a.AccountEmail);
                            }
                            else
                            {
                                AlarmDatabase.UpdateAlarm(a.ID , a.Alarmtime, a.AlarmSet);
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public void CleanAlarms(Account user)
        {
            foreach (Alarm alarm in Alarm_list.ToList())
            {
                if (alarm.AccountEmail == "" || alarm.AccountEmail != user.EmailAdress)
                {
                    RemoveAlarm(alarm);
                }
            }
        }

        public void EmptyAlarmsToUser(Account user)
        {
            foreach (Alarm alarm in Alarm_list.ToList())
            {
                if (alarm.AccountEmail == "")
                {
                    alarm.Update(alarm.Alarmtime, alarm.AlarmSet, user.EmailAdress);
                    AlarmDatabase.InsertAlarm(alarm.Alarmtime, alarm.AlarmSet, user.EmailAdress);
                    Alarm_list.Add(AlarmDatabase.GetAlarm(alarm));
                    Alarm_list.Remove(alarm);
                }
            }
        }
    }
}
