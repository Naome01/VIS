using System;

namespace JISdata
{
    public class Zavody
    {
        public int zid { get; set; }

        public int sid { get; set; }

        public DateTime datum { get; set; }

        public string stajName { get; set; }

        public string info { get; set; }

        public void Print()
        {
            Console.WriteLine(zid.ToString() + "   " + sid.ToString() + "   " + datum.ToString() );
        }
    }
}
