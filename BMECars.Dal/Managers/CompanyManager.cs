using System;
using System.Collections.Generic;
using System.Text;
using BMECars.Dal.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BMECars.Dal.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BMECars.Dal.Managers
{
    public class CompanyManager : ICompanyManager
    {
        BMECarsDbContext _context;
        UserManager<User> userManager;
        readonly IHttpContextAccessor httpContextAccessor;

        public CompanyManager(
            BMECarsDbContext BMECarsDbContext,
            UserManager<User> _userManager,
            IHttpContextAccessor _httpContextAccessor
        )
        {
            _context = BMECarsDbContext;
            userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<CompanyHeaderDTO> GetCompanyHeader(int companyId)
        {
            return await _context.Companies
                .Where(c => c.Id == companyId)
                .Select(c => new CompanyHeaderDTO {
                    Id = c.Id,
                    Name = c.Name,
                    UserId = c.UserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await _context.Companies
                .Where(c => c.Id == companyId)
                .FirstOrDefaultAsync();
        }

        
        public async Task<List<UserHeaderDTO>> GetCompanyAdmins(int companyId)
        {
            return await _context.CompanyAdmins
                                 .Include(c => c.User)
                                 .Where(c => c.CompanyId == companyId)
                                 .Select(u => new UserHeaderDTO {
                                     Email = u.User.Email,
                                     FullName = u.User.FullName,
                                     PhoneNumber = u.User.PhoneNumber
                                 })
                                 .ToListAsync();
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

        public async Task<bool> IsUserAdminAtCompany(string userId, int companyId)
        {
            //current user
            //string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return await _context.Companies
                                 .Include(c => c.CompanyAdmins)
                                 .Where(c => 
                                    c.UserId == userId ||
                                    c.CompanyAdmins.Where(ca => ca.UserId == userId).Any()
                                  )
                                 .AnyAsync();
        }

        public async Task AddAdminForCompany(int companyId, string userId)
        {
            await _context.CompanyAdmins
                          .AddAsync(new CompanyAdmin { UserId = userId, CompanyId = companyId });

            await _context.SaveChangesAsync();
        }
    }
}
