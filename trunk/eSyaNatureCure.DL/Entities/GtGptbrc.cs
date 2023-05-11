using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGptbrc
    {
        public int BusinessKey { get; set; }
        public decimal BookingKey { get; set; }
        public int GuestId { get; set; }
        public int SerialNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int PrevRoomTypeId { get; set; }
        public string PrevRoomNumber { get; set; }
        public string PrevBedNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }
        public string Comment { get; set; }
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
