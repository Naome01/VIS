using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace JISdata.DAO
{
    public class DvojiceTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"dvojice\"";
        public static String SQL_SELECT_ONE = "SELECT * FROM \"dvojice\" WHERE kun=@kun AND jezdec = @jezdec";
        public static String SQL_SELECT_JEZDEC = "SELECT * FROM \"dvojice\" WHERE jezdec = @jezdec";

        public static String SQL_SELECT_ID = "SELECT * FROM \"dvojice\" WHERE did = @id";
        public static String SQL_INSERT = "INSERT INTO \"dvojice\" VALUES (@did, @jezdec, @kun)";
        public static String SQL_DELETE_ID = "DELETE FROM \"dvojice\" WHERE did=@id";
        public static String SQL_UPDATE = "UPDATE \"dvojice\" SET jezdec=@jezdec, kun=@kun WHERE did=@did";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Dvojice dvojice, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, dvojice);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Dvojice dvojice, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, dvojice);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        /// <summary>
        /// Select the records.
        /// </summary>
        public static Collection<Dvojice> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Dvojice> dvojice = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return dvojice;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">dvojice id</param>
        public static int Select(string kun, string jezdec, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ONE);

            command.Parameters.AddWithValue("@kun", kun);
            command.Parameters.AddWithValue("@jezdec", jezdec);

            SqlDataReader reader = db.Select(command);

            Collection<Dvojice> dvojice = Read(reader);
            Dvojice dvoj = new Dvojice();
            if (dvojice.Count == 1)
            {
                dvoj = dvojice[0];
            }
            reader.Close();
            if(dvojice.Count == 0)
            {
                dvoj.did = -1;
            }

            if (pDb == null)
            {
                db.Close();
            }

            return dvoj.did;
        }
        public static Collection<Dvojice> SelectJezdec(string jezdec, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_JEZDEC);

            command.Parameters.AddWithValue("@jezdec", jezdec);

            SqlDataReader reader = db.Select(command);

            Collection<Dvojice> dvojice = Read(reader);
            
            return dvojice;
        }
        public static Dvojice Select(int did, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", did);

            SqlDataReader reader = db.Select(command);

            Collection<Dvojice> dvojice = Read(reader);
            Dvojice dvoj = null;
            if (dvojice.Count == 1)
            {
                dvoj = dvojice[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return dvoj;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idDvojicee">dvojice id</param>
        /// <returns></returns>
        public static int Delete(int idDvojice, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id", idDvojice);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        ///  Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Dvojice dvojice)
        {
            command.Parameters.AddWithValue("@did", dvojice.did);
            command.Parameters.AddWithValue("@jezdec", dvojice.jezdec);
            command.Parameters.AddWithValue("@kun", dvojice.kun);

        }

        private static Collection<Dvojice> Read(SqlDataReader reader)
        {
            Collection<Dvojice> dvojice = new Collection<Dvojice>();

            while (reader.Read())
            {
                int i = -1;
                Dvojice dvoj = new Dvojice();
                dvoj.did = reader.GetInt32(++i);
                dvoj.jezdec = reader.GetString(++i);
                dvoj.kun = reader.GetString(++i);

                dvojice.Add(dvoj);
            }
            return dvojice;
        }

       
    }
}