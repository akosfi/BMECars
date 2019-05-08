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

        Task<CompanyHeaderDTO> GetCompanyHeader(int companyId);

        Task<List<LocationDTO>> GetLocations(int id);

        Task<List<UserHeaderDTO>> GetCompanyAdmins(int companyId);

        Task<Company> GetCompany(int companyId);

        Task AddAdminForCompany(int companyId, string userId);

        Task<bool> IsUserAdminAtCompany(string userId, int companyId);
    }
}
