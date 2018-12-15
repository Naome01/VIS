using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using JISdata;
using JISdata.DAO;

namespace JISweb.Models
{    public class WebHomeClass
    {
        public Zavody zavod;
        public Staj staj;
    }
    public class HomeModel
    {
        public Collection<WebHomeClass> zavody = new Collection<WebHomeClass>();
    }


}
