using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGpdorn
    {
        public int BusinessKey { get; set; }
        public int DonorId { get; set; }
        public string DonorRegistrationNo { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int DonorType { get; set; }
        public string DonorFirstName { get; set; }
        public string DonorMiddleName { get; set; }
        public string DonorLastName { get; set; }
        public int AgeYy { get; set; }
        public string Gender { get; set; }
        public int Isdcode { get; set; }
        public string RegisteredMobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public int StateCode { get; set; }
        public int CityCode { get; set; }
        public string Pincode { get; set; }
        public int AreaCode { get; set; }
        public int RoomType { get; set; }
        public int NoOfPersons { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public decimal Discount { get; set; }
        public decimal DonatedSoFar { get; set; }
        public string Password { get; set; }
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
