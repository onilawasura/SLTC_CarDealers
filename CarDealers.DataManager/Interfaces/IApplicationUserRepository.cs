using CarDealers.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.DataManager.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<Object> PostApplicationUser(ApplcationUserModal modal);
    }
}
