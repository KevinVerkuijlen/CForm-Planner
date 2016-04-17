using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using CForm_Planner.AccountSystem;

namespace CForm_Planner.AlarmSystem
{
    public class AlarmDatabase
    {
        private Database db = new Database();

        public void InsertAlarm(Alarm alarm)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                this.db.Command.ExecuteNonQuery();

                this.db.Query = "INSERT_ALARM";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iTIME", OracleDbType.Date).Value = alarm.Alarmtime;
                int alarmS = 0;
                if (alarm.AlarmSet == true)
                {
                    alarmS = 1;
                }
                else
                {
                    if (alarm.AlarmSet == false)
                    {
                        alarmS = 0;
                    }
                }
                this.db.Command.Parameters.Add("iALARMSET", OracleDbType.Int32).Value = alarmS;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = alarm.AccountEmail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public void DeleteAlarm(Alarm alarm)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                this.db.Command.ExecuteNonQuery();

                this.db.Query = "DELETE_ALARM";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("iTIME", OracleDbType.Date).Value = alarm.Alarmtime;
                this.db.Command.Parameters.Add("iMAIL", OracleDbType.Varchar2).Value = alarm.AccountEmail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public void UpdateAlarm(Alarm oldAlarm, Alarm newAlarm)
        {
            try
            {
                this.db.OpenConnection();
                this.db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                this.db.Command.ExecuteNonQuery();

                this.db.Query = "UPDATE_ALARM";
                this.db.Command.CommandType = System.Data.CommandType.StoredProcedure;
                this.db.Command.Parameters.Add("oTIME", OracleDbType.Date).Value = oldAlarm.Alarmtime;
                this.db.Command.Parameters.Add("oMAIL", OracleDbType.Varchar2).Value = oldAlarm.AccountEmail;
                this.db.Command.Parameters.Add("nTIME", OracleDbType.Date).Value = newAlarm.Alarmtime;
                int newAlarmS = 0;
                if (newAlarm.AlarmSet == true)
                {
                    newAlarmS = 1;
                }
                else
                {
                    if (newAlarm.AlarmSet == false)
                    {
                        newAlarmS = 0;
                    }
                }
                this.db.Command.Parameters.Add("nALARMSET", OracleDbType.Int32).Value = newAlarmS;
                this.db.Command.Parameters.Add("nMAIL", OracleDbType.Varchar2).Value = newAlarm.AccountEmail;
                this.db.Command.ExecuteNonQuery();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.Commit();
                this.db.CloseConnection();
            }
        }

        public Alarm GetAlarm(Alarm check)
        {
            Alarm alarm = null;
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM ALARM WHERE TIME = :TIME AND EMAILADDRESS = :MAIL";
                this.db.Command.Parameters.Add(":TIME", OracleDbType.Date).Value = check.Alarmtime;
                this.db.Command.Parameters.Add(":MAIL", OracleDbType.Varchar2).Value = check.AccountEmail;

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime time = (DateTime)reader["TIME"];
                    int set = Convert.ToInt32(reader["ALARMSET"]);
                    bool alarmset = false;
                    if (set == 1)
                    {
                        alarmset = true;
                    }
                    else
                    {
                        if (set == 0)
                        {
                            alarmset = false;
                        }
                    }
                    string email = (String)reader["EMAILADDRESS"];
                    alarm = new Alarm(time, alarmset, email);
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.CloseConnection();
            }
            return alarm;
        }

        public List<Alarm> GetAllAlarms(Account account)
        {
            List<Alarm> alarms = new List<Alarm>();
            try
            {
                this.db.OpenConnection();
                this.db.Query = "SELECT * FROM ALARM WHERE EMAILADDRESS = :mail";
                this.db.Command.Parameters.Add(new OracleParameter(":mail", account.EmailAdress));

                OracleDataReader reader = this.db.Command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime time = (DateTime)reader["TIME"];
                    int set = Convert.ToInt32(reader["ALARMSET"]);
                    bool alarmset = false;
                    if (set == 1)
                    {
                        alarmset = true;
                    }
                    else
                    {
                        if (set == 0)
                        {
                            alarmset = false;
                        }
                    }
                    string email = (String)reader["EMAILADDRESS"];
                    alarms.Add(new Alarm(time, alarmset,email));
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                this.db.CloseConnection();
            }
            return alarms;
        }
    }
}
