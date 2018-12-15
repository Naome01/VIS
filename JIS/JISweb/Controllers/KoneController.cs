using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JISweb.Models;
using JISdata.DAO;

namespace JISweb.Controllers
{
    public class KoneController : Controller
    {
        public IActionResult Index()

        {
            KunModel model = new KunModel();
            model.kone = KunTable.Select();
            return View(model);
        }
    }
}