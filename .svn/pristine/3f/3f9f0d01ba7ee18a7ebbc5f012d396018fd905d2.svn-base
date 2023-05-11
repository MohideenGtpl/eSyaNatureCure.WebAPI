using eSyaNatureCure.DL.Entities;
using eSyaNatureCure.DO;
using eSyaNatureCure.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.DL.Repository
{
    public class SmsReminderRepository: ISmsReminderRepository
    {
        public async Task<List<DO_GuestBooking>> GetGuestBookingForSendingReminder(string smsId, DateTime remainderDate)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    var ds = db.GtGptbkh
                        .Join(db.GtGptbkp,
                             a => new { a.BusinessKey, a.BookingKey },
                             p => new { p.BusinessKey, p.BookingKey },
                             (a, p) => new { a, p })
                        .Join(db.GtGprmty,
                            apd => apd.p.RoomTypeId,
                            s => s.RoomTypeId,
                            (apd, s) => new { apd, s })
                        .Join(db.GtGptbkg,
                            apds => new { apds.apd.a.BusinessKey, apds.apd.a.BookingKey, apds.apd.p.GuestId, },
                             g => new { g.BusinessKey, g.BookingKey, g.GuestId },
                            (apds, g) => new { apds, g })
                        .Where(w => w.apds.apd.a.CheckInDate.Date == remainderDate.Date
                            && w.apds.apd.a.BookingStatus != "CN"
                            && (bool)w.apds.apd.a.ActiveStatus == true
                            && w.g.MobileNumber != null
                            && (bool)w.g.ActiveStatus == true
                            && !db.GtEcsmsc.Any(s => s.Smsid == smsId && s.ReferenceKey == w.apds.apd.a.BookingKey && s.SendStatus))
                        .Select(r => new DO_GuestBooking
                        {
                            BusinessKey = r.apds.apd.a.BusinessKey,
                            BookingKey = r.apds.apd.a.BookingKey,
                            BookingDate = r.apds.apd.a.BookingDate.Date,
                            CheckInDate = r.apds.apd.a.CheckInDate.Date,
                            CheckOutDate = r.apds.apd.a.CheckOutDate.Date,
                            GuestName = r.g != null ? r.g.FirstName + " " + r.g.LastName : "",
                            FirstName = r.g != null ? r.g.FirstName : "",
                            LastName = r.g != null ? r.g.LastName : "",
                            Age = r.g.AgeYy,
                            Gender = r.g.Gender,
                            MobileNo = r.g.MobileNumber,
                            Place = r.g.Place,
                            NetPackageAmount = r.apds.apd.a.NetPackageAmount,
                            PaymentMethod = r.apds.apd.a.PaymentMethod,
                            PaymentReceived = r.apds.apd.a.PaymentReceived,
                            RoomTypeId = r.apds.apd.p.RoomTypeId,
                            RoomTypeName = r.apds.s.RoomTypeDesc,
                            RoomTypeNumber = r.apds.apd.p.RoomNumber,
                            BedNumber = r.apds.apd.p.BedNumber,
                            GuestId = r.apds.apd.p.GuestId,
                            OccupancyType = r.apds.apd.p.OccupancyType,
                            PackagePrice = r.apds.apd.p.PackagePrice,
                            BookingStatus = r.g.IsCheckedOut ? "CO" : (r.g.IsCheckedIn ? "CI" : r.apds.apd.a.BookingStatus)
                        }).ToListAsync();


                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
