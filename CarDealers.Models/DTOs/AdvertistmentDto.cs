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
        public string ModelNo { get; set; }
        public string Destination { get; set; }

        public int adId { get; set; }

        public List<string> Urls { get; set; }

        public AdvertistmentDto()
        {
            this.Urls = new List<string>();
        }
    }
}
