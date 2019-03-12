using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public interface ICarManager
    {
        IQueryable<CarDTO> GetCars();

        CarHeaderDTO GetCarHeader(int id);
    }
}
