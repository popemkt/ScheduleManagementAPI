using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ColdSchedulesAPI.Controllers
{
    public class SpecialtyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}