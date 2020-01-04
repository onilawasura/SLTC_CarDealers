using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.Models.DTOs
{
    public class FilteredDataDto
    {
        public int? LocationId { get; set; }

        public int? CategoryId { get; set; }

        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }
    }
}
