using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JISweb.Models;
//using JIScore;
using JISdata;
using JISdata.DAO;
using System.Collections.ObjectModel;
using System.Web;
using Microsoft.AspNetCore.Routing;

namespace JISweb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()

        {
      
            // IndexModel mod;
            HomeModel model = new HomeModel();
            Collection<Zavody> zavody = ZavodyTable.Select();

            foreach(Zavody zavod in zavody)
            {
                model.zavody.Add(new WebHomeClass
                {
                    zavod = zavod,
                    staj = StajTable.Select(zavod.sid)
                });
            }

            return View(model);
        }
        public IActionResult Vysledky(int id)
        {
            Collection<Soutez> s = SoutezTable.Select_zavod(id);
            Collection<Vysledek> v = new Collection<Vysledek>();
            foreach(var item in s)
            {
                foreach(var vys in VysledekTable.SelectSoutez(item.cid).OrderByDescending(o=> o.tr_body))
                {
                    v.Add(vys);
                }
            }
            VysledkyModel model = new VysledkyModel
            {
                souteze = s,
                vysledek = v

            };

            return View(model);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
