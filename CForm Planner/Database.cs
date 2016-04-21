using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CForm_Planner
{
    public class Database
    {
        /// <summary>
        /// this is the command field used for the commands
        /// </summary>
        private static OracleCommand command;

        /// <summary>
        /// this will be used as the connection
        /// </summary>
        private OracleConnection connection;

        /// <summary>
        /// this is the string for the database connection
        /// </summary>
        private static readonly string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=Kevin;Password=Dragon2711";
        //private static readonly string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.19.115)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=Planner;Password=Planner; persist security info=false;Connection Timeout=200;";

        /// <summary>
        /// Sets the queries in other classes
        /// </summary>
        public string Query
        {
            set
            {
                command = new OracleCommand(value, this.connection);
            }
        }

        /// <summary>
        /// Gets the command type
        /// </summary>
        public OracleCommand Command
        {
            get
            {
                return command;
            }
        }

        /// <summary>
        /// This opens the connection
        /// </summary>
        /// <returns>this returns the open database connection</returns>
        public OracleConnection OpenConnection()
        {
            //System.Diagnostics.Process.Start("rasdial.exe", @"vpninfralab.fhict.nl I320427 Fvc0x\pD");
            this.connection = new OracleConnection(ConnectionString);
            try
            {
                // Check if the connection is already open
                this.connection.Open();
            }
            catch (OracleException)
            {
                throw;
            }

            return this.connection;
        }

        /// <summary>
        /// close the connection
        /// </summary>
        public void CloseConnection()
        {
            // check if the connection is already close
            if (this.connection.State != System.Data.ConnectionState.Closed)
            {
                this.connection.Close();
               // System.Diagnostics.Process.Start("rasdial.exe", @"vpninfralab.fhict.nl /d");
            }
        }

        /// <summary>
        /// this method saves the input in the database
        /// </summary>
        public void Commit()
        {
            using (OracleConnection connection = this.OpenConnection())
            {
                string query = "commit";
                using (OracleCommand command = new OracleCommand(query, this.connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (OracleException)
                    {
                        // Unexpected error: rethrow to let the caller handle it
                        throw;
                    }
                }
            }
        }
    }
}
