using CarDealers.Models.Models.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealers.Models.Models
{
    public class Image : RecordBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string  Url { get; set; }
        public Advertistment Advertistment { get; set; }


        [ForeignKey("FkAdvertistmentId")]
        public int? FkAdvertistmentId { get; set; }
    }
}
