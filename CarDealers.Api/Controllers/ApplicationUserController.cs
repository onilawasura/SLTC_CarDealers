using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarDealers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {

        private IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserController(IApplicationUserRepository applicationUserRepository)
        {
            this._applicationUserRepository = applicationUserRepository;
        }

        //[HttpPost]
        //[Route("Register")]
        //POST : /api/ApplicationUser/Register

        //private UserManager<ApplicationUser> _userManager;
        //public ApplicationUserController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        //POST : /api/ApplicationUser/Register

        public async Task<Object> PostApplicationUser(ApplcationUserModal model)
        {

            if (model == null)
            {
                return BadRequest(model);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var res = await _applicationUserRepository.PostApplicationUser(model);

            return Ok(res);
        }

        //public async Task<Object> PostApplicationUser(ApplcationUserModal model)
        //{
        //    model.Role = "Admin";//new line

        //    var applicationUser = new ApplicationUser()
        //    {
        //        UserName = model.UserName,
        //        Email = model.Email,
        //        FullName = model.FullName
        //    };

        //    try
        //    {
        //        var result = await _userManager.CreateAsync(applicationUser, model.Password);
        //        await _userManager.AddToRoleAsync(applicationUser, model.Role);//new line
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}