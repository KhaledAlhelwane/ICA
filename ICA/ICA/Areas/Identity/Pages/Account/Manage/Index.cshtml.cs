// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ICA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ICA.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment hosting;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment Hosting)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            hosting = Hosting;
        }

        public string Username { get; set; }

      
        [TempData]
        public string StatusMessage { get; set; }

       
        [BindProperty]
        public InputModel Input { get; set; }

      
        public class InputModel
        {
            [Required]
            [StringLength(10, ErrorMessage = "يجب ان لا يتجاوز الاسم أكثر من 15 محرف")]
            public string FirstName { get; set; }
            [Required]
            [StringLength(10, ErrorMessage = "يجب ان لا تتجاوز الكنية أكثر من 15 محرف")]
            public string SecoundName { get; set; }

            public IFormFile PorfilePicture { get; set; }
             public string? profilePictureGet { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName=user.FirstName,
                SecoundName=user.SecoundName,
                profilePictureGet=user.ProfilePicture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            user.PhoneNumber = Input.PhoneNumber;
            user.FirstName = Input.FirstName;
            user.SecoundName = Input.SecoundName;
            if (Input.PorfilePicture != null)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                //شو نعمل شلون بدنا نحكيي (:
                string filename = string.Empty;
                filename = Guid.NewGuid().ToString() + Input.PorfilePicture.FileName;
                string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
                string fullpath = Path.Combine(uploads, filename);
                //Delete Old Picture
                if (user.ProfilePicture!= null)
                {
                    string OldFile = user.ProfilePicture;
                    string fullOldpath = Path.Combine(uploads, OldFile);
                    System.IO.File.Delete(fullOldpath);
                }
                //Saving new Picture
                Input.PorfilePicture.CopyTo(new FileStream(fullpath, FileMode.Create));
                user.ProfilePicture = filename;
            }
            var result =await _userManager.UpdateAsync(user);
            
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
