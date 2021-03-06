﻿using CarDealers.Models.Models.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealers.Models.Models
{
    public class Modal : IdName
    {
        public Brand Brand { get; set; }

        [ForeignKey("FkBrandId")]
        public int? FkBrandId { get; set; }
    }
}
