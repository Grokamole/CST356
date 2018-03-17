using System.Collections.Generic;
using System.Web.Http;
using Lab9.Services;
using Lab9.Models.View;

namespace TheAppAPI.Controllers
{
    public class CarController : ApiController
    {
        private ICarService service;
        public CarController(ICarService service)
        {
            this.service = service;
        }

        public IEnumerable<CarViewModel> GetAllCars()
        {
            return service.GetAllCars();
        }

        public IHttpActionResult GetCar(int id)
        {
            CarViewModel car = service.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
    }
}
