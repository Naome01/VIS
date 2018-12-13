using System;

namespace JISdata
{
    public class Soutez
    {
        public int cid { get; set; }

        public int zid { get; set; }

        public string obtiznost { get; set; }

        public TimeSpan limit { get; set; }

        public void Print()
        {
            Console.WriteLine(cid.ToString() + "   " + zid.ToString() + "   " + obtiznost.ToString() + "   " + limit.ToString());
        }


    }

}
