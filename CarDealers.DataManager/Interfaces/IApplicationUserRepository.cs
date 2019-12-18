using CarDealers.Models.DTOs;
using CarDealers.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<Object> PostApplicationUser(ApplcationUserModal modal);

        Task<Object> Login(LoginModelDto model);
    }
}
