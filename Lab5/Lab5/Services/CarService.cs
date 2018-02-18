using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models.View;
using Lab5.Repositories;
using Lab5.Data.Entities;

namespace Lab5.Services
{
    public class CarService : ICarService
    {
        ICarRepository repository;
        public CarService(ICarRepository repository)
        {
            this.repository = repository;
        }

        public void DeleteCar(int ID)
        {
            repository.DeleteCar(ID);
        }

        public CarViewModel GetCar(int ID)
        {
            return MapToCarViewModel(repository.GetCar(ID));
        }

        public CarViewModel GetCarDetails(int ID)
        {
            CarViewModel car = GetCar(ID);

            switch (car.Color.ToLower())
            {
                case "green":
                    {
                        car.Color = "<font color=\"#196f3d\">Green</font>";
                    }
                    break;
                case "red":
                    {
                        car.Color = "<font color=\"#c0392b\">Red</font>";
                    }
                    break;
                case "gray":
                    {
                        car.Color = "<font color=\"#566573\">Gray</font>";
                    }
                    break;
                case "blue":
                    {
                        car.Color = "<font color=\"#2980b9\">Blue</font>";
                    }
                    break;
                case "pink":
                    {
                        car.Color = "<font color=\"#f1948a\">Pink</font>";
                    }
                    break;
                case "purple":
                    {
                        car.Color = "<font color=\"#196f3d\">8e44ad</font>";
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
            return car;
        }

        public IEnumerable<CarViewModel> GetCarsForUser(int userID)
        {
            List<CarViewModel> model = new List<CarViewModel>();

            foreach(Car car in repository.GetCarsFromUser(userID))
            {
                model.Add(MapToCarViewModel(car));
            }

            return model;
        }

        public void SaveCar(CarViewModel car)
        {
            repository.SaveCar(MapToCar(car));
        }

        public void UpdateCar(CarViewModel car)
        {
            repository.UpdateCar(MapToCar(car));
        }

        public IEnumerable<CarViewModel> GetCarsForUserByColor(int userID, String color)
        {
            List<CarViewModel> model = new List<CarViewModel>();

            foreach(Car car in repository.GetCarsFromUser(userID))
            {
                if (car.Color == color)
                {
                    model.Add(MapToCarViewModel(car));
                }
            }

            return model;
        }

        private Car MapToCar(CarViewModel inputCar)
        {
            Car outputCar = new Car();

            outputCar.ID = inputCar.ID;
            outputCar.Color = inputCar.Color;
            outputCar.LicensePlateNumber = inputCar.LicensePlateNumber;
            outputCar.UserID = inputCar.UserID;

            return outputCar;
        }

        private CarViewModel MapToCarViewModel(Car inputCar)
        {
            CarViewModel outputCar = new CarViewModel();

            outputCar.ID = inputCar.ID;
            outputCar.Color = inputCar.Color;
            outputCar.LicensePlateNumber = inputCar.LicensePlateNumber;
            outputCar.UserID = inputCar.UserID;
            return outputCar;
        }
    }
}