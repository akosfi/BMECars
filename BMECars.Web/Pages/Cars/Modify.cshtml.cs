using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMECars.Web.Pages.Cars
{
    public class ModifyModel : PageModel
    {
        public CarDTO Car { get; set; }

        [BindProperty]
        public InputCar InputCar { get; set; }
        [BindProperty]
        public IFormFile ImageOfCar { get; set; }
        

        public IEnumerable<SelectListItem> AllCarBrandList { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }


        ICarManager carManager;
        ILocationManager locationManager;
        private IHostingEnvironment environment;

        public ModifyModel(
            ICarManager _carManager,
            ILocationManager _locationManager,
            IHostingEnvironment _environment
            )
        {
            carManager = _carManager;
            locationManager = _locationManager;
            environment = _environment;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            await InitCar(id);
            if (Car == null)
            {
                return Redirect("/profile");
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(ImageOfCar != null)
            {
                var file = Path.Combine("uploads", ImageOfCar.FileName);

                using (var fileStream = new FileStream(Path.Combine(environment.ContentRootPath, "wwwroot\\", file), FileMode.Create))
                {
                    await ImageOfCar.CopyToAsync(fileStream);
                }
                file = "/" + file;

                InputCar.Image = file;
            }

            await InitCar((int)InputCar.Id);
            if (ModelState.IsValid)
            {
                await carManager.UpdateCar(Car.Id, InputCar);
                return Redirect("/companies/cars/" + InputCar.CompanyId);
            }
            return Page();
        }

        public async Task InitCar(int id)
        {
            Car = await carManager.GetCar(id);
            AllCarBrandList = (await carManager.GetAllCarBrands()).Select(b => new SelectListItem
            {
                Text = b,
                Value = b,
                Selected = (b == Car.Brand)
            });

            AvailableCategories = Enum.GetValues(typeof(Category)).OfType<Category>().ToList().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = c.ToString(),
                Selected = (c == Car.Category)
            });
            
            Locations = (await locationManager.GetAvaiableLocationsForCompany(Car.CompanyId)).Select(c => new SelectListItem
            {
                Text = c.Country + ", " + c.City + ", " + c.Address,
                Value = c.Id.ToString(),
                Selected = (c.Id == Car.PickUpLocationId)
            });


        }
    }
}