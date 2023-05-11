using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_DonorPackageLink
    {
        public int DonorType { get; set; }
        public int PackageId { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        public string DonorTypeDesc { get; set; }
        public string PackageDesc { get; set; }
    }
}
