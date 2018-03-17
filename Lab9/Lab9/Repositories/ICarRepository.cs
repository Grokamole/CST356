using System.Collections.Generic;
using Lab9.Data.Entities;
namespace Lab9.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(int id);
        IEnumerable<Car> GetCarsFromUser(int userId);
        IEnumerable<Car> GetAllCars();
        void SaveCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}