using DontFlipIt.Models;
using DontFlipIt.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DontFlipIt.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<MemberEntity> _userManager;
        private readonly SignInManager<MemberEntity> _signInManager;
        public AuthenticationService(SignInManager<MemberEntity> signInManager, UserManager<MemberEntity> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public async Task MemberRegistration(string id)
        {
            var member = _userManager.FindByEmailAsync(id);
            if (member == null)
            {
                //fortsätt här imorgon. 
            }
            
        }

        public async Task MemberLogin()
        {
            //fortsätt här imorgon. 
        }

        public async Task MemberLogout()
        {
            //fortsätt här imorgon. 
        }


    }
}
