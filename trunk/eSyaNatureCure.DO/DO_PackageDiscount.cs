using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_PackageDiscount
    {
        public int PackageId { get; set; }
        public int RoomTypeId { get; set; }
        public string OccupancyType { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime TillDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string RoomTypeDesc { get; set; }
        public string PackageDesc { get; set; }
        public bool Status { get; set; }
    }
}
