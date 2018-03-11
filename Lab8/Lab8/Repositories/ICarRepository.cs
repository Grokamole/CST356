using System.Collections.Generic;
using Lab8.Data.Entities;
namespace Lab8.Repositories
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