﻿using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtEfpbdt
    {
        public int BusinessKey { get; set; }
        public long BillDocumentKey { get; set; }
        public int SerialNumber { get; set; }
        public DateTime ServiceDate { get; set; }
        public int ServiceType { get; set; }
        public int ServiceCode { get; set; }
        public int ServiceTypeId { get; set; }
        public int ServiceId { get; set; }
        public int? DoctorCode { get; set; }
        public bool ChargableToPatient { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ConcessionAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PayableByPatient { get; set; }
        public decimal PayableByInsurance { get; set; }
        public string ServiceNarration { get; set; }
        public bool ServiceConfirmationStatus { get; set; }
        public bool ApprovalStatus { get; set; }
        public DateTime? ApprovalOn { get; set; }
        public bool SmartLinked { get; set; }
        public int RefundType { get; set; }
        public int RefundReason { get; set; }
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
