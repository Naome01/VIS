using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;


namespace JISdata.DAO

{
    public class VysledekTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"vysledek\"";
        public static String SQL_SELECT_ONE = "SELECT * FROM \"vysledek\" WHERE cid=@id AND did = @did";
        public static String SQL_SELECT_SOUTEZ = "SELECT * FROM \"vysledek\" where cid = @id order by tr_body, cas";
        public static String SQL_PRIHLAS = "execute dbo.Prihlaseni @kun , @jezdec, @cid";
        public static String SQL_DELETE_ID = "DELETE FROM \"vysledek\" WHERE did=@id, cid = @cid";
        public static String SQL_UPDATE_VYSLEDEK = "execute dbo.PridejVysledek @did , @cid, @cas, @chyby, @vyloucen";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Prihlas(Kun kun, Jezdec jezdec, Soutez soutez, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_PRIHLAS);

            command.Parameters.AddWithValue("@kun", kun.cislo_licence);
            command.Parameters.AddWithValue("@jezdec", jezdec.cislo_licence);
            command.Parameters.AddWithValue("@cid", soutez.cid);


            int ret = db.ExecuteNonQuery(command);
            //int dvojice = DvojiceTable.Select(kun.cislo_licence, jezdec.cislo_licence, db);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        public static int Update(Vysledek vysledek, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE_VYSLEDEK);
            PrepareCommand(command, vysledek);
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
        public static Collection<Vysledek> Select(Database pDb = null)
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

            Collection<Vysledek> jezdci = Read(reader);
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
        /// <param name="id">vysledek id</param>
        public static Vysledek SelectId(int did, int cid, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", cid);
            command.Parameters.AddWithValue("@did", did);

            SqlDataReader reader = db.Select(command);

            Collection<Vysledek> Vysledky = Read(reader);
            Vysledek vysledek = null;
            if (Vysledky.Count == 1)
            {
                vysledek = Vysledky[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return vysledek;
        }

        public static Collection<Vysledek> SelectStaj(int sid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SOUTEZ);

            command.Parameters.AddWithValue("@sid", sid);
            SqlDataReader reader = db.Select(command);

            Collection<Vysledek> vysledky = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return vysledky;
        }
        public static Collection<Vysledek> SelectSoutez(int cid, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SOUTEZ);

            command.Parameters.AddWithValue("@id", cid);
            SqlDataReader reader = db.Select(command);

            Collection<Vysledek> vysledky = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return vysledky;
        }



        /// <summary>
        /// Delete the record.
        /// </summary>
        /// <param name="idJezdci">vysledek id</param>
        /// <returns></returns>
        public static int Delete(Vysledek vysledek, Database pDb = null)
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

            command.Parameters.AddWithValue("@id", vysledek.did);
            command.Parameters.AddWithValue("@cid", vysledek.cid);

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
        private static void PrepareCommand(SqlCommand command, Vysledek vysledek)
        {
            command.Parameters.AddWithValue("@cid", vysledek.cid);
            command.Parameters.AddWithValue("@did", vysledek.did);
            if (vysledek.vyloucen.HasValue == true)
            {
              if(vysledek.vyloucen.Value == true)  command.Parameters.AddWithValue("@vyloucen", "1");
            else command.Parameters.AddWithValue("@vyloucen", "0");
            }
            command.Parameters.AddWithValue("@chyby", vysledek.chyby);
            command.Parameters.AddWithValue("@cas", vysledek.cas);
            command.Parameters.AddWithValue("@tr_body", vysledek.tr_body);


        }

        private static Collection<Vysledek> Read(SqlDataReader reader)
        {
            Collection<Vysledek> vysledky = new Collection<Vysledek>();

            while (reader.Read())
            {
                int i = -1;
                Vysledek vysledek = new Vysledek();
                vysledek.did = reader.GetInt32(++i);
                vysledek.cid = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    vysledek.cas = reader.GetTimeSpan(i);
                    vysledek.tr_body = reader.GetInt32(++i);

                    if (reader.GetString(++i) == "1")
                    {
                        vysledek.vyloucen = true;
                    }
                    else
                    {
                        vysledek.vyloucen = false;
                    }
                    vysledek.chyby = reader.GetInt32(++i);
                }
                vysledek.jezdec_name = OsobaTable.Select(JezdecTable.Select(DvojiceTable.Select(vysledek.did).jezdec).oid).prijmeni;
                vysledek.kun_name = KunTable.Select(DvojiceTable.Select(vysledek.did).kun).jmeno;

                vysledky.Add(vysledek);
            }
            return vysledky;
        }

      
    }
}