using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages.Companies
{
    public class PendingReservationsModel : PageModel
    {
        public List<ReservationDTO> PendingReservations { get; set; }
        public LocationDTO PickUpLocation { get; set; }
        public LocationDTO DropDownLocation { get; set; }

        IReservationManager reservationManager;
        ILocationManager locationManager;
        public PendingReservationsModel(
            IReservationManager _reservationManager,
            ILocationManager _locationManager
            )
        {
            reservationManager = _reservationManager;
            locationManager = _locationManager;
        }
        public async Task OnGet(int id)
        {
            PendingReservations = await reservationManager.GetPendingReservationsForCompany(id);
            //PickUpLocation = await locationManager.GetLocation()
        }
    }
}