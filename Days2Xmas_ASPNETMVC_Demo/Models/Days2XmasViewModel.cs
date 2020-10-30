using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Days2Xmas_ASPNETMVC_Demo.Models
{
    public class Days2XmasViewModel
    {
        public int Year { get; private set; }
        public int Days { get; private set; }
        public Days2XmasViewModel(int days, int year)
        {
            Days = days;
            Year = year;
        }

    }
}
