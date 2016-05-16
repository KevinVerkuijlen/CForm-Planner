using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CForm_Planner.AccountSystem;
using Oracle.ManagedDataAccess.Client;


namespace CForm_Planner.AlarmSystem
{
    public class AlarmAdministration
    {
        public List<Alarm> Alarm_list = new List<Alarm>();

        public bool AddAlarm(DateTime alarmtime, bool alarmset, string email)
        {
            Alarm alarm = new Alarm(alarmtime, alarmset, email);
            if (Alarm_list.Contains(alarm) == false)
            {
                if (alarm.AccountEmail != "")
                {

                    try
                    {
                        if (GetAlarm(alarm))
                        {
                            Alarm_list.Add(alarm);
                            InsertAlarm(alarmtime, alarmset, email);
                            return true;
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
                    try
                    {
                        OracleParameter[] deleteParameter =
                        {
                            new OracleParameter("iTIME", alarm.Alarmtime),
                            new OracleParameter("iMAIL", alarm.AccountEmail)
                        };
                        DatabaseManager.ExecuteInsertQuery("DeleteAlarm", deleteParameter);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
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
                            UpdateAlarm(oldAlarm.Alarmtime, oldAlarm.AccountEmail, alarmtime, alarmset);
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

        public void InsertAlarm(DateTime time, bool set, string email)
        {
            OracleParameter[] insertParameter =
            {
                new OracleParameter("iTIME", time),
                new OracleParameter("iALARMSET", Convert.ToInt32(set)),
                new OracleParameter("IMAIL", email)
            };
            DatabaseManager.ExecuteInsertQuery("InsertAlarm", insertParameter);
        }

        public void UpdateAlarm(DateTime oldTime, string oldEmail, DateTime newTime, bool set)
        {
            OracleParameter[] updateParameter =
            {
                new OracleParameter("oTIME", oldTime),
                new OracleParameter("oMAIL", oldEmail),
                new OracleParameter("nTIME", newTime),
                new OracleParameter("nALARMSET", Convert.ToInt32(set))
            };
            DatabaseManager.ExecuteInsertQuery("UpdateAlarm", updateParameter);
        }

        public void MergeAlarms(Account user)
        {
            if (user != null)
            {
                try
                {
                    List<Alarm> loaded = new List<Alarm>();
                    OracleParameter[] checkParameter =
                    {
                        new OracleParameter("mail", user.EmailAdress)
                    };
                    DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllAlarms"],
                        checkParameter);
                    foreach (DataRow reader in dt.Rows)
                    {
                        DateTime time = (DateTime) reader["TIME"];
                        bool alarmset = Convert.ToBoolean(reader["ALARMSET"]);
                        string email = (String) reader["EMAILADDRESS"];
                        loaded.Add(new Alarm(time, alarmset, email));
                    }
                    this.Alarm_list = Alarm_list.Union(loaded).Distinct().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool GetAlarm(Alarm alarm)
        {
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("TIME", alarm.Alarmtime),
                    new OracleParameter("MAIL", alarm.AccountEmail)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAlarm"],
                    checkParameter);
                if (dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
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
                            if (GetAlarm(a))
                            {
                                InsertAlarm(a.Alarmtime, a.AlarmSet, a.AccountEmail);
                            }
                            else
                            {
                                UpdateAlarm(a.Alarmtime, a.AccountEmail, a.Alarmtime, a.AlarmSet);
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
                    InsertAlarm(alarm.Alarmtime, alarm.AlarmSet, user.EmailAdress);
                }
            }
        }
    }
}
