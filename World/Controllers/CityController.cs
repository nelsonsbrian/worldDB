using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CityController : Controller
    {

      [HttpGet("/city")]
      public ActionResult Index()
      {
        List<City> list = City.FilterByCountry();
        return View("Index", list);
      }
    }
}
