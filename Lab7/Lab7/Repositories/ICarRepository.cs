using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab7.Data.Entities;
namespace Lab7.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(int id);
        IEnumerable<Car> GetCarsFromUser(int userId);
        void SaveCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}