using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JISdata;
using JISdata.DAO;
using JISweb.Models;
using System.Collections.ObjectModel;

namespace JISweb.Controllers
{
    public class JezdciController : Controller
    {
        public IActionResult Index()
        {
            JezdecModel model = new JezdecModel();
            model.jezdci = JezdecTable.Select();
            
            return View(model);
        }
    }
}