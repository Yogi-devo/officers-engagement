﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OfficerEngagement.Models;
using OfficerEngagement.Repository;


namespace OfficerEngagement.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet("signup")]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost("signup")]
        //[Route("signup")]
        public async  Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError(" ", errorMessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
                return RedirectToAction("Login","Account");
            }
            return View(userModel);
        }
        [HttpGet("login")]
        
        public IActionResult Login()
        {
            return View();
        }

       // [Route("login")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInModel signInModel, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if(result.Succeeded)
                { if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(" ", "Invalied credentials");
                }
            }
            return View(signInModel);
        }

       [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("change-password")]
        public  IActionResult ChangePassword()
        {             
            return View();
        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordModel model)
        {
           if(ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if(result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }

            }
            return View(model);
        }
    }
}
