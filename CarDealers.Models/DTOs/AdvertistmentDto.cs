using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.Models.DTOs
{
    public class AdvertistmentDto
    {
        public string CategoryType { get; set; }
        //public string SubCategory { get; set; }
        public string BrandType { get; set; }
        public string ModelType { get; set; }
        //public string ModelNo { get; set; }
        public string Destination { get; set; }
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
        public string Milage { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }
        public int? adId { get; set; }
        public string FkUserId { get; set; }

        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string Description { get; set; }

        public List<string> Urls { get; set; }

        public AdvertistmentDto()
        {
            this.Urls = new List<string>();
        }
    }
}
