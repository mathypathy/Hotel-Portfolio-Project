using DontFlipIt.Models;
using DontFlipIt.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using DontFlipIt.Repository;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Claims;

namespace DontFlipIt.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<HotelUserEntity> _userManager;
        private readonly SignInManager<HotelUserEntity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly Logger<AuthenticationService> _logger;
        public AuthenticationService(SignInManager<HotelUserEntity> signInManager, UserManager<HotelUserEntity> userManager, UnitOfWork unitOfWork, Logger<AuthenticationService> logger, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            
        }
        public async Task RegisterNewUser(HotelUserViewModel model)
        {
            var doesUserExist = await _userManager.FindByEmailAsync(model.Email);
            var isFirst = !_userManager.Users.Any();
            if (doesUserExist == null)
            {
                var user = new HotelUserEntity
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                  
                };
           
                var createUser = await _userManager.CreateAsync(user, model.Password);    
                if (createUser.Succeeded)
                {

                    if(isFirst)
                    {
                        var adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
                        if(!adminRoleExists)
                        {
                            await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        }
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _unitOfWork.GuestRepository.Add(user);
                    
                        _logger.LogInformation("User registration successfull for user");
                    }
                }
                else
                {
                    _logger.LogError("Error when register the user");
                }
            }
            else
            {
                _logger.LogWarning("A User with that email already exist");
            }
        }

        public async Task<bool> UserLoginAsync(LoginViewModel model)
        {
          
            var user = await _userManager.FindByEmailAsync(model.UserEmail);
            if(user != null)
            {
                var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure:false);
                if (passwordCheck.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("{user.Email} logged in successfully.", user.Email);
                    return true;
                  
                }
                _logger.LogError("user could not log in.");
                return false;
               
            }
            _logger.LogError("user is null");
            return false;
           
        }
         
        public async Task UserLogout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out Successfully");
        }


    }
}
