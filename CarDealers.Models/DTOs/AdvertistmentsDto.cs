using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.Models.DTOs
{
    public class AdvertistmentsDto
    {
        public string AdTitle { get; set; }
        public string Destination { get; set; }
        public string CategoryType { get; set; }
        public float? Price { get; set; }
        public string Url { get; set; }
        public int AdId { get; set; }
        //public string PostedDate { get; set; }
    }
}
