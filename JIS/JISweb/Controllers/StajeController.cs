using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JISweb.Controllers
{
    public class StajeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}