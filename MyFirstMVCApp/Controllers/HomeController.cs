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
        /// <summary>
        /// This route is the default route to the home page
        /// </summary>
        /// <returns>Returns a ViewResult</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// This post route takes user input and calls the result route
        /// </summary>
        /// <param name="begYear">Beginning year</param>
        /// <param name="endYear">Ending year</param>
        /// <returns>Returns a redirect</returns>
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Result", new { begYear, endYear});
        }

        /// <summary>
        /// This method passes the user input to the TimePerson Class file
        /// </summary>
        /// <param name="begYear">Beginning year</param>
        /// <param name="endYear">Ending year</param>
        /// <returns>Returns a list of people to the results page</returns>
        public ViewResult Result(int begYear, int endYear)
        {
            List<TimePerson> listOfPeople = TimePerson.GetPersons(begYear, endYear);
            return View(listOfPeople);
        }
    }
}
