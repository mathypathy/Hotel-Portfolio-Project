using DontFlipIt.Models;
using DontFlipIt.Repository;
using DontFlipIt.Services;
using DontFlipIt.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DontFlipIt.Controllers
{
    [RequireHttps]
    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationService _authService;
     
 
        // add logger here 
        public AuthenticationController(AuthenticationService authService) 
        {
            _authService = authService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public  async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               var result =  await _authService.UserLoginAsync(model);
               if(result == true)
               {
                    return RedirectToAction("UserDashboard", "Authentication");
               }
                return RedirectToAction("Index", "Error");
            }
            return View();
        }



        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task <ActionResult> Register(HotelUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _authService.RegisterNewUser(model);
                return RedirectToAction("Index","Authentication");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Registration failed. Please check your input.");
            }
            return View("Register", model);
        }


      public ActionResult UserDashboard()
      {
            return View();
      }
        
      public async Task <IActionResult> Logout()
      {
            HttpContext.Session.Clear();
            await _authService.UserLogout();
            return RedirectToAction("Index", "Home");
      }

    }
}
