using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealers.Models.Models
{
    public class FavouriteAdvertistment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }
        [ForeignKey("FkUserId")]
        public string FkUserId { get; set; }

        public virtual Advertistment Advertistment { get; set; }
        [ForeignKey("FkAdvertistmentId")]
        public int? FkAdvertistmentId { get; set; }


    }
}
