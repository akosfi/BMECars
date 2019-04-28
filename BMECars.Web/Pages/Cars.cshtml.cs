using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages
{
    public class CarsModel : PageModel
    {
        ICarManager _carManager;
        ICompanyManager _companyManager;
        public CarsModel(ICarManager CarManager, ICompanyManager CompanyManager)
        {
            _carManager = CarManager;
            _companyManager = CompanyManager;       
        }
        public CompanyHeaderDTO Company { get; set; }
        public List<CarDTO> Cars { get; set; }

        public Dictionary<int, ReservationInfoDTO> ReservationInfo = new Dictionary<int, ReservationInfoDTO>();

        public async Task OnGet(int companyId)
        {
            Cars = _carManager.GetCarsForCompany(companyId);
            Company = await _companyManager.GetCompanyHeader(companyId);

            foreach(var car in Cars)
            {
                ReservationInfo.Add(car.Id, _carManager.GetReservationInfoForCar(car.Id));
            }
        }
    }
}