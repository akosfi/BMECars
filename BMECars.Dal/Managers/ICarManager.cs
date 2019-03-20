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
        List<CarDTO> GetCars(SearchDTO queryCar);

        CarHeaderDTO GetCarHeader(int id);

        List<string> GetAvailableCarBrands();

    }
}
