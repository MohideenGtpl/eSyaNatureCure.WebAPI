using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IGuestPaymentRepository
    {
        Task<DO_ReturnParameter> InsertPatientReceipt(DO_GuestPaymentReceiptDetails obj);

        Task<List<DO_GuestPaymentReceiptDetails>> GetGuestPaymentReceiptDetails(int businessKey, long bookingKey);

        Task<DO_ReturnParameter> UpdateRefundRequestApproval(DO_GuestPaymentReceiptDetails obj);

        Task<DO_GuestOnlinePaymentResponse> GetPaymentOrderResponseByBookingKey(int businessKey, long bookingKey);

        Task<DO_ReturnParameter> CheckOnlinePaymentAndMakePaymentReceipt(DO_GuestOnlinePaymentResponse obj);
        #region Refund Request Approvals
        Task<List<DO_GuestRefundRequestApprovals>> GetRefundRequestApprovals(int businesskey);
        #endregion
    }
}
