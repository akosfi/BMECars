using System;
using System.Collections.Generic;
using System.Text;
using BMECars.Dal.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BMECars.Dal.Entities;
using System.Threading.Tasks;

namespace BMECars.Dal.Managers
{
    public class CompanyManager : ICompanyManager
    {
        BMECarsDbContext _context;
        public CompanyManager(BMECarsDbContext BMECarsDbContext)
        {
            _context = BMECarsDbContext;
            
        }

        public CompanyHeaderDTO GetCompanyHeader(int companyId)
        {
            return _context.Companies
                .Where(c => c.Id == companyId)
                .Select(c => new CompanyHeaderDTO {
                    Id = c.Id,
                    Name = c.Name,
                    UserId = c.UserId
                })
                .First();
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await _context.Companies
                .Where(c => c.Id == companyId)
                .FirstOrDefaultAsync();
        }

        public List<CompanyHeaderDTO> GetCompaniesForUser(string userID)
        {
            return _context.Companies
                .Where(c => c.UserId == userID)
                .Select(c => new CompanyHeaderDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    UserId = userID
                }).ToList();
        }
    }
}
