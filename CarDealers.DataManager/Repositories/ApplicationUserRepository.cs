using CarDealers.DataManager.Interfaces;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {

        private UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
