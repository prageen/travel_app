using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travel.Bl.Register;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Infrastructure;
using Travel.Repository.Interface;

namespace Travel.Bl.Register_User
{
  public  class RegisterBl : IRegisterBl
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterBl(IUnitOfWork unitOfWork, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseModel> Signup(RegisterDto appUserDto)
        {
            ResponseModel response = new ResponseModel();
            var userCheck = await _userManager.FindByNameAsync(appUserDto.PhoneNumber);
            if (userCheck == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    PhoneNumber = appUserDto.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = appUserDto.Username
                };
                var result = await _userManager.CreateAsync(user, appUserDto.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    {
                        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }
                    response.Status = "Success";
                    response.Message = "User registered";
                }
                else
                {
                    response.Status = "Error";
                    response.Message = result;
                }
            }
            else
            {
                response.Status = "Error";
                response.Message = response;
            }
            return response;
        }

        public async Task<dynamic> SignIn(string phoneNumber, string password)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var user = await Task.Run(() =>
                {
                    return _userManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
                });
                //var user = await _userManager.FindByNameAsync(phoneNumber);
                if (user == null || await _userManager.CheckPasswordAsync(user, password) == false)
                {
                    response.Status = "Error";
                    response.Message = "Invalid credentials";
                    return response;
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, true);

                if (result.Succeeded)
                {
                    // await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    response.Status = "Success";
                    response.Message = user;
                    return response;
                }
                else if (result.IsLockedOut)
                {
                    response.Status = "Error";
                    response.Message = "Account Locked";
                }
                else
                {
                    response.Status = "Error";
                    response.Message = "Login failed";
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
        public async Task<dynamic> Logout()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                await _signInManager.SignOutAsync();
                response.Status = "Success";
                response.Message = "Login success";
                return response;
            }
            catch (Exception)
            {
                response.Status = "Error";
                response.Message = "Some server error occured.Please try later";
                return response;
            }
           
        }

    }
}
