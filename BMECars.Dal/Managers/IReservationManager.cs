using BMECars.Dal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public interface IReservationManager
    {
        Task MakeReservation(PaymentDTO car);
        Task ApproveReservation(int id, bool approve = false);
        Task AddBillingData(BillingDataDTO billingData);

        Task<BillingDataDTO> GetBillingData(int id);

        Task<List<BillingDataDTO>> GetBillingDatasForUser(string userId);

        Task<List<ReservationDTO>> GetReservationsForCar(int id);
        Task<List<ReservationDTO>> GetReservationsForUser(string userId);
        Task<List<ReservationDTO>> GetPendingReservationsForCompany(int id);
    }
}
