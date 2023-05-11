﻿using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGppkpr
    {
        public int PackageId { get; set; }
        public int RoomTypeId { get; set; }
        public string OccupancyType { get; set; }
        public decimal Price { get; set; }
        public int NoOfWeeks { get; set; }
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
