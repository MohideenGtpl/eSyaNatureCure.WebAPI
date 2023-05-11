﻿using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGppkms
    {
        public int PackageId { get; set; }
        public string PackageDesc { get; set; }
        public string ServiceDesc { get; set; }
        public int NoOfNights { get; set; }
        public string CheckInWeekDays { get; set; }
        public TimeSpan CheckInFromTime { get; set; }
        public TimeSpan CheckInToTime { get; set; }
        public TimeSpan CheckOutFromTime { get; set; }
        public TimeSpan CheckOutToTime { get; set; }
        public int BookingRule { get; set; }
        public int BookingWindow { get; set; }
        public string BookingApplicableFor { get; set; }
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
