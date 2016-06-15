using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace CForm_Planner.AlarmSystem
{
    public class AlarmDatabase
    {
        public bool InsertAlarm(DateTime time, bool set, string email)
        {
            try
            {
                OracleParameter[] insertParameter =
                {
                    new OracleParameter("iTIME", time),
                    new OracleParameter("iALARMSET", Convert.ToInt32(set)),
                    new OracleParameter("IMAIL", email)
                };
                DatabaseManager.ExecuteInsertQuery("InsertAlarm", insertParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAlarm(Alarm alarm)
        {
            try
            {
                OracleParameter[] deleteParameter =
                {
                            new OracleParameter("iID", alarm.ID)
                };
                DatabaseManager.ExecuteInsertQuery("DeleteAlarm", deleteParameter);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAlarm(int id, DateTime newTime, bool set)
        {
            try
            {
                OracleParameter[] updateParameter =
            {
                new OracleParameter("iID", id),
                new OracleParameter("nTIME", newTime),
                new OracleParameter("nALARMSET", Convert.ToInt32(set))
            };
                DatabaseManager.ExecuteInsertQuery("UpdateAlarm", updateParameter);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }            
        }

        public Alarm GetAlarm(Alarm alarm)
        {
            Alarm found = null;
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("TIME", alarm.Alarmtime),
                    new OracleParameter("MAIL", alarm.AccountEmail)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAlarm"],
                    checkParameter);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reader in dt.Rows)
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        DateTime time = (DateTime)reader["TIME"];
                        bool alarmset = Convert.ToBoolean(reader["ALARMSET"]);
                        string email = (String)reader["EMAILADDRESS"];
                        found = new Alarm(id, time, alarmset, email);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return found;
        }

        public List<Alarm> GetAlarms(string mail)
        {
            List<Alarm> loaded = new List<Alarm>();
            try
            {
                OracleParameter[] checkParameter =
                {
                    new OracleParameter("mail", mail)
                };
                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllAlarms"],
                    checkParameter);
                foreach (DataRow reader in dt.Rows)
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    DateTime time = (DateTime) reader["TIME"];
                    bool alarmset = Convert.ToBoolean(reader["ALARMSET"]);
                    string email = (String) reader["EMAILADDRESS"];
                    loaded.Add(new Alarm(id, time, alarmset, email));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return loaded;
        }
    }
}
