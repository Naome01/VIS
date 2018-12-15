using System;
using System.Configuration.Assemblies;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace JISdata.DAO
{
    public class ZavodyTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"zavody\" order by datum desc";
        public static String SQL_SELECT_ID = "SELECT * FROM \"zavody\" WHERE zid=@id";
        public static String SQL_SELECT_Future = "SELECT * FROM \"zavody\" WHERE datum >= @datum";
        public static String SQL_SELECT_SID = "SELECT * FROM \"zavody\" WHERE sid=@id AND datum <= @datum";
        public static String SQL_SELECT_ALL_SID = "SELECT * FROM \"zavody\" WHERE sid=@id";

        public static String SQL_SELECT_LAST = "Select max(zid) from zavody";
        public static String SQL_INSERT = "INSERT INTO \"zavody\" VALUES ((Select max(zid) from zavody) + 1, @sid, @datum)";
        public static String SQL_DELETE_ID = "DELETE FROM \"zavody\" WHERE zid=@id";
        public static String SQL_UPDATE = "UPDATE \"zavody\" SET sid=@sid, datum=@datum WHERE zid=@zid";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static Zavody Insert(Zavody zavody, Database pDb = null)
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
            PrepareCommand(command, zavody);
            db.ExecuteNonQuery(command);

            command = db.CreateCommand(SQL_SELECT_LAST);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            zavody.zid = reader.GetInt32(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zavody;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Zavody zavody, Database pDb = null)
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

            if (zavody.datum <= DateTime.Now) return 0;

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zavody);
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
        public static Collection<Zavody> Select(Database pDb = null)
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

            Collection<Zavody> zavody = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zavody;
        }
        public static Collection<Zavody> SelectFuture(DateTime datum, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_Future);
            command.Parameters.AddWithValue("@datum", datum);

            SqlDataReader reader = db.Select(command);

            Collection<Zavody> zavody = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zavody;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">zavody id</param>
        public static Zavody Select(int id, Database pDb = null)
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

            Collection<Zavody> zavody = Read(reader);
            Zavody zavod = null;
            if (zavody.Count == 1)
            {
                zavod = zavody[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zavod;
        }
        public static Collection<Zavody> SelectStaj(int sid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SID);

            command.Parameters.AddWithValue("@id", sid);
            command.Parameters.AddWithValue("@datum", DateTime.Now);

            SqlDataReader reader = db.Select(command);

            Collection<Zavody> zavody = Read(reader);
            
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zavody;
        }

        public static Collection<Zavody> SelectAllFromStaj(int sid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ALL_SID);

            command.Parameters.AddWithValue("@id", sid);

            SqlDataReader reader = db.Select(command);

            Collection<Zavody> zavody = Read(reader);

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zavody;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idZavodye">zavody id</param>
        /// <returns></returns>
        public static int Delete(Zavody zavody, Database pDb = null)
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

            if (zavody.datum <= DateTime.Now)
                return 800;

            SoutezTable.DeleteZid(zavody.zid, db);

            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id", zavody.zid);
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
        private static void PrepareCommand(SqlCommand command, Zavody zavody)
        {
            command.Parameters.AddWithValue("@zid", zavody.zid);
            command.Parameters.AddWithValue("@sid", zavody.sid);
            command.Parameters.AddWithValue("@datum", zavody.datum);
    
        }

        private static Collection<Zavody> Read(SqlDataReader reader)
        {
            Collection<Zavody> zavody = new Collection<Zavody>();

            while (reader.Read())
            {
                Zavody zavod = new Zavody();

                int i = -1;
                zavod.zid = reader.GetInt32(++i);
                zavod.sid = reader.GetInt32(++i);
                zavod.datum = reader.GetDateTime(++i);
                zavod.stajName = JISdata.DAO.StajTable.SelectNazev(zavod.sid);
                zavod.info = zavod.stajName + " " + zavod.datum.ToShortDateString();
                zavody.Add(zavod);
            }
            return zavody;
        }

       
    }
}