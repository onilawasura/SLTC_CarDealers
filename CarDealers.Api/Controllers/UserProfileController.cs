﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarDealers.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }


        [Route("api/UserProfile/GetUserProfile")]
        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
           var xx =  new
            {
                user.FullName,
                user.Email,
                user.UserName,
                role,
                user.Id
            };

            return xx;
        }

    }
}