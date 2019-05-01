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
    public class PaymentModel : PageModel
    {
        public CarDTO Car { get; set; }
        public string ReserveFrom { get; set; }
        public string ReserveTo { get; set; }
        public int TotalPrice { get; set; }

        ICarManager carManager;
        ILocationManager locationManager;
        public PaymentModel(
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


            DateTime dateFrom = new DateTime(Int32.Parse(ReserveFrom.Split(". ")[0]), Int32.Parse(ReserveFrom.Split(". ")[1]), Int32.Parse(ReserveFrom.Split(". ")[2]));
            DateTime dateTo = new DateTime(Int32.Parse(ReserveTo.Split(". ")[0]), Int32.Parse(ReserveTo.Split(". ")[1]), Int32.Parse(ReserveTo.Split(". ")[2]));

            TotalPrice = ((int)Math.Abs((dateFrom - dateTo).TotalDays) + 1) * Car.Price;
        }
    }
}