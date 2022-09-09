using YouTube.ViewModels;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using YouTube.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace YouTube.Controllers
{
   public class AccountController : Controller
   {
      private readonly IUser _user;
      private readonly IChannel _channel;
      private readonly UserManager<IdentityUser> userManager;
      private readonly SignInManager<IdentityUser> signInManager;
      private readonly IMapper _mapper;
      public AccountController(UserManager<IdentityUser> uManager, SignInManager<IdentityUser> sManager, IUser user, IChannel channel, IMapper mapper)
      {
         _mapper = mapper;
         userManager = uManager;
         signInManager = sManager;
         _user = user;
         _channel = channel;
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
               //register user at the time of account registeration
               Models.User newUser = _mapper.Map<Models.User>(model);
               newUser.channelId = null;
               _user.AddUser(newUser);
               HttpContext.Response.Cookies.Append("login", "false");
               if (!HttpContext.Request.Cookies.ContainsKey("email"))
                  HttpContext.Response.Cookies.Append("email", model.Email);
               else
               {
                  HttpContext.Response.Cookies.Delete("email");
                  HttpContext.Response.Cookies.Append("email", model.Email);
               }
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
               //store email of logged in user in cookies
               HttpContext.Response.Cookies.Append("login", "true");
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
         HttpContext.Response.Cookies.Append("login", "false");
         await signInManager.SignOutAsync();
         return RedirectToAction("index", "home");
      }
   }
}
