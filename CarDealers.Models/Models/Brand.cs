using CarDealers.Models.Models.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealers.Models.Models
{
    public class Brand : IdName
    {
        public Category ParentCat { get; set; }


        [ForeignKey("FkCatId")]
        public int? FkCatId { get; set; }
    }
}
