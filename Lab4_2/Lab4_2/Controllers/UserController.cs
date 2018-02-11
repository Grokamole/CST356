using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Lab4_2.Data.Entities;
using Lab4_2.Models.View;
using Lab4_2.Data;

namespace Lab4_2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User user = MapToUser(newUser);

            SubDbContext context = new SubDbContext();
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("ShowUsersList");
        }
        
        public ActionResult ShowUsersList()
        {
            SubDbContext db = new SubDbContext();

            List<UserViewModel> models = new List<UserViewModel>();

            foreach(User user in db.Users)
            {
                UserViewModel model = MapToUserViewModel(user);
                models.Add(model);
            }

            return View(models);
        }

        private User MapToUser(UserViewModel inputUser)
        {
            User outputUser = new User();

            outputUser.EmailAddress = inputUser.EmailAddress;
            outputUser.FirstName = inputUser.FirstName;
            outputUser.GPA = inputUser.GPA;
            outputUser.ID = inputUser.ID;
            outputUser.LastName = inputUser.LastName;
            outputUser.MiddleName = inputUser.MiddleName;
            outputUser.YearsInSchool = inputUser.YearsInSchool;

            return outputUser;
        }

        private UserViewModel MapToUserViewModel(User inputUser)
        {
            UserViewModel outputUser = new UserViewModel();

            outputUser.EmailAddress = inputUser.EmailAddress;
            outputUser.FirstName = inputUser.FirstName;
            outputUser.GPA = inputUser.GPA;
            outputUser.ID = inputUser.ID;
            outputUser.LastName = inputUser.LastName;
            outputUser.MiddleName = inputUser.MiddleName;
            outputUser.YearsInSchool = inputUser.YearsInSchool;

            return outputUser;
        }

        /* public ActionResult Error()
         {
             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
         }*/
    }
}