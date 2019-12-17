using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.Models.Models
{
    public class ApplcationUserModal
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }


        //user to add a role to a user
        public string Role { get; set; }
    }
}
