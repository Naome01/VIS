using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JISdata;
using JISdata.DAO;

namespace JISweb.Models
{
    public class VysledkyModel
    {
        public Collection<Soutez> souteze;
        public Collection<Vysledek> vysledek;
    }
}
