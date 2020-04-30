using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WinnipegSNS.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}