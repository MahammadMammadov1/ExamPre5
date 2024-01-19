using ExamPre5.Areas.ViewModel;
using ExamPre5.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel vm)
        {

            if (!ModelState.IsValid) return View();

            var user =await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "invalid username or password");
                return View();
            }

            var result =await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "invalid username or password");
                return View();
            }

            return RedirectToAction("Index","Dashboard");
        }

        


        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new AppUser
            {
                UserName = "SuperAdmin",
                Fullname = "Mehemmed Memmedov",

            };

            await _userManager.CreateAsync(user,"Admin123@");
            await _userManager.AddToRoleAsync(user, "SuperAdmin");

            return Ok("yarandi");

        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role = new IdentityRole("SuperAdmin");
            IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role);
            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);

            return Ok("yarandi");
        }

    }
}
