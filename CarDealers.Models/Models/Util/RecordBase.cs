using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealers.Models.Models.Util
{
    public class RecordBase
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime EditOn { get; set; }

        public string EdtedBy { get; set; }

        public int RecordStatus { get; set; }

        public int CompanyId { get; set; }

        public RecordBase()
        {
            CreatedOn = DateTime.Now;

            EditOn = DateTime.Now;

            RecordStatus = 1;

            CompanyId = 0;
        }
    }
}
