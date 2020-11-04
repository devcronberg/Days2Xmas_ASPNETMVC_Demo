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
  - Calc in controller and use of ViewModel  
 
