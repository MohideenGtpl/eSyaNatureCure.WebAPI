using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace eSyaNatureCure.IF
{
   public interface ILaundryRepository
    {
        Task<List<DO_GuestCheckInDetails>> GetCheckInGuestDetailsByBookingKey(int businessKey);

        Task<List<DO_ServiceRates>> GetLaundryServiceList(int businessKey, string gender, string ServiceCriteria);

        Task<DO_ServiceRates> GetLaundryServiceRates(int businessKey, int serviceId, int rateType, string currencyCode);

        Task<List<DO_Service>> GetGuestLaundryServiceByBookingKey(int businessKey, long bookingKey);

        Task<DO_ReturnParameter> InsertGuestLaundryService(DO_Service obj);

        Task<DO_ReturnParameter> UpdateGuestLaundryService(DO_Service obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveGuestLaundryService(bool status, int businessKey, long bookingKey, int SerialNumber);
    }
}
