using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Days2Xmas_ASPNETMVC_Demo.Models
{
    public class Days2Xmas8ViewModel
    {
        [Display(Name="Year for christmas")]
        [Range(1900, 2050, ErrorMessage = "Wrong year")]        
        public int Year { get; set; }        
    }
}
