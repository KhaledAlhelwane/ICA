using ICA.Models;
using ICA.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ICA.Controllers.Admin
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManger;

        public UserController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManger)
        {
            _userManager = userManager;
            _roleManger = roleManger;
        }
        //List of the users and thier roles
        public async Task<IActionResult> Index()
        {
            var users =  _userManager.Users.Select(user => new UserViewModel
            {
                id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.SecoundName,
                UserName = user.UserName,
                TheUser=user,
                status = user.LockoutEnabled

                //Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync().Result;
            List<UserViewModel> UserWithRoles=new List<UserViewModel>();
            foreach (var x in users)
            {
                var ListaOfRoles =await _userManager.GetRolesAsync(x.TheUser);
                x.Roles = ListaOfRoles;
                UserWithRoles.Add(x);
            }
           
           
			return View(UserWithRoles);
        }

        // Creat new User
        // Get Method
        public IActionResult Creat()
        {

            var CreatUser = new CreatUserViewModel
            {
                ListaOfRoles = _roleManger.Roles.ToListAsync().Result
            };

            return View(CreatUser);
        }
        // Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat(CreatUserViewModel Collection)
        {
			if (!ModelState.IsValid)
			{
				ViewBag.message = "you have to fix and rich all requirments";
			}
            var EndDate = new DateTime(2222, 06, 06);
            var user = new ApplicationUser { UserName = Collection.Email, Email = Collection.Email, FirstName = Collection.FirstName, SecoundName = Collection.SecoundName,LockoutEnabled=true,LockoutEnd= EndDate };
			var result = await _userManager.CreateAsync(user, Collection.Password);
			if (result.Errors.Count() > 0)
			{
				ViewBag.message = result;
				var ListaOfRoles = await _roleManger.Roles.ToListAsync();

				var NewUser = new CreatUserViewModel
				{
					ListaOfRoles = ListaOfRoles
				};

				return View(NewUser);
			}
           await _userManager.AddToRoleAsync(user, Collection.TheRole);
			return RedirectToAction(nameof(Index));
        }

		//get Method for susbending user
		public async Task<IActionResult> SuspendUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var UserSuspend = new UserViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.SecoundName,
                UserName=user.UserName
                //status = user.Status
            };
            if (user.LockoutEnabled == true)
            {
                ViewBag.status = "Lock";
            }
            else
            {
                ViewBag.status = "UnLock";
              
			}
            return View(UserSuspend);
        }
		//post method for susbending user
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuspendUser(UserViewModel collection)
        {
            if (User != null)
            {
                if (User.Identity.Name == collection.UserName)
                {
                    ModelState.AddModelError("", "Admin can't suspened him self");
                    ViewBag.status = "Can't process";
                    return View();
                }
            }
          var  EndDate = new DateTime(2222, 06, 06);
            var user = await _userManager.FindByEmailAsync(collection.Email);
          await  _userManager.SetLockoutEnabledAsync(user, collection.status);
          await  _userManager.SetLockoutEndDateAsync(user, EndDate);
            user.LockoutEnabled = collection.status;
            await _userManager.UpdateAsync(user);
           
           
            return RedirectToAction(nameof(Index));
        }


	}
}
