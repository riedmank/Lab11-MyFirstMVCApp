using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Result", new { begYear, endYear});
        }

        public ViewResult Result(int begYear, int endYear)
        {
            List<TimePerson> listOfPeople = TimePerson.GetPersons(begYear, endYear);
            return View(listOfPeople);
        }
    }
}
