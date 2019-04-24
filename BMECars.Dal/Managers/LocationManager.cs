using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BMECars.Dal.Managers
{
    public class LocationManager : ILocationManager
    {
        BMECarsDbContext _context;
        public LocationManager(BMECarsDbContext BMECarsDbContext)
        {
            _context = BMECarsDbContext;
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
    }
}
