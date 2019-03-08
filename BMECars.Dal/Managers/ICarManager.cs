using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMECars.Dal.Managers
{
    public interface ICarManager
    {
        IQueryable<CarDTO> GetCars();
    }
}
