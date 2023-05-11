using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_MemberShipCard
    {
        public int MembershipType { get; set; }
        public decimal DonationRangeFrom { get; set; }
        public decimal DonationRangeTo { get; set; }
        public decimal? BookingDiscountPercentage { get; set; }
        public int RoomType { get; set; }
        public int NoOfPersons { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        //for display
        public string MembershipTypeDesc { get; set; }
        public string RoomTypeDesc { get; set; }
    }
}
