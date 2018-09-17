using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;
using System;

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
        string country = Request.Form["city"];
        string sorting = Request.Form["order"];
        List<City> list = City.FilterByCountry(country, sorting);
        return View("Index", list);
      }

      [HttpGet("/random")]
      public ActionResult GetRandom()
      {

        List<City> list = City.GetAll();
        int randomnumber = new Random().Next(0, list.Count);

        return View("Random", list[randomnumber]);
      }
    }
}
