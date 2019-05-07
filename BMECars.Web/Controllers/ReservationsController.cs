using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BMECars.Web.Controllers
{
    public class ReservationsController : Controller
    {
        public IReservationManager reservationManager;
        public ILocationManager locationManager;
        public ReservationsController(
            IReservationManager _reservationManager,
            ILocationManager _locationManager)
        {
            reservationManager = _reservationManager;
            locationManager = _locationManager;
        }
        
        [HttpGet("reservations/MakeReservation/{id}")]
        public async Task<IActionResult> MakeReservation(int id, int pickUp, int dropDown, DateTime reserveFrom, DateTime reserveTo)
        {

            LocationDTO pickUpLocation = await locationManager.GetLocation(pickUp);
            LocationDTO dropDownLocation = await locationManager.GetLocation(dropDown);
            await reservationManager.MakeReservation(new SearchDTO
            {
                Id = id,
                ReserveFrom = reserveFrom,
                ReserveTo = reserveTo,
                CountryPickUp = pickUpLocation.Country,
                CityPickUp = pickUpLocation.City,
                LocationPickUp = pickUpLocation.Address,
                CountryDropDown = dropDownLocation.Country,
                CityDropDown = dropDownLocation.City,
                LocationDropDown = dropDownLocation.Address
            });
            return Redirect("/Index");
        }
    }
}