using CarDealers.Models.Models.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.Models.Models
{
    public class UserComments : IdName
    {
        public string UserId { get; set; }
        public int AdvertisementId { get; set; }
    }
}
