﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages.Companies
{
    public class AdminsModel : PageModel
    {
        public ICompanyManager companyManager;
        public UserManager<User> userManager;

        [BindProperty]
        public CompanyHeaderDTO Company { get; set; }

        [BindProperty]
        public List<UserHeaderDTO> CompanyAdmins { get; set; }

        public AdminsModel(
            ICompanyManager _companyManager,
            UserManager<User> _userManager)
        {
            this.companyManager = _companyManager;
            this.userManager = _userManager;
        }

        public async Task OnGet(int id)
        {
            Company = await companyManager.GetCompanyHeader(id);
            CompanyAdmins = await companyManager.GetCompanyAdmins(id);
            
        }

        [BindProperty]
        [Required, DataType(DataType.EmailAddress)]
        public string EmailInput { get; set; }

        public async Task<IActionResult> OnPost(string companyId)
        {
            if (!ModelState.IsValid) return Redirect("/companies/admins/" + companyId);
            User userToAdd = await userManager.FindByEmailAsync(EmailInput);
            if(userToAdd == null)
            {
                return Redirect("/companies/admins/" + companyId);
            }

            await companyManager.AddAdminForCompany(Int32.Parse(companyId), userToAdd.Id);
            return Redirect("/companies/admins/" + companyId);
        }
    }
}