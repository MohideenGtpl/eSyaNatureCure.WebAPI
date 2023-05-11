using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public  class DO_GuestOnlinePaymentResponse
    {
        public string id { get; set; }
        public string entity { get; set; }
        public decimal amount { get; set; }
        public decimal amount_paid { get; set; }
        public decimal amount_due { get; set; }
        public string currency { get; set; }
        public string receipt { get; set; }
        public string order_id { get; set; }
        public string offer_id { get; set; }
        public string status { get; set; }
        public string attempts { get; set; }
        public string created_at { get; set; }

        public int BusinessKey { get; set; }
        public decimal BookingKey { get; set; }
        public string ResponseData { get; set; }
    }
}
