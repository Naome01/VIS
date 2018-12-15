using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace JISdata.DAO
{
    public class JezdecTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"jezdec\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"jezdec\" WHERE cislo_licence=@id";
        public static String SQL_SELECT_STAJ = "SELECT * FROM \"jezdec\" WHERE sid=@sid";
        public static String SQL_INSERT = "INSERT INTO \"jezdec\" VALUES (dbo.GenerateLicence((SELECT prijmeni from osoba WHERE oID = @oid)), @sid, @licence, @oid, @heslo)";
        public static String SQL_SELECT_O = "SELECT * FROM \"jezdec\" WHERE oID=@oid";
        public static String SQL_DELETE_ID = "DELETE FROM \"jezdec\" WHERE cislo_licence=@id";
        public static String SQL_UPDATE = "UPDATE \"jezdec\" SET sid=@sid, licence=@licence, oID=@oid, heslo = @heslo WHERE cislo_licence=@cislo_licence";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static Jezdec Insert(Jezdec jezdec, Database pDb = null)
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

            if (SelectOsoba(jezdec.oid, db) == null)
            {
                SqlCommand command = db.CreateCommand(SQL_INSERT);
                PrepareCommand(command, jezdec);
                db.ExecuteNonQuery(command);
            }

            jezdec = SelectOsoba(jezdec.oid, db);
                
            if (pDb == null)
            {
                db.Close();
            }

            return jezdec;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Jezdec jezdec, Database pDb = null)
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
            PrepareCommand(command, jezdec);
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
        public static Collection<Jezdec> Select(Database pDb = null)
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

            Collection<Jezdec> jezdci = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdci;
        }
       
        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">jezdec id</param>
        public static Jezdec SelectId(Jezdec j, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", j.cislo_licence);
            SqlDataReader reader = db.Select(command);

            Collection<Jezdec> Jezdci = Read(reader);
            Jezdec jezdec = null;
            if (Jezdci.Count == 1)
            {
                jezdec = Jezdci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdec;
        }
        public static Jezdec Select(string cislo_licence, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", cislo_licence);
            SqlDataReader reader = db.Select(command);

            Collection<Jezdec> Jezdci = Read(reader);
            Jezdec jezdec = null;
            if (Jezdci.Count == 1)
            {
                jezdec = Jezdci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdec;
        }

        public static Jezdec SelectOsoba(int oid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_O);

            command.Parameters.AddWithValue("@oid", oid);
            SqlDataReader reader = db.Select(command);

            Collection<Jezdec> Jezdci = Read(reader);
            Jezdec jezdec = null;
            if (Jezdci.Count == 1)
            {
                jezdec = Jezdci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdec;
        }


        public static Collection<Jezdec> SelectStaj(int sid, Database pDb = null)
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

            command.Parameters.AddWithValue("@sid", sid);
            SqlDataReader reader = db.Select(command);

            Collection<Jezdec> jezdci = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return jezdci;
        }



        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idJezdci">jezdec id</param>
        /// <returns></returns>
        public static int Delete(Jezdec j, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", j.cislo_licence);
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
        private static void PrepareCommand(SqlCommand command, Jezdec jezdec)
        {
            command.Parameters.AddWithValue("@cislo_licence", jezdec.cislo_licence);
            command.Parameters.AddWithValue("@sid", jezdec.sid);
            if (jezdec.licence.HasValue == true)
            {
                if(jezdec.licence.Value == true) command.Parameters.AddWithValue("@licence", "1");
                else command.Parameters.AddWithValue("@licence", "0");
            }

            else command.Parameters.AddWithValue("@licence", "0");
            
            command.Parameters.AddWithValue("@oid", jezdec.oid);
            command.Parameters.AddWithValue("@heslo", jezdec.heslo);

        }

        private static Collection<Jezdec> Read(SqlDataReader reader)
        {
            Collection<Jezdec> jezdci = new Collection<Jezdec>();

            while (reader.Read())
            {
                int i = -1;
                Jezdec jezdec = new Jezdec();
                jezdec.cislo_licence = reader.GetString(++i);
                jezdec.sid = reader.GetInt32(++i);

                if (!reader.IsDBNull(++i))
                {
                    if (reader.GetString(i) == "1")
                    {
                        jezdec.licence = true;
                    }
                    else
                    {
                        jezdec.licence = false;
                    }
                }
                jezdec.oid = reader.GetInt32(++i);
                Osoba osoba =JISdata.DAO.OsobaTable.Select(jezdec.oid);
                jezdec.jmeno = osoba.jmeno + " " + osoba.prijmeni;
                jezdec.telefon = osoba.telefon.ToString();
                if (!reader.IsDBNull(i))
                {
                    jezdec.heslo = reader.GetString(++i);

                }
                else jezdec.heslo = "11";
                jezdci.Add(jezdec);
            }
            return jezdci;
        }

    }
}