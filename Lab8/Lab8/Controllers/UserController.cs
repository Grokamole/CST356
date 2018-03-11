using System.Web.Mvc;
using Lab8.Models.View;
using Lab8.Services;

namespace Lab8.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

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

            service.SaveUser(newUser);

            return RedirectToAction("ShowUsersList");
        }
        
        public ActionResult Details(int ID)
        {
            UserViewModel user = service.GetUser(ID);
            if (null == user)
            {
                return RedirectToAction("ShowUsersList");
            }

            return View(user);
        }

        public ActionResult Delete(int ID)
        {
            service.DeleteUser(ID);
            return RedirectToAction("ShowUsersList");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            UserViewModel user = service.GetUser(ID);
            if (null == user)
            {
                return RedirectToAction("ShowUsersList");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            UserViewModel user = service.GetUser(userModel.ID);

            if (null != user)
            {
                user.FirstName = userModel.FirstName;
                user.MiddleName = userModel.MiddleName;
                user.LastName = userModel.LastName;
                user.GPA = userModel.GPA;
                user.YearsInSchool = userModel.YearsInSchool;
                user.EmailAddress = userModel.EmailAddress;
                service.UpdateUser(user);
            }

            return RedirectToAction("ShowUsersList");
        }

        public ActionResult ShowUsersList()
        {
            return View(service.GetAllUsers());
        }

        /* public ActionResult Error()
         {
             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
         }*/
    }
}