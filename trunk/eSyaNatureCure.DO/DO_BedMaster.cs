using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_BedMaster
    {
        public int RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public string BedNumber { get; set; }
        public string Gender { get; set; }
        public bool ReservedStatus { get; set; }
        public bool CheckedIn { get; set; }
        public bool CheckedOut { get; set; }
        public bool ReadyForOccupancy { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        //
        public string RoomTypeDesc { get; set; }
        public bool Status { get; set; }
    }
}
