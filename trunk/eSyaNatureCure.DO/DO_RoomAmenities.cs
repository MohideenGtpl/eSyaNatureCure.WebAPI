using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_RoomAmenities
    {
        public int RoomTypeId { get; set; }
        public string OptionType { get; set; }
        public int SerialNumber { get; set; }
        public string OptionValues { get; set; }
        public string OptionDesc { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string RoomTypeDesc { get; set; }
        public bool Status { get; set; }
    }
}
