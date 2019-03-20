using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Managers
{
    public interface ILocationManager
    {
        List<String> GetAvailableCountries();

        List<string> GetAvailableCities(string qCountry);

        List<string> GetAvaiableLocations(string country, string qCity);

        List<string> GetDealerName(string partOfName);
    }
}
