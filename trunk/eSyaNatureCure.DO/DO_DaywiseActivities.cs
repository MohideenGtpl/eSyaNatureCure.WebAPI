using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_DaywiseActivities
    {
        public int PackageId { get; set; }
        public int DayId { get; set; }
        public int ActivityId { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string PackageDesc { get; set; }
        public string ActivityDesc { get; set; }
        public bool Status { get; set; }
    }
}
