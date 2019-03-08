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
    public class SearchModel : PageModel
    {
        ICarManager _carManager;
        public SearchModel(ICarManager CarManager)
        {
            _carManager = CarManager;
        }

        public IQueryable<CarDTO> Cars { get; set; }

        public void OnGet()
        {
            Cars = _carManager.GetCars();
        }
    }
}