using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace JISdata.DAO
{
    public class OsobaTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"osoba\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"osoba\" WHERE oid=@id";
        public static String SQL_SELECT_CHANGES = "SELECT * FROM \"osoba\" WHERE oid < 0";

        public static String SQL_SELECT_LAST = "SELECT * FROM \"osoba\" WHERE oid=(SELECT MAX(oid) from osoba)";
        public static String SQL_INSERT = "INSERT INTO \"osoba\" VALUES ((SELECT MAX(oid) from osoba) +1, @jmeno, @prijmeni, @narozen, @email," +
            "@telefon, @adresa)";
        public static String SQL_INSERT_CHANGE = "INSERT INTO \"osoba\" VALUES (@oid, @jmeno, @prijmeni, @narozen, @email," +
            "@telefon, @adresa)";
        public static String SQL_DELETE_ID = "DELETE FROM \"osoba\" WHERE oid=@id";
        public static String SQL_UPDATE = "UPDATE \"osoba\" SET jmeno=@jmeno, prijmeni=@prijmeni, narozen=@narozen," +
            "email=@email, telefon=@telefon, adresa = @adresa WHERE oid=@oid";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static Osoba Insert(Osoba osoba, Database pDb = null)
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
            PrepareCommand(command, osoba);
            int ret = db.ExecuteNonQuery(command);

            command = db.CreateCommand(SQL_SELECT_LAST);
            SqlDataReader reader = db.Select(command);

            Collection<Osoba> osoby = Read(reader);
            if (osoby.Count == 1)
            {
                osoba = osoby[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osoba;
        }
        public static void InsertChange(Osoba osoba, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_INSERT_CHANGE);
            PrepareCommand(command, osoba);
            int ret = db.ExecuteNonQuery(command);

            
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Osoba osoba, Database pDb = null)
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
            PrepareCommand(command, osoba);
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
        public static Collection<Osoba> Select(Database pDb = null)
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

            Collection<Osoba> osoby = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osoby;
        }
        public static Collection<Osoba> SelectCHanges(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_CHANGES);
            SqlDataReader reader = db.Select(command);

            Collection<Osoba> osoby = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osoby;
        }

        /// <summary>
        /// Select the record.
        /// </summary>
        /// <param name="id">osoba id</param>
        public static Osoba Select(int id, Database pDb = null)
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

            Collection<Osoba> osoby = Read(reader);
            Osoba osoba = null;
            if (osoby.Count == 1)
            {
                osoba = osoby[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osoba;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idOsoby">osoba id</param>
        /// <returns></returns>
        public static int Delete(int idOsoby, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", idOsoby);
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
        private static void PrepareCommand(SqlCommand command, Osoba osoba)
        {
            command.Parameters.AddWithValue("@oid", osoba.oid);
            command.Parameters.AddWithValue("@jmeno", osoba.jmeno);
            command.Parameters.AddWithValue("@prijmeni", osoba.prijmeni);
            command.Parameters.AddWithValue("@narozen", osoba.narozen == null ? DBNull.Value : (object)osoba.narozen);
            command.Parameters.AddWithValue("@email", osoba.email == null ? DBNull.Value : (object)osoba.email);
            command.Parameters.AddWithValue("@telefon", osoba.telefon == null ? DBNull.Value : (object)osoba.telefon);
            command.Parameters.AddWithValue("@adresa", osoba.adresa);


        }

        private static Collection<Osoba> Read(SqlDataReader reader)
        {
            Collection<Osoba> osoby = new Collection<Osoba>();

            while (reader.Read())
            {
                int i = -1;
                Osoba osoba = new Osoba();
                osoba.oid = reader.GetInt32(++i);
                osoba.jmeno = reader.GetString(++i);
                osoba.prijmeni = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    osoba.narozen = reader.GetDateTime(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    osoba.email = reader.GetString(i);
                }
                else osoba.email = "";
                if (!reader.IsDBNull(++i))
                {
                    osoba.telefon = reader.GetInt32(i);
                }
                osoba.adresa = reader.GetInt32(++i);
                
                osoby.Add(osoba);
            }
            return osoby;
        }

    
    }
}