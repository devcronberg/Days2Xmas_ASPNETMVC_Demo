﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Days2Xmas_ASPNETMVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Days2Xmas_ASPNETMVC_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDays2XmasCalculator days2XmasCalculator;

        [HttpGet("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("~/days2xmas01")]
        public IActionResult Days2Xmas01()
        {
            return View();
        }

        [HttpGet("~/days2xmas02")]
        public IActionResult Days2Xmas02()
        {
            int year = DateTime.Now.Year;
            int days = (new DateTime(year, 12, 24) - DateTime.Now).Days;
            ViewBag.days = days;
            ViewBag.year = year;
            return View();
        }

        [HttpGet("~/days2xmas03")]
        public IActionResult Days2Xmas03()
        {
            int year = DateTime.Now.Year;
            int days = (new DateTime(year, 12, 24) - DateTime.Now).Days;
            var model = new Days2XmasViewModel(days, year);
            return View(model);
        }

        [HttpGet("~/days2xmas04")]
        public IActionResult Days2Xmas04()
        {
            int year = DateTime.Now.Year;
            var calc = new Days2XmasCalculator();
            var model = new Days2XmasViewModel(calc.CalculateDays(year), year);
            return View(model);
        }

        [HttpGet("~/days2xmas05")]
        public IActionResult Days2Xmas05()
        {
            int year = DateTime.Now.Year;
            var model = new Days2XmasViewModel(days2XmasCalculator.CalculateDays(year), year);
            return View(model);
        }

        [HttpGet("~/days2xmas06")]
        public IActionResult Days2Xmas06()
        {
            ViewBag.year = DateTime.Now.Year;
            return View();
        }

        [HttpGet("~/days2xmas07/{year:int=2020}")]
        public IActionResult Days2Xmas07(int year)
        {
            var model = new Days2XmasViewModel(days2XmasCalculator.CalculateDays(year), year);
            return View(model);
        }

        [HttpGet("~/days2xmas08")]
        public IActionResult Days2Xmas08Get()
        {
            return View(new Days2Xmas8ViewModel { Year = DateTime.Now.Year });
        }

        [HttpPost("~/days2xmas08")]
        public IActionResult Days2Xmas08Post(Days2Xmas8ViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resModel = new Days2XmasViewModel(days2XmasCalculator.CalculateDays(model.Year), model.Year);
                return View(resModel);
            }
            else
                return View("Days2Xmas08Get", model);
        }

        [HttpGet("~/days2xmas09")]
        public IActionResult Days2Xmas09()
        {
            int year = DateTime.Now.Year;
            var model = new Days2XmasViewModel(days2XmasCalculator.CalculateDays(year), year);
            return View(model);
        }

        [HttpGet("~/days2xmas10")]
        public IActionResult Days2Xmas10()
        {
            return View();
        }

        [HttpGet("~/days2xmasapi/{year:int}")]
        public IActionResult Days2XmasAPI(int year)
        {
            var model = new Days2XmasViewModel(days2XmasCalculator.CalculateDays(year), year);
            return Json(model);
        }

        [HttpGet("~/days2xmas11")]
        public IActionResult Days2Xmas11()
        {
            return View();
        }

        public HomeController(IDays2XmasCalculator days2XmasCalculator)
        {
            this.days2XmasCalculator = days2XmasCalculator;
        }
    }
}
