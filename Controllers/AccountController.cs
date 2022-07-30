using YouTube.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace YouTube.Controllers
{
   public class AccountController : Controller
   {
      private readonly UserManager<IdentityUser> userManager;
      private readonly SignInManager<IdentityUser> signInManager;

      public AccountController(UserManager<IdentityUser> uManager, SignInManager<IdentityUser> sManager)
      {
         userManager = uManager;
         signInManager = sManager;
      }
      public IActionResult Index()
      {
         return View();
      }
      [HttpGet]
      public IActionResult Register()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Register(RegisterViewModel model)
      {
         int invalid = 0;
         if (ModelState.IsValid)
         {
            var user = new IdentityUser
            {
               UserName = model.Username,
               Email = model.Email,
               EmailConfirmed = true,
               LockoutEnabled = false,
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
               if (signInManager.IsSignedIn(User))
               {
                  return RedirectToAction("index", "home");
               }
               return RedirectToAction("login", "account");
            }
            foreach (var error in result.Errors)
            {
               invalid = 1;
               ModelState.AddModelError("", error.Description);
            }
         }
         else
            invalid = 1;
         ViewBag.valid = invalid;
         return View();
      }

      [HttpGet]
      public IActionResult Login()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Login(LoginViewModel model)
      {
         int invalid = 0;
         if (ModelState.IsValid)
         {
            var result = await
            signInManager.PasswordSignInAsync(model.Username,
                                          model.Password, false, false);
            if (result.Succeeded)
            {
               return RedirectToAction("index", "home");
            }
            invalid = 1;
            ModelState.AddModelError(string.Empty, "Invalid Username or Password");

         }
         else
            invalid = 1;
         ViewBag.valid = invalid;
         return View(model);
      }
      [HttpGet]
      public async Task<IActionResult> Logout()
      {
         await signInManager.SignOutAsync();
         return RedirectToAction("index", "home");
      }
   }
}
