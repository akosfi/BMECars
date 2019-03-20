using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages
{
    public class SearchModel : PageModel
    {
        ICarManager _carManager;
        public SearchModel(ICarManager CarManager)
        {
            _carManager = CarManager;
        }

        public List<CarDTO> Cars { get; set; }
        public SearchDTO SearchCar { get; set; }
        public void OnGet(SearchDTO queryCar)
        {


            SearchCar = queryCar;
            Cars = _carManager.GetCars(queryCar);
        }
    }
}