using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMECars.Web.Pages.Companies
{
    public class LocationsModel : PageModel
    {
        public List<LocationDTO> CompanyLocations { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> AllCountries { get; set; }

        [BindProperty]
        public LocationDTO InputLocation { get; set; }

        ICompanyManager companyManager;
        ILocationManager locationManager;
        public LocationsModel(
            ICompanyManager _companyManager,
            ILocationManager _locationManager
            )
        {
            companyManager = _companyManager;
            locationManager = _locationManager;
            AllCountries = locationManager.GetAllCountries().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = c.ToString()
            });
        }

        public async Task OnGet(int id)
        {
            CompanyId = id;
            CompanyLocations = await companyManager.GetLocations(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Redirect("/companies/locations/" + InputLocation.CompanyId);
            Console.WriteLine(InputLocation.Country + "-----------------------" + InputLocation.CompanyId );   
            await locationManager.AddLocation(InputLocation);

            return Redirect("/companies/locations/" + InputLocation.CompanyId);

        }
    }
}