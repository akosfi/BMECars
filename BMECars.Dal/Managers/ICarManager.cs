﻿using BMECars.Dal.DTOs;
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
        Task<CarDTO> GetCar(int id);

        List<CarDTO> GetCars(SearchDTO queryCar);

        Task UpdateCar(int id, InputCar inputCar);

        CarHeaderDTO GetCarHeader(int id);

        List<string> GetAvailableCarBrands();

        Task<List<string>> GetAllCarBrands();

        List<CarDTO> GetCarsForCompany(int companyId);

        ReservationInfoDTO GetReservationInfoForCar(int carId);

        Task AddNewCarAsync(Car c);

        Task RemoveCar(int id);
    }
}
