# DemoScript

- Show the MVC template
- Show working Index page
  - Edit view
- Show Master page
  - Edit _Layout-file
  - Add css (from /wwwroot) 
  - Add js (from /wwwroot)
- Create days2xmas01
  - Calc in view
  
```csharp
int year = DateTime.Now.Year;
int days = (new DateTime(year, 12, 24) - DateTime.Now).Days;
```

- Create days2xmas02
  - Calc in controller
- Create days2xmas03
  - Calc in controller and use of ViewModel  

 ```csharp
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
 ```
- Create days2xmas04
  - Calculate in Model and use ViewModel

```csharp
public class Days2XmasCalculator 
{
  public int CalculateDays(int year)
  {
    return (new DateTime(year, 12, 24) - DateTime.Now).Days;
  }
}
```
  
 - Create days2xmas05
  - Dependency injection in controller

```csharp
services.AddTransient<Days2XmasCalculator>();
//services.AddTransient<Days2XmasCalculator>();
//services.AddTransient<IDays2XmasCalculator>(i =>
//{
//    if (DateTime.Now.Millisecond % 2 == 0)
//        return new Days2XmasMockCalculator();
//    else
//        return new Days2XmasCalculator();
//});
// services.AddTransient<IDays2XmasCalculator>(i => new Days2XmasCalculator());
```
- Create days2xmas06
  - Dependency injection in view
    - Year in ViewBag

```
@inject IDays2XmasCalculator days2XmasCalculator
```

- Create days2xmas07
  - Modelbinding
  
```csharp
[HttpGet("~/days2xmas07/{year:int=2020}")]
```

- Create days2xmas08
  - Get / Post (year)
  
```csharp
public class Days2Xmas8ViewModel
{
  [Display(Name="Year for christmas")]
  [Range(1900, 2050, ErrorMessage = "Wrong year")]        
  public int Year { get; set; }        
}
```

```html
<form method="post" action="/Days2Xmas08">
    <div>
        <label asp-for="Year"></label>
        <input asp-for="Year" />
        <span asp-validation-for="Year"></span>
    </div>
    <input type="submit" value="Calculate"  />
</form>
```

- Create days2xmas09
  - Partial view

```html
<partial name="ShowDays2Xmas" model="@Model" />
```

- Create days2xmas10
  - View Component
  
```csharp
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
```


```html
<vc:days2xmas year="@DateTime.Now.Year"></vc:days2xmas>
<vc:days2xmas year="2021"></vc:days2xmas>
```

View in /Views/Shared/Components/Days2Xmas/Default.cshtml

- Create days2xmas11
  - AJAX
  - Show LibMan (Axios)

```HTML
<h3>Days2Xmas11</h3>

<div id="request">
    <div>
        <label>Year</label>
        <input id="year" value="2020" />
    </div>
    <br />
    <input id="calculate" type="submit" value="Calculate" />
</div>

<div id="response" style="display:none">
    <p>There are <span id="response_days"></span> days days left until christmas in <span id="response_year"></span>.</p>
</div>

<p><a href="/">Home</a></p>

<script src="~/lib/axios/axios.min.js"></script>
<script>
    document.getElementById("calculate").onclick = async () => {
        let year = document.getElementById("year").value;
        let apiResponse = await axios.get("Days2XmasApi/" + year);
        let days = apiResponse.data.days;
        document.getElementById("response_days").innerText = days;
        document.getElementById("response_year").innerText = year;
        document.getElementById("response").style.display = "block";
    };

</script>
```
