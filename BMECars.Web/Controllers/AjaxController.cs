using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BMECars.Web.Controllers
{
    [Produces("application/json")]
    public class AjaxController : Controller
    {
        ILocationManager locationManager;
        BMECarsDbContext _context;
        public AjaxController(ILocationManager locationManager, BMECarsDbContext dbContext)
        {
            this.locationManager = locationManager;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            return Ok("Index");
        }

        public IActionResult GetCountries()
        {
            return Ok(locationManager.GetAvailableCountries());
        }
        
        public IActionResult GetCities(string country)
        {
            return Ok(locationManager.GetAvailableCities(country));
        }

        public IActionResult GetLocations(string country, string city)
        {
            return Ok(locationManager.GetAvaiableLocations(country, city));
        }

        public IActionResult GetDealerName(string partOfName)
        {
            return Ok(locationManager.GetDealerName(partOfName));
        }


        public IActionResult GetReservationsForCar(int carId)
        {
            var reservations = _context
                .Reservations
                .Where(r => r.CarId == carId)
                .Select(r => new {
                    StartDate = r.ReserveFrom,
                    EndDate = r.ReserveTo
                });

            return Ok(reservations.ToList());
        }
    }
}