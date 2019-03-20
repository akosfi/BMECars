using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BMECars.Dal.DTOs;

namespace BMECars.Web.Pages
{
    public class IndexModel : PageModel
    {
        ICarManager _carManager;
        public List<CarHeaderDTO> CarHeaders { get; set; }
        public SearchDTO SearchCar { get; set; } = new SearchDTO();
        public IndexModel(ICarManager CarManager)
        {
            _carManager = CarManager;
            CarHeaders = new List<CarHeaderDTO>();
        }


        public void OnGet()
        {
            CarHeaders.Add(_carManager.GetCarHeader(1));
            CarHeaders.Add(_carManager.GetCarHeader(2));
            CarHeaders.Add(_carManager.GetCarHeader(3));
        }
    }
}
