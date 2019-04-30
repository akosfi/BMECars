using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal;
using BMECars.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMECars.Web.Controllers
{
    public class CompanyController : Controller
    {
        BMECarsDbContext _context;
        public CompanyController(BMECarsDbContext bmeCarsDbContext)
        {
            _context = bmeCarsDbContext;
        }
        public async Task<IActionResult> Remove(int id)
        {
            var companyCars = await _context.Cars.Where(c => c.CompanyId == id).ToListAsync();

            foreach(Car car in companyCars)
            {
                var reservationsToDelete = await _context.Reservations.Where(r => r.CarId == car.Id).ToListAsync();
                foreach (Reservation r in reservationsToDelete)
                {
                    _context.Reservations.Remove(r);
                }

                _context.Cars.Remove(car);
            }

            var companyLocations = await _context.Locations
                                                 .Where(c => c.CompanyId == id && c.IsGlobal == false)
                                                 .ToListAsync();
            foreach (Location location in companyLocations)
            {
                _context.Locations.Remove(location);
            }

            var company = await _context.Companies.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(company != null)
                _context.Companies.Remove(company);

            await _context.SaveChangesAsync();
            return Ok(id);
        }
    }
}