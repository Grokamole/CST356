using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Lab7.Data.Entities;
using Lab7.Models.View;
using Lab7.Data;

namespace Lab7.Controllers
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
        
        public ActionResult Details(int ID)
        {
            SubDbContext context = new SubDbContext();
            User user = context.Users.Find(ID);
            if (null == user)
            {
                return RedirectToAction("ShowUsersList");
            }
            UserViewModel userView = MapToUserViewModel(user);

            return View(userView);
        }

        public ActionResult Delete(int ID)
        {
            SubDbContext context = new SubDbContext();
            User user = context.Users.Find(ID);
            if (null != user)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }

            return RedirectToAction("ShowUsersList");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            SubDbContext context = new SubDbContext();
            User user = context.Users.Find(ID);
            if (null == user)
            {
                return RedirectToAction("ShowUsersList");
            }

            return View(MapToUserViewModel(user));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            SubDbContext context = new SubDbContext();
            User user = context.Users.Find(userModel.ID);
            if (null != user)
            {
                user.FirstName = userModel.FirstName;
                user.MiddleName = userModel.MiddleName;
                user.LastName = userModel.LastName;
                user.GPA = userModel.GPA;
                user.YearsInSchool = userModel.YearsInSchool;
                user.EmailAddress = userModel.EmailAddress;
                context.SaveChanges();
            }


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