using CarDealers.Models.Models.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealers.Models.Models
{

    [Table("Advertisement", Schema = "Advertisement")]
    public class Advertistment : IdName
    {
        public string AdTitle { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("FkUserId")]
        public string FkUserId { get; set; }


        [ForeignKey("FkLocationId")]
        public Location Location { get; set; }
        public int? FkLocationId { get; set; }

        public Brand Brand { get; set; }
        [ForeignKey("FkBrandId")]
        public int? FkBrandId { get; set; }

        public int? CategoryId { get; set; }

    }
}
