using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages.Cars
{
    public class SearchModel : PageModel
    {
        ICarManager carManager;
        ILocationManager locationManager;
        public SearchModel(ICarManager _carManager, ILocationManager _locationManager)
        {
            carManager = _carManager;
            locationManager = _locationManager;
        }

        public List<CarDTO> Cars { get; set; }
        public SearchDTO SearchCar { get; set; }
        public LocationDTO PickUpLocation { get; set; }
        public LocationDTO DropDownLocation { get; set; }
        public async Task OnGet(SearchDTO queryCar)
        {
            SearchCar = queryCar;

            Cars = carManager.GetCars(queryCar);
            PickUpLocation = await locationManager.GetLocationByAddress(queryCar.CountryPickUp, queryCar.CityPickUp, queryCar.LocationPickUp);
            DropDownLocation = await locationManager.GetLocationByAddress(queryCar.CountryDropDown, queryCar.CityDropDown, queryCar.LocationDropDown);

            Console.WriteLine("++++++++++++++++++++++++"+(new DateTime()).ToString());

            if (DropDownLocation == null)
                DropDownLocation = PickUpLocation;
        }
    }
}