using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OfficerEngagement.Models;
using OfficerEngagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficerEngagement.Repository
{
    
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppilicationUser> _userManager;
        private readonly SignInManager<AppilicationUser> _signInManager;
        private readonly IUserService _userService;

        public AccountRepository(UserManager<AppilicationUser> userManager, SignInManager<AppilicationUser> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
             _userService = userService;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel UserModel)
        {
            var user = new AppilicationUser()
            { 
                firstName=UserModel.firstName,
                LaststName=UserModel.LastName,
                Email = UserModel.LoginId,
                UserName=UserModel.LoginId,
            };
              var result= await _userManager.CreateAsync(user, UserModel.Password);
            return result;
        }
         
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
           var result= await _signInManager.PasswordSignInAsync(signInModel.LoginId, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return  await _userManager.ChangePasswordAsync(user,model.CurrentPassword, model.NewPassword);
        }
    }
}
