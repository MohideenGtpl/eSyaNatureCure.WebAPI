using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface ISmsReminderRepository
    {
        Task<List<DO_GuestBooking>> GetGuestBookingForSendingReminder(string smsId, DateTime remainderDate);
    }
}
