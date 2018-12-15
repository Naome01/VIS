﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JISdata
{
    /// <summary>
    /// Represents a MS SQL Database
    /// </summary>
    public class Database
    {
        private SqlConnection Connection { get; set; }
        private SqlTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new SqlConnection();
            Language = "en";
        }

        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect(string conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;

        }

        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect()
        {
            bool ret = true;
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                ConnectionStringSettingsCollection settings =
               ConfigurationManager.ConnectionStrings;

                ConnectionStringSettings conf = new ConnectionStringSettings("LocalMssql","Data Source =.\\SQLEXPRESS; Initial Catalog = JIS; Integrated Security = SSPI; MultipleActiveResultSets = true;");

                if (settings != null)
                {
                    foreach (ConnectionStringSettings cs in settings)
                    {
                        Console.WriteLine(cs.Name);
                        Console.WriteLine(cs.ProviderName);
                        Console.WriteLine(cs.ConnectionString);
                    }
                }
                // connection string is stored in file App.config or Web.config
                ret = Connect(conf.ConnectionString);
                //ret = Connect("Data Source=.\SQLEXPRESS;Initial Catalog=JIS;Integrated Security=SSPI;MultipleActiveResultSets=true;");
            }
            return ret;
        }

        /// <summary>
        /// Close
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// End a transaction.
        /// </summary>
        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        /// <summary>
        /// If a transaction is failed call it.
        /// </summary>
        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        /// <summary>
        /// Insert a record encapulated in the command.
        /// </summary>
        public int ExecuteNonQuery(SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Nepovolena operace");
            }
            return rowNumber;
        }

        /// <summary>
        /// Create command
        /// </summary>
        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        /// <summary>
        /// Select encapulated in the command.
        /// </summary>
        public SqlDataReader Select(SqlCommand command)
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }
    }
}

