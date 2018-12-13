using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JISdata.DAO;

namespace JISdata
{
    class Program
    {
        static void Main(string[] args)

        {
            //Database db = new Database();
           Staj staj =  StajTable.Select(2);
            staj.Print();

            staj = StajTable.Select(3);
            staj.Print();

            Console.Read();
        }
    }
}
