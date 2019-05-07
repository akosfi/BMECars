using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public class ReservationManager : IReservationManager
    {
        BMECarsDbContext _context;
        ICarManager carManager;
        ILocationManager locationManager;
        UserManager<User> userManager;
        public ReservationManager(
            BMECarsDbContext BMECarsDbContext, 
            ICarManager _carManager, 
            ILocationManager _locationManager,
            UserManager<User> _userManager)
        {
            _context = BMECarsDbContext;
            carManager = _carManager;
            locationManager = _locationManager;
            userManager = _userManager;
        }

        public async Task MakeReservation(SearchDTO car)
        {
            List<int> avaibleCarIds = carManager.GetCars(car).Select(c => c.Id).ToList();
            
            if (avaibleCarIds.Contains(car.Id))
            {
                HttpContext.
                LocationDTO pickUpLocation = await locationManager.GetLocationByAddress(car.CountryPickUp, car.CityPickUp, car.LocationPickUp);
                LocationDTO dropDownLocation = await locationManager.GetLocationByAddress(car.CountryDropDown, car.CityDropDown, car.LocationDropDown);
                await _context.AddAsync(new Reservation {
                    CarId = car.Id,
                    ReservationPrice = car.Price,
                    ReserveFrom = car.ReserveFrom,
                    ReserveTo = car.ReserveTo,
                    PickUpLocationId = pickUpLocation.Id,
                    DropDownLocationId = dropDownLocation.Id,
                    UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd"
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
