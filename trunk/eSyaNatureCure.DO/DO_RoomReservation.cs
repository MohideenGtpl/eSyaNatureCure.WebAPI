using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_RoomReservation
    {
        public int BusinessKey { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TillDate { get; set; }
        public int ReasonType { get; set; }
        public string Comments { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string RoomTypeDesc { get; set; }
        public string ReasonTypeDesc { get; set; }
        public string RoomNumberDesc { get; set; }
        public string BedNumberDesc { get; set; }
        public bool Status { get; set; }
    }
}
