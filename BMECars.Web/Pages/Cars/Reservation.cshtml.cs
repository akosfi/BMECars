using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages.Cars
{
    public class ReservationModel : PageModel
    {
        public CarDTO Car { get; set; }
        public string ReserveFrom { get; set; }
        public string ReserveTo { get; set; }
        public LocationDTO PickUpLocation { get; set; }
        public LocationDTO DropDownLocation { get; set; }

        ICarManager carManager;
        ILocationManager locationManager;
        public ReservationModel (
            ICarManager _carManager,
            ILocationManager _locationManager)
        {
            carManager = _carManager;
            locationManager = _locationManager;
        }
        public async Task OnGet(int? id, int pickUp, int dropDown, string reserveFrom, string reserveTo)
        {
            Car = await carManager.GetCar((int)id);
            ReserveFrom = reserveFrom;
            ReserveTo = reserveTo;
            PickUpLocation = await locationManager.GetLocation(pickUp);
            DropDownLocation = await locationManager.GetLocation(dropDown);
        }
    }
}