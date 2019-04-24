using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMECars.Web.Pages
{
    public class AddCarModel : PageModel
    {
        public IEnumerable<SelectListItem> CompaniesForUser { get; set; }
        public IEnumerable<SelectListItem> AllCarBrandList { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
        public IEnumerable<SelectListItem> AllCountries { get; set; }

        [BindProperty]
        public InputCar InputCar { get; set; }

        ICarManager carManager;
        ICompanyManager companyManager;
        UserManager<User> userManager;
        ILocationManager locationManager;

        public AddCarModel(
            ICarManager _carManager, 
            UserManager<User> _userManager, 
            ICompanyManager _companyManager,
            ILocationManager _locationManager)
        {
            carManager = _carManager;
            userManager = _userManager;
            companyManager = _companyManager;
            locationManager = _locationManager;
        }

        public async void OnGet() {
            User user = await userManager.GetUserAsync(HttpContext.User);
            CompaniesForUser = companyManager.GetCompaniesForUser(user.Id).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            AllCarBrandList = (await carManager.GetAllCarBrands()).Select(b => new SelectListItem {
                Text = b,
                Value = b
            });

            AvailableCategories = Enum.GetValues(typeof(Category)).OfType<Category>().ToList().Select(c => new SelectListItem {
                Text = c.ToString(),
                Value = c.ToString()
            });
            
            AllCountries = locationManager.GetAllCountries().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = c.ToString()
            });

        }

        public async Task<IActionResult> OnPostAsync(IList<CarInvidual> inviduals)
        {
            foreach (CarInvidual ci in inviduals)
            {
                Console.WriteLine(ci.Plate);
            }
            if (ModelState.IsValid)
            {
                Company selectedCompany = await companyManager.GetCompany(InputCar.CompanyId);
                if(selectedCompany == null)
                {
                    ModelState.AddModelError("NoCompany", "Company not found.");
                    return Page();
                }
                foreach(CarInvidual ci in inviduals)
                {
                    await carManager.AddNewCarAsync(new Car
                    {
                        Brand = InputCar.Brand,
                        Price = (int)InputCar.Price,
                        IsFuelFull = (bool)InputCar.IsFuelFull,
                        Seat = (int)InputCar.Seat,
                        Year = (int)InputCar.Year,
                        Door = (int)InputCar.Door,
                        Transmission = (Transmission)InputCar.Transmission,
                        Climate = (bool)InputCar.Climate,
                        Category = (Category)InputCar.Category,
                        Bag = (int)InputCar.Bag,
                        Company = selectedCompany,
                        Plate = ci.Plate,
                        PickUpLocation = new Location {
                            Country = ci.Country,
                            City = ci.City,
                            Address = ci.PickUp,
                            Company = selectedCompany,
                            IsGlobal = false
                        }
                    });
                }
                
                return RedirectToPage("/");
            }
            return Page();
        }
        public class CarInvidual
        {
            [Required(ErrorMessage = "'Plate' can't be empty.")]
            public string Plate { get; set; }

            [Required(ErrorMessage = "'Country' can't be empty.")]
            public string Country { get; set; }

            [Required(ErrorMessage = "'City' can't be empty.")]
            public string City { get; set; }

            [Required(ErrorMessage = "'Pick Up' can't be empty.")]
            public string PickUp { get; set; }
        }
    }
    
}