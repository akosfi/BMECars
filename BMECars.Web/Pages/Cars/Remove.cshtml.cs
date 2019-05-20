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
    public class RemoveModel : PageModel
    {
        public CarDTO Car { get; set; }
        public List<ReservationDTO> ReservationsForCar { get; set; }

        ICarManager carManager;
        IReservationManager reservationManager;
        public RemoveModel(
            ICarManager _carManager,
            IReservationManager _reservationManager
        )
        {
            carManager = _carManager;
            reservationManager = _reservationManager;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Car = await carManager.GetCar(id);
            ReservationsForCar = (await reservationManager.GetReservationsForCar(Car.Id))
                                 .Where(r => r.ReserveFrom > DateTime.Now)
                                 .ToList();
            return Page();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            CarDTO car = await carManager.GetCar(id);
            if(car == null)
            {
                return Redirect("/profile");
            }

            await carManager.RemoveCar(id);

            return Redirect("/companies/cars/" + car.CompanyId);
        }
    }
}