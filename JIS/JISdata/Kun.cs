using System;

namespace JISdata
{
    public class Kun
    {
        public string cislo_licence { get; set; }

        public int sid { get; set; }

        public string jmeno { get; set; }

        public string plemeno { get; set; }

        public DateTime? narozen { get; set; }

        public int majitel { get; set; }

        public Boolean? licence { get; set; }

        public void Print()
        {
            Console.WriteLine(cislo_licence.ToString() + "   " + sid.ToString() + "   " + jmeno.ToString() + "   " + plemeno.ToString() + "   " + narozen.ToString() + "   " + majitel.ToString() + "   " + licence.ToString());
        }

    }

}
