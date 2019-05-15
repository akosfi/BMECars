using BMECars.Dal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public interface IReservationManager
    {
        Task MakeReservation(SearchDTO car);

        Task<List<ReservationDTO>> GetPendingReservationsForCompany(int id);

        Task ApproveReservation(int id, bool approve = false);

        Task<List<ReservationDTO>> GetReservationsForUser(string userId);
    }
}
