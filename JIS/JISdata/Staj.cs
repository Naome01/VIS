using System;
using JISdata.DAO;
namespace JISdata
{
    public class Staj
    {
        public int sid { get; set; }

        public string nazev { get; set; }

        public int adresa { get; set; }

        public int majitel { get; set; }

        public string telefon { get; set; }

        public string heslo { get; set; }


        public void Print()

        {
            Adresa adresa = AdresaTable.getInstance().getByID(this.adresa);
            Console.WriteLine(sid.ToString() + "   " + nazev.ToString() + ",  " + adresa.ToString() + "   " + majitel.ToString() + "   " + telefon.ToString() + "   " + heslo.ToString());
        }

        public String getStringAdress()
        {
            return AdresaTable.getInstance().getByID(this.adresa).ToString();
        }
    }

}