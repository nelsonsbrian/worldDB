using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CountryController : Controller
    {

      [HttpGet("/country")]
      public ActionResult Index()
      {
        List<Country> list = Country.GetAll();
        return View("Index", list);
      }
    }
}
