using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models.View;

namespace Lab5.Services
{
    public interface ICarService
    {
        CarViewModel GetCar(int ID);

        CarViewModel GetCarDetails(int ID);

        IEnumerable<CarViewModel> GetCarsForUser(int userID);

        void SaveCar(CarViewModel car);

        void UpdateCar(CarViewModel car);

        void DeleteCar(int ID);

        IEnumerable<CarViewModel> GetCarsForUserByColor(int userID, String color);
    }
}