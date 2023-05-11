using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IGuestBookingRepository
    {
        List<DO_GuestBooking> GetGuestBookingBySearchCreteria(int businessKey, int roomTypeId,
        string roomNumber, string bedNumber, string occupancyType, string gender, DateTime? bookingFrom, DateTime? bookingTo, DateTime? checkInDate, DateTime? checkOutDate, bool isOnCheckInOutDate);

        List<DO_GuestBooking> GetGuestBookingPaymentFailedDetails(int businessKey, int roomTypeId,
                 string roomNumber, string bedNumber, string occupancyType, string gender,
                 DateTime? bookingFrom, DateTime? bookingTo,
                 DateTime? checkInDate, DateTime? checkOutDate, bool isOnCheckInOutDate);
    }
}
