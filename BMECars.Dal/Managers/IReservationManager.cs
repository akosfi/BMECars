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
    }
}
