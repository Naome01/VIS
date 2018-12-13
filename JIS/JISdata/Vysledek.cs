using System;

namespace JISdata
{
    public class Vysledek
    {
        public int did { get; set; }

        public int cid { get; set; }

        public int? chyby { get; set; }

        public int? tr_body { get; set; }

        public Boolean? vyloucen { get; set; }

        public TimeSpan? cas { get; set; }
        public string jezdec_name { get; set; }
        public string kun_name { get; set; }


        public void Print()
        {
            Console.WriteLine(did.ToString() + "   " + cid.ToString() + "   " + chyby.ToString() + "   " + tr_body.ToString() + "   " + vyloucen.ToString() + "   " + cas.ToString());
        }

    }

}