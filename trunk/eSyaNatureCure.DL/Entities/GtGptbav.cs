using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGptbav
    {
        public int BusinessKey { get; set; }
        public long Ipnumber { get; set; }
        public int SerialNumber { get; set; }
        public string Cltype { get; set; }
        public string ClcontrolId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
        public long Uhid { get; set; }
        public int TransactionId { get; set; }
    }
}
