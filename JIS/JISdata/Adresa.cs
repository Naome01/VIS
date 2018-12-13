using System;

namespace JISdata
{
    public class Adresa
    {
        public int aid { get; set; }

        public string cislo_popisne { get; set; }

        public string ulice { get; set; }

        public string mesto { get; set; }

        override
     public String ToString()
        {
            return ulice + " " + cislo_popisne + ", " + mesto;
        }



        
    }
}