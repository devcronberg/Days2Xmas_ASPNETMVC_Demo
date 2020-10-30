using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Days2Xmas_ASPNETMVC_Demo.Models
{
    public class Days2XmasMockCalculator : IDays2XmasCalculator
    {
        public int CalculateDays(int year)
        {
            return 9999;
        }
    }
}
