using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public interface ICompanyManager
    {
        List<CompanyHeaderDTO> GetCompaniesForUser(string userID);

        CompanyHeaderDTO GetCompanyHeader(int companyId);

        Task<Company> GetCompany(int companyId);
    }
}
