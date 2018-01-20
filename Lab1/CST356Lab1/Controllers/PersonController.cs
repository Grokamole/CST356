using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CST356Lab1.Models;

namespace CST356Lab1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            Person person = new Person("The Character", "The Player", "The Class");
            ViewBag.Person = person;
            return View();
        }
    }
}