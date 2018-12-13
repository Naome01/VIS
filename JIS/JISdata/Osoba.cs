using System;
using JISdata.DAO;

namespace JISdata
{
    public class Osoba
    {
        public int oid { get; set; }

        public string jmeno { get; set; }

        public string prijmeni { get; set; }

        public DateTime? narozen { get; set; }

        public string email { get; set; }

        public int? telefon { get; set; }

        public int adresa { get; set; }

        public void Print()
        {
            Console.WriteLine(oid.ToString() + "   " + jmeno.ToString() + "   " + prijmeni.ToString() + "   " + narozen.ToString() + "   " + email.ToString() + "   " + telefon.ToString());
        }

        public String getStringAdress()
        {
            return AdresaTable.getInstance().getByID(this.adresa).ToString();
        }

    }
}