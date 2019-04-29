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
    public class CarsController : Controller
    {
        BMECarsDbContext _context;
        public CarsController(BMECarsDbContext bmeCarsDbContext)
        {
            _context = bmeCarsDbContext;
        }
        public async Task<IActionResult> Remove(int id)
        {
            var reservationsToDelete = await _context.Reservations.Where(r => r.CarId == id).ToListAsync();
            foreach(Reservation r in reservationsToDelete)
            {
                _context.Reservations.Remove(r);
            }
            Car car = await _context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(car != null)
                _context.Cars.Remove(car);

            await _context.SaveChangesAsync();
            return Ok(id);
        }
    }
}