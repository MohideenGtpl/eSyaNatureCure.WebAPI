using System;
using System.Collections.Generic;

namespace eSyaNatureCure.DL.Entities
{
    public partial class GtGptbpl
    {
        public decimal BookingKey { get; set; }
        public int SerialNo { get; set; }
        public string RequestType { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
