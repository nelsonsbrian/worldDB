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
        List<City> list = City.GetAll();
        return View("Index", list);
      }

      [HttpPost("/city")]
      public ActionResult GetCity()
      {
        List<City> list = City.FilterByCountry(Request.Form["city"]);
        return View("Index", list);
      }
    }
}
