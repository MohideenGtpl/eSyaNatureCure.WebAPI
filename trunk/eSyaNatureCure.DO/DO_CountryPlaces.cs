using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
   public class DO_CountryPlaces
    {
        public int PlaceRype { get; set; }
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
    }

    public class DO_CountryArea
    {
        public int AreaCode { get; set; }
        public string AreaName { get; set; }
        public int StateCode { get; set; }
        public int CityCode { get; set; }
        public int District { get; set; }
        public string Pincode { get; set; }
    }
}
