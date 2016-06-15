using System;
using System.Data;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows.Forms;

namespace CForm_Planner
{
    public static class DatabaseManager
    {
        private static OracleConnection _connection;

        private static OracleConnection Connection
        {
            get
            {
                try
                {
                    // _connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.19.115)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=Planner;Password=Planner");
                    _connection =
                        new OracleConnection(
                            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=Kevin;Password=Dragon2711");
                    _connection.Open();
                    return _connection;
                }
                catch (Exception ex)
                {
                    throw ;
                }
                return null;
            }
        }

        public static DataTable ExecuteReadQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleCommand command = new OracleCommand(sqlquery, Connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                DataTable dt = new DataTable();
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
                return dt;
            }
        }

        public static void ExecuteInsertQuery(string sqlquery, OracleParameter[] parameters)
        {
            OracleConnection connection = Connection;
            OracleTransaction transaction = connection.BeginTransaction();
            OracleCommand command = new OracleCommand(sqlquery, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (OracleException)
            {
                throw;
            }
            connection.Close();
        }

       
        public static void ExecuteDeleteQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleTransaction ot = Connection.BeginTransaction())
            {
                OracleCommand command = new OracleCommand(sqlquery, _connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                try
                {
                    command.ExecuteNonQuery();
                    ot.Commit();
                }
                catch (OracleException oe)
                {
                    throw;
                }
            }
        }

        public static bool CheckConnection()
        {
            try
            {
                OracleConnection con = Connection;
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public static DataTable ExecuteFunction(string sqlquery, OracleParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Connection)
                {
                    OracleCommand cmd = new OracleCommand(sqlquery, Connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("return", OracleDbType.RefCursor));
                    cmd.Parameters["return"].Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.AddRange(parameters);

                    cmd.ExecuteNonQuery();
                    OracleDataReader reader = ((OracleRefCursor) cmd.Parameters["return"].Value).GetDataReader();

                    dt.Load(reader);
                }
                return dt;
            }                    
            catch (Exception)
            {
                throw;
            }
        }


    }
}
