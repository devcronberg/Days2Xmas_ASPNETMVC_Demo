using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Days2Xmas_ASPNETMVC_Demo.Models;

namespace Days2Xmas_ASPNETMVC_Demo.Controllers
{
    public class HomeController : Controller
    {

        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/days2xmas1")]
        public IActionResult Days2Xmas1()
        {
            return View();
        }
    }
}
