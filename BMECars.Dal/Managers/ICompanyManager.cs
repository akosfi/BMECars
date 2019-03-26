using BMECars.Dal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Managers
{
    public interface ICompanyManager
    {
        List<CompanyHeaderDTO> GetCompaniesForUser(string userID);
    }
}
