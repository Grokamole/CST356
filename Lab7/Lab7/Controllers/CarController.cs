using System.Web.Mvc;
using Lab7.Models.View;
using Lab7.Services;
using System;
using System.Linq;
using System.Data.Entity;

namespace Lab7.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService service;        
        public CarController(ICarService service)
        {
            this.service = service;
        }

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

            service.SaveCar(newCar);

            return RedirectToAction("ShowCarsList", new { userID = newCar.UserID });
        }

        public ActionResult Details(int ID)
        {
            CarViewModel car = service.GetCarDetails(ID);
            if (null == car)
            {
                return RedirectToAction("ShowCarsList");
            }
            return View(car);
        }

        public ActionResult Delete(int ID, int userID)
        {
            service.DeleteCar(ID);
            return RedirectToAction("ShowCarsList", new { userID });
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CarViewModel car = service.GetCar(ID);
            if (null == car)
            {
                return RedirectToAction("ShowCarsList");
            }

            return View(car);
        }

        [HttpPost]
        public ActionResult Edit(CarViewModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            CarViewModel car = service.GetCar(carModel.ID);

            if (null != car)
            {
                car.Color = carModel.Color;
                car.ID = carModel.ID;
                car.LicensePlateNumber = carModel.LicensePlateNumber;
                service.UpdateCar(car);
            }

            return RedirectToAction("ShowCarsList", new { userID = carModel.UserID });
        }

        public ActionResult ShowCarsList(int userID)
        {
            ViewBag.userID = userID;
            return View(service.GetCarsForUser(userID));
        }

        public ActionResult ShowCarsListFilterColor(int userID, String colorString)
        {
            ViewBag.userID = userID;
            if (!String.IsNullOrEmpty(colorString))
            {
                return View(service.GetCarsForUserByColor(userID, colorString));
            }
            return View(service.GetCarsForUser(userID));
        }
    }
}