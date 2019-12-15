using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CarDealers.Models.Models
{
    public class ApplicationUser : IdentityUser 
    {

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
    }
}
