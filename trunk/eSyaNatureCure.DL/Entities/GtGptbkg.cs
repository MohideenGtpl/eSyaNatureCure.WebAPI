using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGptbkg
    {
        public int BusinessKey { get; set; }
        public decimal BookingKey { get; set; }
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AgeYy { get; set; }
        public int Isdcode { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Place { get; set; }
        public long? Uhid { get; set; }
        public bool IsCheckedIn { get; set; }
        public DateTime? ActualCheckedInDate { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime? ActualCheckedOutDate { get; set; }
        public string Address { get; set; }
        public int? AreaCode { get; set; }
        public int? CityCode { get; set; }
        public int? StateCode { get; set; }
        public string Pincode { get; set; }
        public bool IsDoctorConsulted { get; set; }
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
