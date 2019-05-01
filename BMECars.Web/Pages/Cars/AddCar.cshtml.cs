using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMECars.Web.Pages.Cars
{
    public class AddCarModel : PageModel
    {
        public IEnumerable<SelectListItem> CompaniesForUser { get; set; }
        public IEnumerable<SelectListItem> AllCarBrandList { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
        public IEnumerable<SelectListItem> AllCountries { get; set; }

        [BindProperty]
        public InputCar InputCar { get; set; }
        [BindProperty]
        public IFormFile ImageOfCar { get; set; }


        ICarManager carManager;
        ICompanyManager companyManager;
        UserManager<User> userManager;
        ILocationManager locationManager;

        private IHostingEnvironment environment;

        public AddCarModel(
            ICarManager _carManager, 
            UserManager<User> _userManager, 
            ICompanyManager _companyManager,
            ILocationManager _locationManager,
            IHostingEnvironment _environment)
        {
            carManager = _carManager;
            userManager = _userManager;
            companyManager = _companyManager;
            locationManager = _locationManager;
            environment = _environment;
        }

        public async Task OnGet() {            
            await setDropDowns();
        }

        public async Task<IActionResult> OnPostAsync(IList<CarInvidual> inviduals)
        {
            var file = Path.Combine("uploads", ImageOfCar.FileName);

            using (var fileStream = new FileStream(Path.Combine(environment.ContentRootPath, "wwwroot\\", file), FileMode.Create))
            {
                await ImageOfCar.CopyToAsync(fileStream);
            }
            file = "/" + file;
            

            if (ModelState.IsValid)
            {
                Company selectedCompany = await companyManager.GetCompany(InputCar.CompanyId);
                if(selectedCompany == null)
                {
                    ModelState.AddModelError("NoCompany", "Company not found.");

                    await setDropDowns();
                    return Page();
                }
                foreach(CarInvidual ci in inviduals)
                {
                    await carManager.AddNewCarAsync(new Car
                    {
                        Brand = InputCar.Brand,
                        Price = (int)InputCar.Price,
                        Image = file,
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
                            Country = InputCar.Country,
                            City = InputCar.City,
                            Address = InputCar.Address,
                            Company = selectedCompany,
                            IsGlobal = false
                        }
                    });
                }
                
                return RedirectToPage("/");
            }
            await setDropDowns();
            return Page();
        }


        private async Task setDropDowns()
        {
            User user = await userManager.GetUserAsync(HttpContext.User);
            CompaniesForUser = companyManager.GetCompaniesForUser(user.Id).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            AllCarBrandList = (await carManager.GetAllCarBrands()).Select(b => new SelectListItem
            {
                Text = b,
                Value = b
            });

            AvailableCategories = Enum.GetValues(typeof(Category)).OfType<Category>().ToList().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = c.ToString()
            });

            AllCountries = locationManager.GetAllCountries().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = c.ToString()
            });
        }


        public class CarInvidual
        {
            [Required(ErrorMessage = "'Plate' can't be empty.")]
            public string Plate { get; set; }
        }
    }
    
}