using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Data.Entities;
using Lab5.Data;

namespace Lab5.Repositories
{
    public class CarRepository : ICarRepository
    {
        public CarRepository(SubDbContext context)
        {
            this.context = context;
        }

        public void DeleteCar(int id)
        {
            Car toRemove = context.Cars.Find(id);
            context.Cars.Remove(toRemove);
            context.SaveChanges();
        }

        public Car GetCar(int id)
        {
            return context.Cars.Find(id);
        }

        public IEnumerable<Car> GetCarsFromUser(int userId)
        {
            List<Car> cars = new List<Car>();
            foreach (Car car in context.Cars)
            {
                if (car.UserID == userId)
                {
                    cars.Add(car);
                }
            }

            return cars;
        }

        public void SaveCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            Car toUpdate = context.Cars.Find(car.ID);
            if (null == toUpdate)
            {
                return;
            }

            toUpdate.Color = car.Color;
            toUpdate.LicensePlateNumber = car.LicensePlateNumber;
            toUpdate.UserID = car.UserID;
            context.SaveChanges();
        }

        private SubDbContext context;
    }
}