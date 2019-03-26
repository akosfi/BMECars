using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BMECars.Dal.DTOs;
using BMECars.Dal.Entities;
using BMECars.Dal.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BMECars.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ICompanyManager _companyManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            ICompanyManager companyManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _companyManager = companyManager;
        }

        public string Username { get; set; }
        

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone number")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }


            [Display(Name = "Password")]
            [DataType(DataType.Text)]
            public string Password { get; set; }


            [Display(Name = "Old Password")]
            [DataType(DataType.Text)]
            [Compare("Password", ErrorMessage = "The password and old password do not match.")]
            public string OldPassword { get; set; }

            [Required]
            [Display(Name = "Birth Date")]
            [DataType(DataType.DateTime)]
            public DateTime BirthDate { get; set; }

            [Required]
            [Display(Name = "Full Name")]
            [DataType(DataType.Text)]
            public string FullName { get; set; }
        }

        public List<CompanyHeaderDTO> UserCompanies;

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            UserCompanies = _companyManager.GetCompaniesForUser(user.Id);

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var birthDate = user.BirthDate;
            var fullName = user.FullName;

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                BirthDate = birthDate,
                FullName = fullName
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }


            
            if(Input.Password != Input.OldPassword && Input.OldPassword != "" && Input.Password != "")
            {
                
                var passwordCheck = await _userManager.CheckPasswordAsync(user, Input.OldPassword);
                if (passwordCheck)
                {
                    var setPasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.Password);
                    if (!setPasswordResult.Succeeded)
                    {

                    }
                }                
            }
            
            if(Input.BirthDate != user.BirthDate)
            {
                user.BirthDate = Input.BirthDate;
                var setBirthDateResult = await _userManager.UpdateAsync(user);
                if (!setBirthDateResult.Succeeded)
                {

                }
            }

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
