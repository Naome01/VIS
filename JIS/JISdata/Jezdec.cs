using System;

namespace JISdata
{
    public class Jezdec
    {
        public string cislo_licence { get; set; }

        public int sid { get; set; }

        public Boolean? licence { get; set; }

        public int oid { get; set; }

        public string jmeno { get; set; }

        public string telefon { get; set; }

        public string heslo { get; set; }
        
        public void Print()
        {
            if (licence.HasValue)
            {
                Console.WriteLine(cislo_licence.ToString() + "   " + sid.ToString() + "   " + licence.ToString() +"   " + oid.ToString() );

            }
            Console.WriteLine(cislo_licence.ToString() + "   " + sid.ToString() + "   " + oid.ToString() );
        }

    }

}
