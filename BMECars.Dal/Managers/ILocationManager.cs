using BMECars.Dal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public interface ILocationManager
    {
        Task<LocationDTO> GetLocation(int id);

        Task<LocationDTO> GetLocationByAddress(string country, string city, string address);

        List<string> GetAvailableCountries();

        List<string> GetAllCountries();

        List<string> GetAvailableCities(string qCountry);

        List<string> GetAvaiableLocations(string country, string qCity);

        List<string> GetDealerName(string partOfName);
    }
}
