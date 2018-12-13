using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;


namespace JISdata.DAO
{
    public class SoutezTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"soutez\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"soutez\" WHERE cid=@id";
        public static String SQL_SELECT_ZID = "SELECT * FROM \"soutez\" WHERE zid=@id";

        public static String SQL_SELECT_MAX = "Select max(cid) from soutez";
        public static String SQL_INSERT = "INSERT INTO \"soutez\" (cid, zid, obtiznost, limit) VALUES (@cid, @zid, @obtiznost, @limit)";
        public static String SQL_DELETE_ID = "DELETE FROM \"soutez\" WHERE cid=@id";
        public static String SQL_DELETE_ZID = "DELETE FROM \"soutez\" WHERE zid=@id";

        public static String SQL_UPDATE = "UPDATE \"soutez\" SET zid=@zid, obtiznost=@obtiznost, limit=@limit WHERE cid=@cid";

        /// <summary>
        /// Insert the record.
        /// </summary>
        /// 
                public static int Insert(Soutez soutez, Database pDb = null)
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


            SqlCommand command = db.CreateCommand(SQL_SELECT_MAX);

            SqlDataReader reader = db.Select(command);
            reader.Read();
            soutez.cid = reader.GetInt32(0) + 1;
            reader.Close();


            command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, soutez);
            db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return soutez.cid;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Soutez soutez, Database pDb = null)
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
            PrepareCommand(command, soutez);
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
        public static Collection<Soutez> Select(Database pDb = null)
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

            Collection<Soutez> souteze = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return souteze;
        }
        public static Collection<Soutez> Select_zavod(int zid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ZID);
            command.Parameters.AddWithValue("@id", zid);

            SqlDataReader reader = db.Select(command);

            Collection<Soutez> souteze = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return souteze;
        }



        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">soutez id</param>
        public static Soutez Select(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Soutez> souteze = Read(reader);
            Soutez soutez = null;
            if (souteze.Count == 1)
            {
                soutez = souteze[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return soutez;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idSouteze">soutez id</param>
        /// <returns></returns>
        public static int Delete(int idSouteze, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", idSouteze);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int DeleteZid(int zid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ZID);
            command.Parameters.AddWithValue("@id", zid);

            SqlDataReader reader = db.Select(command);

            Collection<Soutez> souteze = Read(reader);
            reader.Close();
            foreach (Soutez item in souteze)
            {
                Collection<Vysledek> vys = VysledekTable.SelectSoutez(item.cid, db);
                foreach (Vysledek i in vys)
                {
                    VysledekTable.Delete(i, db);

                }
            }
            

            command = db.CreateCommand(SQL_DELETE_ZID);
            command.Parameters.AddWithValue("@id", zid);

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
        private static void PrepareCommand(SqlCommand command, Soutez soutez)
        {
            command.Parameters.AddWithValue("@cid", soutez.cid);
            command.Parameters.AddWithValue("@zid", soutez.zid);
            command.Parameters.AddWithValue("@obtiznost", soutez.obtiznost);
            command.Parameters.AddWithValue("@limit", soutez.limit);
            
        }

        private static Collection<Soutez> Read(SqlDataReader reader)
        {
            Collection<Soutez> souteze = new Collection<Soutez>();

            while (reader.Read())
            {
                int i = -1;
                Soutez soutez = new Soutez();
                soutez.cid = reader.GetInt32(++i);
                soutez.zid = reader.GetInt32(++i);
                soutez.obtiznost = reader.GetString(++i);
                soutez.limit = reader.GetTimeSpan(++i);

                souteze.Add(soutez);
            }
            return souteze;
        }

      
    }
}