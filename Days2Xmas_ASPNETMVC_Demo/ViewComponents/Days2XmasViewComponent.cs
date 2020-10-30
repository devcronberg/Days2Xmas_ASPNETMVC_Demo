using Days2Xmas_ASPNETMVC_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Days2Xmas_ASPNETMVC_Demo.ViewComponents
{
    [ViewComponent(Name = "days2xmas")]
    public class Days2XmasViewComponent : ViewComponent
    {
        private readonly IDays2XmasCalculator days2XmasCalculator;

        public IViewComponentResult Invoke(int year = 2020)
        {            
            var model = new Days2XmasViewModel(days2XmasCalculator.CalculateDays(year), year);
            return View(model);            
        }

        public Days2XmasViewComponent(IDays2XmasCalculator days2XmasCalculator)
        {
            this.days2XmasCalculator = days2XmasCalculator;
        }
    }
}
