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
        

        [HttpGet("reservations/ApproveReservation/{id}")]
        public async Task<IActionResult> ApproveReservation(int id, bool approve = false)
        {
            await reservationManager.ApproveReservation(id, approve);
            return Redirect("/Index");
        }
    }
}