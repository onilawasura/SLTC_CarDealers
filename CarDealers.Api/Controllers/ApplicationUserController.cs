using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarDealers.DataManager.Interfaces;
using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarDealers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {

        private IApplicationUserRepository _applicationUserRepository;
        private UserManager<ApplicationUser> _userManager;

        public ApplicationUserController(IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager)
        {
            this._applicationUserRepository = applicationUserRepository;
            this._userManager = userManager;
        }


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

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(LoginModelDto model)
        {
            //var res = await _applicationUserRepository.Login(model);
            //if(res != null)
            //{
            //return Ok(res ) ;
            //}
            //else
            //{
            //    return BadRequest(new { message = "Username or password is incorrect." });
            //}

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
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }

        }
    }
}