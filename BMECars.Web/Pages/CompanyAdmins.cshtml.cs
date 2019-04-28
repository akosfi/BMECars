using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages
{
    public class CompanyAdminsModel : PageModel
    {
        public ICompanyManager companyManager;

        public CompanyHeaderDTO Company { get; set; }
        public List<UserHeaderDTO> CompanyAdmins { get; set; }

        public CompanyAdminsModel(ICompanyManager _companyManager)
        {
            this.companyManager = _companyManager;
        }

        public async Task OnGet(int companyId)
        {
            Company = await companyManager.GetCompanyHeader(companyId);
            CompanyAdmins = await companyManager.GetCompanyAdmins(companyId);

            foreach(UserHeaderDTO u in CompanyAdmins)
            {
                Console.WriteLine(u.Email +  " +++++++++++++++++++" );
            }
        }
    }
}