using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMECars.Web.Pages.Cars
{
    public class PaymentModel : PageModel
    {
        public CarDTO Car { get; set; }
        public DateTime ReserveFrom { get; set; }
        public DateTime ReserveTo { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropDownLocationId { get; set; }
        public int TotalPrice { get; set; }

        public IEnumerable<SelectListItem> PreviousBillingDatas { get; set; }

        ICarManager carManager;
        ILocationManager locationManager;
        IReservationManager reservationManager;
        public PaymentModel(
            ICarManager _carManager,
            ILocationManager _locationManager,
            IReservationManager _reservationManager)
        {
            carManager = _carManager;
            locationManager = _locationManager;
            reservationManager = _reservationManager;
        }
        public async Task OnGet(int? id, int PickUpLocationId, int DropDownLocationId, DateTime reserveFrom, DateTime reserveTo)
        {
            Car = await carManager.GetCar((int)id);
            ReserveFrom = reserveFrom;
            ReserveTo = reserveTo;

            this.PickUpLocationId = PickUpLocationId;
            this.DropDownLocationId = DropDownLocationId;

            TotalPrice = ((int)Math.Abs((reserveFrom - reserveTo).TotalDays) + 1) * Car.Price;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            PreviousBillingDatas = (await reservationManager.GetBillingDatasForUser(userId)).Select(b => new SelectListItem
            {
                Text = b.FirstName + " " + b.LastName + " " + b.Address + ", " + b.City,
                Value = b.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost(PaymentDTO ReservationDetails)
        {
            BillingDataDTO billingData = await reservationManager.GetBillingData(ReservationDetails.BillingDataId);

            if (billingData == null)
            {
                await reservationManager
                      .AddBillingData(new BillingDataDTO {
                          Address = ReservationDetails.Address,
                          City = ReservationDetails.City,
                          FirstName = ReservationDetails.FirstName,
                          LastName = ReservationDetails.LastName,
                          Country = ReservationDetails.Country,
                          Postal = ReservationDetails.Postal,
                          Company = ReservationDetails.Company,
                          State = ReservationDetails.State
                      });
            }
            await reservationManager.MakeReservation(ReservationDetails);

            return Redirect("/Profile");
        }
    }
}