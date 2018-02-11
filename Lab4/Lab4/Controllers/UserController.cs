using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab4.Data.Entities;
using Lab4.Data;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            return RedirectToAction("ShowUsersList");
        }

        public IActionResult ShowUsersList()
        {
            //get list of users
            //if users are null, error
                //return view
            // return View(database.users)
            
            return View(new SubDbContext().Users);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}