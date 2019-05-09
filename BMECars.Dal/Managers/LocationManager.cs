using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public class LocationManager : ILocationManager
    {
        BMECarsDbContext _context;
        public LocationManager(BMECarsDbContext BMECarsDbContext)
        {
            _context = BMECarsDbContext;
        }

        public async Task<LocationDTO> GetLocation(int id)
        {
            return await _context.Locations
                                 .Where(l => l.Id == id)
                                 .Select(l => new LocationDTO {
                                     Id = l.Id,
                                     Address = l.Address,
                                     City = l.City,
                                     Country = l.Country,
                                     IsGlobal = l.IsGlobal
                                 })
                                 .FirstOrDefaultAsync();
        }

        public async Task<LocationDTO> GetLocationByAddress(string country, string city, string address)
        {
            return await _context.Locations
                                 .Where(l => l.Country == country && l.City == city && l.Address == address)
                                 .Select(l => new LocationDTO
                                 {
                                     Id = l.Id,
                                     Address = l.Address,
                                     City = l.City,
                                     Country = l.Country,
                                     IsGlobal = l.IsGlobal
                                 })
                                 .FirstOrDefaultAsync();
        }

        public List<string> GetAvailableCountries()
        {
            return _context.Locations.Select(l => l.Country).Distinct().ToList();
        }

        public List<string> GetAllCountries()
        {
            using (var reader = File.OpenText("../BMECars.DAL/Static/CountryList.txt"))
            {
                var fileText = reader.ReadToEnd();
                return fileText.Split('\n').Select(p => p.Trim()).ToList();
            }
        }
        
        public List<string> GetAvailableCities(string qCountry)
        {
            return _context.Locations
                .Where(l => l.Country == qCountry)
                .Select(l => l.City)
                .Distinct().ToList();
        }

        public List<string> GetAvaiableLocations(string qCountry, string qCity)
        {
            return _context.Locations
                .Where(l => l.City == qCity && l.Country == qCountry)
                .Select(l => l.Address)
                .Distinct().ToList();
        }

        public List<string> GetDealerName(string partOfName)
        {
            return _context.Companies.Where(c => c.Name.Contains(partOfName)).Select(c => c.Name).ToList();
        }

        public async Task AddLocation(LocationDTO location)
        {
            await _context.Locations
                           .AddAsync(new Location
                           {
                               Country = location.Country,
                               City = location.City,
                               Address = location.Address,
                               IsGlobal = location.IsGlobal,
                               CompanyId = location.CompanyId                  
                           });

            await _context.SaveChangesAsync();
        }

        public async Task<List<LocationDTO>> GetAvaiableLocationsForCompany(int id)
        {
            return await _context.Locations
                                 .Where(l => l.CompanyId == id || l.IsGlobal == true)
                                 .Select(l => new LocationDTO
                                 {
                                     Id = l.Id,
                                     Country = l.Country,
                                     City = l.City,
                                     Address = l.Address,
                                     IsGlobal = l.IsGlobal,
                                     CompanyId = (int)l.CompanyId
                                 })
                                 .ToListAsync();
        }
    }
}
