using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BMECars.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Pages
{
    public class LoginModel : PageModel
    {
        private SignInManager<User> SignInManager { get; }
        public LoginModel(SignInManager<User> signInManager) =>
            SignInManager = signInManager;
        public class InputModel
        {
            [Required, EmailAddress]
            public string Email { get; set; }

            [Required, DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Keep me signed in")]
            public bool KeepMeSignedIn { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet() { }
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var signInResult = await SignInManager.PasswordSignInAsync(
                    Input.Email, Input.Password, Input.KeepMeSignedIn, false);

                if (!signInResult.Succeeded)
                    ModelState.AddModelError("", "Failed login attempt.");
                else
                    return RedirectToPage("~/");
            }
            return Page();
        }
    }
}