using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3.Data.Entities;
using Lab3.Data;
using Lab3.Models;

namespace Lab3.Controllers
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
            MyDatabase.AddUser(newUser);
            return RedirectToAction("ShowUsersList");
        }

        public IActionResult ShowUsersList()
        {
            IReadOnlyList<User> users = MyDatabase.GetUsers();
            if (null == users)
            {
                ViewData["Error"] = "users are null.";
                return View();
            }
            return View(MyDatabase.GetUsers());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}