using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGptrmc
    {
        public int MembershipType { get; set; }
        public decimal DonationRangeFrom { get; set; }
        public decimal DonationRangeTo { get; set; }
        public decimal? BookingDiscountPercentage { get; set; }
        public int RoomType { get; set; }
        public int NoOfPersons { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
