using CarDealers.DataManager.Context;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {

        private UserManager<ApplicationUser> _userManager;

        CarDealerDbContext _db;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, CarDealerDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<Object> Login(LoginModelDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);


                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {

                    //get roles assigned to the user

                    var role = await _userManager.GetRolesAsync(user);
                    IdentityOptions _options = new IdentityOptions();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim( _options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return token;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }
            //try
            //{
            //    var xx = await _userManager.FindByNameAsync(model.UserName);

            //}
            //catch (Exception ex)
            //{

            //    var xxxx = ex;
            //}

            //var user = await _userManager.FindByNameAsync(model.UserName);
            //if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            //{

            //    //get roles assigned to the user

            //    var role = await _userManager.GetRolesAsync(user);
            //    IdentityOptions _options = new IdentityOptions();

            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new Claim[]
            //        {
            //            new Claim("UserID",user.Id.ToString()),
            //            new Claim( _options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
            //        }),
            //        Expires = DateTime.UtcNow.AddDays(1),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //    var token = tokenHandler.WriteToken(securityToken);
            //    return new { token };
            //}
            //else
            //{
            //    return new { message = "Username or password is incorrect." };
            //}



        }
            public async Task<Object> PostApplicationUser(ApplcationUserModal model)
        {
            model.Role = "Admin";//new line

            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);//new line
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
