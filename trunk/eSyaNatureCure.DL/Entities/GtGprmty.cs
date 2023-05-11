using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGprmty
    {
        public GtGprmty()
        {
            GtGptbkp = new HashSet<GtGptbkp>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeDesc { get; set; }
        public string BedType { get; set; }
        public string SqFeet { get; set; }
        public int MaxOccupancy { get; set; }
        public bool SharingStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual ICollection<GtGptbkp> GtGptbkp { get; set; }
    }
}
