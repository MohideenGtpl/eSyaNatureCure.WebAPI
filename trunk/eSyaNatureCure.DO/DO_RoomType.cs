using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
    public class DO_RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeDesc { get; set; }
        public string BedType { get; set; }
        public string SqFeet { get; set; }
        public int MaxOccupancy { get; set; }
        public bool SharingStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
