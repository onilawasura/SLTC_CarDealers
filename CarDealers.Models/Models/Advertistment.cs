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

        [ForeignKey("FkBrandId")]
        public Brand Brand { get; set; }
        public int? FkBrandId { get; set; }

        public int? CategoryId { get; set; }

        public float? Price { get; set; }

        public string Edition { get; set; }

        public string Grade { get; set; }

        public int? ModelYear { get; set; }

        public bool? Condition { get; set; }

        public bool? Negotiable { get; set; }

        public string Transmission { get; set; }

        public string BodyType { get; set; }

        public int? FuelType { get; set; }

        public string Capacity { get; set; }

        public string Millage { get; set; }

        public string Email { get; set; }

        public string Contactno { get; set; }
    }
}
