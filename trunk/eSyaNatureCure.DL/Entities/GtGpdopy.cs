using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGpdopy
    {
        public int BusinessKey { get; set; }
        public int DonorId { get; set; }
        public DateTime DateOfDonation { get; set; }
        public decimal DonationAmount { get; set; }
        public string VoucherKeyReference { get; set; }
        public string Comments { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
