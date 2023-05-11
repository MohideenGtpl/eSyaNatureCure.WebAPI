using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_DonorRules
    {
        public int DonorType { get; set; }
        public string DonorTypeDesc { get; set; }
        public decimal DonationRangeFrom { get; set; }
        public decimal DonationRangeTo { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int RoomType { get; set; }
        public int NoOfPersons { get; set; }
        public decimal DonorValidityInYears { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string RoomTypeDesc { get; set; }

    }
}
