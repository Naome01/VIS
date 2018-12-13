using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;


namespace JISdata.DAO
{
    public class KunTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"kun\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"kun\" WHERE cislo_licence=@id";
        public static String SQL_SELECT_STAJ = "SELECT * FROM \"kun\" WHERE sid=@id";
        public static String SQL_INSERT = "INSERT INTO \"kun\" VALUES (@cislo_licence, @sid, @jmeno, @plemeno, @narozen, @majitel, @licence)";
        public static String SQL_LICENCE = "SELECT dbo.GenerateLicence ( @jmeno )";
        public static String SQL_DELETE_ID = "DELETE FROM \"kun\" WHERE cislo_licence=@id";
        public static String SQL_UPDATE = "UPDATE \"kun\" SET sid=@sid, jmeno = @jmeno, plemeno = @plemeno, narozen = @narozen, majitel = @majitel, licence=@licence WHERE cislo_licence=@cislo_licence";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static Kun Insert(Kun kun, Database pDb = null)
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

            kun = Licence(kun, db);

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, kun);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return kun;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Kun kun, Database pDb = null)
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
            PrepareCommand(command, kun);
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
        public static Collection<Kun> Select(Database pDb = null)
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

            Collection<Kun> kone = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kone;
        }
        public static Collection<Kun> Select(int sid,Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_STAJ);
            command.Parameters.AddWithValue("@id", sid);

            SqlDataReader reader = db.Select(command);

            Collection<Kun> kone = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kone;
        }

        public static Kun Licence(Kun kun, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_LICENCE);
            command.Parameters.AddWithValue("@jmeno", kun.jmeno);

            SqlDataReader reader = db.Select(command);
            reader.Read();
            kun.cislo_licence = reader.GetString(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }
            return kun;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">kun id</param>
        public static Kun Select(String id, Database pDb = null)
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

            Collection<Kun> Kone = Read(reader);
            Kun kun = null;
            if (Kone.Count == 1)
            {
                kun = Kone[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kun;
        }


        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idKone">kun id</param>
        /// <returns></returns>
        public static int Delete(Kun kun, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", kun.cislo_licence);
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
        private static void PrepareCommand(SqlCommand command, Kun kun)
        {
            command.Parameters.AddWithValue("@cislo_licence", kun.cislo_licence);
            command.Parameters.AddWithValue("@sid", kun.sid);
            command.Parameters.AddWithValue("@jmeno", kun.jmeno);
            command.Parameters.AddWithValue("@plemeno", kun.plemeno == null ? DBNull.Value : (object)kun.plemeno);
            command.Parameters.AddWithValue("@narozen", kun.narozen == null ? DBNull.Value : (object)kun.narozen);
            command.Parameters.AddWithValue("@majitel", kun.majitel);
            if (kun.licence.HasValue == true)
            {
               if(kun.licence.Value == true) command.Parameters.AddWithValue("@licence", "1");
                else command.Parameters.AddWithValue("@licence", "0");
            }
            else command.Parameters.AddWithValue("@licence", "0");
            

        }

        private static Collection<Kun> Read(SqlDataReader reader)
        {
            Collection<Kun> kone = new Collection<Kun>();

            while (reader.Read())
            {
                int i = -1;
                Kun kun = new Kun();
                kun.cislo_licence = reader.GetString(++i);
                kun.sid = reader.GetInt32(++i);
                kun.jmeno = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    kun.plemeno = reader.GetString(i);
                }
                else kun.plemeno = "";
                if (!reader.IsDBNull(++i))
                {
                    kun.narozen = reader.GetDateTime(i);
                }
                kun.majitel = reader.GetInt32(++i);

                if (!reader.IsDBNull(++i))
                {
                    if (reader.GetString(i) == "1")
                    {
                        kun.licence = true;
                    }
                    else
                    {
                        kun.licence = false;
                    }
                }
                kone.Add(kun);
            }
            return kone;
        }

    }
}