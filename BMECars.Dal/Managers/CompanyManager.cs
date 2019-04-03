using System;
using System.Collections.Generic;
using System.Text;
using BMECars.Dal.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BMECars.Dal.Managers
{
    public class CompanyManager : ICompanyManager
    {
        BMECarsDbContext _context;
        public CompanyManager(BMECarsDbContext BMECarsDbContext)
        {
            _context = BMECarsDbContext;
            
        }

        public CompanyHeaderDTO GetCompany(int companyId)
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
