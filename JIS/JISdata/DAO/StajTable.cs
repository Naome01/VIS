using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace JISdata.DAO
{
    public class StajTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"staj\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"staj\" WHERE sid=@id";
        public static String SQL_SELECT_Nazev = "SELECT nazev FROM \"staj\" WHERE sid=@id";
        public static String SQL_SELECT_MAX = "SELECT max(sid) from staj";

        public static String SQL_INSERT = "INSERT INTO \"staj\" VALUES (@sid, @nazev, @majitel, @telefon," +
            " @heslo, @adresa)";
        public static String SQL_DELETE_ID = "DELETE FROM \"staj\" WHERE sid=@id";
        public static String SQL_UPDATE = "UPDATE \"staj\" SET nazev=@nazev, majitel=@majitel," +
            "telefon=@telefon, heslo = @heslo, adresa = @adresa WHERE sid=@sid";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Staj staj, Database pDb = null)
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
            staj.sid = reader.GetInt32(0) +1;
            reader.Close();

            command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, staj);
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
        public static int Update(Staj staj, Database pDb = null)
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
            PrepareCommand(command, staj);
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
        public static Collection<Staj> Select(Database pDb = null)
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

            Collection<Staj> staje = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return staje;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">staj id</param>
        public static Staj Select(int id, Database pDb = null)
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

            Collection<Staj> Staje = Read(reader);
            Staj staj = null;
            if (Staje.Count == 1)
            {
                staj = Staje[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return staj;
        }
        public static String SelectNazev(int id, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_Nazev);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            String nazev = reader.GetString(0);

            return nazev;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idStaje">staj id</param>
        /// <returns></returns>
        public static int Delete(int idStaje, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", idStaje);
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
        private static void PrepareCommand(SqlCommand command, Staj staj)
        {
            command.Parameters.AddWithValue("@sid", staj.sid);
            command.Parameters.AddWithValue("@nazev", staj.nazev);
            command.Parameters.AddWithValue("@majitel", staj.majitel);
            command.Parameters.AddWithValue("@telefon", staj.telefon);
            command.Parameters.AddWithValue("@heslo", staj.heslo);
            command.Parameters.AddWithValue("@adresa", staj.adresa);


        }

        private static Collection<Staj> Read(SqlDataReader reader)
        {
            Collection<Staj> staje = new Collection<Staj>();

            while (reader.Read())
            {
                int i = -1;
                Staj staj = new Staj();
                staj.sid = reader.GetInt32(++i);
                staj.nazev = reader.GetString(++i);
                staj.majitel = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    staj.telefon = reader.GetString(i);
                }
                else staj.telefon = "";
                staj.heslo = reader.GetString(++i);
                staj.adresa = reader.GetInt32(++i);

                staje.Add(staj);
            }
            return staje;
        }

        


    }
}