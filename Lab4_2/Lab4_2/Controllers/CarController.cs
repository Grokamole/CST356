using System.Collections.Generic;
using System.Web.Mvc;
using Lab4_2.Data.Entities;
using Lab4_2.Models.View;
using Lab4_2.Data;

namespace Lab4_2.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public ActionResult Create(int userID)
        {
            ViewBag.userID = userID;

            return View();
        }

        [HttpPost]
        public ActionResult Create(CarViewModel newCar)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Car car = MapToCar(newCar);

            SubDbContext context = new SubDbContext();
            context.Cars.Add(car);
            context.SaveChanges();

            return RedirectToAction("ShowCarsList", new { UserID = newCar.UserID });
        }

        public ActionResult ShowCarsList(int userID)
        {
            SubDbContext db = new SubDbContext();

            List<CarViewModel> models = new List<CarViewModel>();

            foreach (Car car in db.Cars)
            {
                if (car.UserID == userID)
                {
                    CarViewModel model = MapToCarViewModel(car);
                    models.Add(model);
                }
            }

            return View(models);
        }

        private Car MapToCar(CarViewModel inputCar)
        {
            Car outputCar = new Car();

            outputCar.ID = inputCar.ID;
            outputCar.Color = inputCar.Color;
            outputCar.LicensePlateNumber = inputCar.LicensePlateNumber;

            return outputCar;
        }

        private CarViewModel MapToCarViewModel(Car inputCar)
        {
            CarViewModel outputCar = new CarViewModel();

            outputCar.ID = inputCar.ID;
            outputCar.Color = inputCar.Color;
            outputCar.LicensePlateNumber = inputCar.LicensePlateNumber;

            return outputCar;
        }
    }
}