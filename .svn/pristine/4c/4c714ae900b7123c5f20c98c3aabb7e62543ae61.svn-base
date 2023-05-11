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
    public class FrontOfficeRepository : IFrontOfficeRepository
    {
        public async Task<DO_FrontOffice> GetTodayDashboard(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = await db.GtGptbkh
                    .Join(db.GtGptbkg,
                      h => h.BookingKey,
                      g => g.BookingKey,
                      (h, g) => new { h, g })
                      .Join(db.GtGptbkp,
                      hg => new { hg.h.BookingKey, hg.g.GuestId },
                      p => new { p.BookingKey, p.GuestId },
                      (hg, p) => new { hg, p })
                      .Where(w => w.hg.h.BusinessKey == businessKey
                        && ((w.hg.h.CheckInDate.Date <= System.DateTime.Now.Date && !w.hg.g.IsCheckedOut) //&& w.hg.h.CheckOutDate >= System.DateTime.Now.Date)
                            || (w.hg.g.IsCheckedIn && !w.hg.g.IsCheckedOut)
                            )
                        && w.hg.h.ActiveStatus)
                      .AsNoTracking()
                      .Select(
                        l => new DO_BookinDetails
                        {
                            BusinessKey = l.hg.h.BusinessKey,
                            BookingKey = l.hg.h.BookingKey,
                            BookingDate = l.hg.h.BookingDate,
                            CheckInDate = l.hg.h.CheckInDate,
                            CheckOutDate = l.hg.h.CheckOutDate,
                            BookingStatus = l.hg.h.BookingStatus,
                            FirstName = l.hg.g.FirstName,
                            LastName = l.hg.g.LastName,
                            GuestName = l.hg.g.FirstName + " " + l.hg.g.LastName,
                            Gender = l.hg.g.Gender,
                            MobileNumber = l.hg.g.MobileNumber,
                            EmailId = l.hg.g.EmailId,
                            Place = l.hg.g.Place,
                            Uhid = l.hg.g.Uhid,
                            GuestId = l.hg.g.GuestId,
                            IsCheckedIn = l.hg.g.IsCheckedIn,
                            ActualCheckedInDate = l.hg.g.ActualCheckedInDate,
                            IsCheckedOut = l.hg.g.IsCheckedOut,
                            ActualCheckedOutDate = l.hg.g.ActualCheckedOutDate,
                            RoomTypeId = l.p.RoomTypeId,
                            RoomTypeDesc = db.GtGprmty.Where(w => w.RoomTypeId == l.p.RoomTypeId).Select(s => s.RoomTypeDesc).FirstOrDefault(),
                            RoomNumber = l.p.RoomNumber,
                            BedNumber = l.p.BedNumber,
                            OccupancyType = l.p.OccupancyType,
                            NoOfWeeks = l.p.NoOfWeeks
                        }
                            ).ToListAsync();

                    var dashboard = new DO_FrontOffice();
                    dashboard.Checkin_List = ds.FindAll(w => w.CheckInDate.Date == System.DateTime.Now.Date && !w.IsCheckedIn);
                    dashboard.Checkin_Count = dashboard.Checkin_List.Count;
                    dashboard.Checkout_List = ds.FindAll(w => w.CheckOutDate.Date == System.DateTime.Now.Date && !w.IsCheckedOut);
                    dashboard.Checkout_Count = dashboard.Checkout_List.Count;
                    dashboard.PendingCheckin_List = ds.FindAll(w => w.CheckInDate.Date < System.DateTime.Now.Date && !w.IsCheckedIn);
                    dashboard.PendingCheckin_Count = dashboard.PendingCheckin_List.Count;
                    dashboard.Occupancy_List = ds.FindAll(w => w.IsCheckedIn && !w.IsCheckedOut);
                    dashboard.Occupancy_Count = dashboard.Occupancy_List.Count;

                    var occ_rooms = dashboard.Occupancy_List.Select(s => s.RoomNumber).Distinct().ToList().Count;
                    var total_rooms = db.GtGprmbm.Select(s => s.RoomNumber).Distinct().ToList().Count();
                    if (total_rooms != 0)
                    {
                        dashboard.Occupancy_Percent = (occ_rooms * 100) / total_rooms;
                    }
                    else
                    {
                        dashboard.Occupancy_Percent = 0;
                    }



                    return dashboard;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public async Task<List<DO_BookinDetails>> GetDashboardByDate(int businessKey, DateTime fromDate, DateTime toDate)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    toDate = toDate.AddDays(28);
                    var rm_reservation = await db.GtGprmrv
                        .Join(db.GtGprmty,
                            r => r.RoomTypeId,
                            m => m.RoomTypeId,
                            (r, m) => new { r, m})
                        .Join(db.GtEcapcd,
                            rm => new { rm.r.ReasonType },
                            a => new { ReasonType = a.ApplicationCode },
                            (rm, a) => new { rm, a } )
                        .Where(w => ((fromDate.Date == w.rm.r.EffectiveDate.Date)
                            || (fromDate.Date == w.rm.r.TillDate.Date)
                            || (fromDate.Date < w.rm.r.EffectiveDate.Date && toDate >= w.rm.r.EffectiveDate.Date)
                            || (fromDate.Date > w.rm.r.EffectiveDate.Date && fromDate.Date <= w.rm.r.TillDate.Date))
                                && w.rm.r.ActiveStatus)
                          .Select(
                        l => new DO_BookinDetails
                            {
                            BusinessKey = businessKey,
                            BookingKey = 0,
                            BookingDate = l.rm.r.EffectiveDate,
                            CheckInDate = l.rm.r.EffectiveDate,
                            CheckOutDate = l.rm.r.TillDate,
                            FirstName = "",
                            LastName = "",
                            GuestName = l.a.CodeDesc,
                            Gender = "",
                            MobileNumber = l.rm.r.Comments,
                            EmailId = "",
                            Place = "",
                            Uhid = 0,
                            GuestId = 0,
                            RoomTypeId = l.rm.r.RoomTypeId,
                            RoomTypeDesc = l.rm.m.RoomTypeDesc,
                            RoomNumber = l.rm.r.RoomNumber,
                            BedNumber = l.rm.r.BedNumber,
                            BookingStatus = "RS"

                        }).ToListAsync();

                    var ds = await db.GtGptbkh
                    .Join(db.GtGptbkp,
                          h => new { h.BusinessKey, h.BookingKey },
                          p => new { p.BusinessKey, p.BookingKey },
                          (h, p) => new { h, p })
                    .Join(db.GtGptbkg,
                          hp => new { hp.h.BookingKey, hp.p.GuestId },
                          g => new { g.BookingKey, g.GuestId },
                          (hp, g) => new { hp, g })
                     .Join(db.GtGprmty,
                          hpg => new { hpg.hp.p.RoomTypeId },
                          r => new { r.RoomTypeId },
                          (hpg, r) => new { hpg, r })
                     .Where(w => w.hpg.hp.h.BusinessKey == businessKey
                          && ((w.hpg.hp.h.CheckInDate >= fromDate.Date && w.hpg.hp.h.CheckInDate <= fromDate.AddDays(28).Date)
                          || (w.hpg.hp.h.CheckOutDate >= fromDate.Date && w.hpg.hp.h.CheckOutDate <= fromDate.AddDays(28).Date))
                          && w.hpg.hp.h.ActiveStatus
                          && w.hpg.hp.h.BookingStatus != "CN")
                      .AsNoTracking()
                      .Select(
                        l => new DO_BookinDetails
                        {
                            BusinessKey = l.hpg.hp.h.BusinessKey,
                            BookingKey = l.hpg.hp.h.BookingKey,
                            BookingDate = l.hpg.hp.h.BookingDate,
                            CheckInDate = l.hpg.hp.h.CheckInDate,
                            CheckOutDate = l.hpg.hp.h.CheckOutDate,
                            FirstName = l.hpg.g.FirstName,
                            LastName = l.hpg.g.LastName,
                            GuestName = l.hpg.g.FirstName + " " + l.hpg.g.LastName,
                            Gender = l.hpg.g.Gender,
                            MobileNumber = l.hpg.g.MobileNumber,
                            EmailId = l.hpg.g.EmailId,
                            Place = l.hpg.g.Place,
                            Uhid = l.hpg.g.Uhid,
                            GuestId = l.hpg.g.GuestId,
                            IsCheckedIn = l.hpg.g.IsCheckedIn,
                            ActualCheckedInDate = l.hpg.g.ActualCheckedInDate,
                            IsCheckedOut = l.hpg.g.IsCheckedOut,
                            ActualCheckedOutDate = l.hpg.g.ActualCheckedOutDate,
                            RoomTypeId = l.hpg.hp.p.RoomTypeId,
                            RoomTypeDesc = l.r.RoomTypeDesc,//db.GtGprmty.Where(w => w.RoomTypeId == l.hp.p.RoomTypeId).Select(s => s.RoomTypeDesc).FirstOrDefault(),
                            RoomNumber = l.hpg.hp.p.RoomNumber,
                            BedNumber = l.hpg.hp.p.BedNumber,
                            OccupancyType = l.hpg.hp.p.OccupancyType,
                            NoOfWeeks = l.hpg.hp.p.NoOfWeeks,
                            NoOfMaleGuest = l.hpg.hp.h.NoOfMaleGuest,
                            NoOfFemaleGuest = l.hpg.hp.h.NoOfFemaleGuest,
                            TotalPackageAmount = l.hpg.hp.h.TotalPackageAmount,
                            BookingStatus = l.hpg.g.IsCheckedOut ? "CO" : (l.hpg.g.IsCheckedIn ? "CI" : l.hpg.hp.h.BookingStatus),
                            UserID = l.hpg.hp.h.CreatedBy
                        }).ToListAsync();

                    var bookingRooms = rm_reservation.Union(ds);

                    return bookingRooms.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public async Task<List<DO_BedMaster>> GetActiveRoomBedMaster(DateTime fromDate, DateTime toDate)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {

                    var rm_reservation = db.GtGprmrv
             .Where(w => ((fromDate.Date == w.EffectiveDate.Date)
                         || (fromDate.Date == w.TillDate.Date)
                         || (fromDate.Date < w.EffectiveDate.Date && toDate >= w.EffectiveDate.Date)
                         || (fromDate.Date > w.EffectiveDate.Date && fromDate.Date <= w.TillDate.Date))
                  && w.ActiveStatus).ToList();

                    var ds = db.GtGprmbm.Where(w=> w.ActiveStatus)
                        .Join(db.GtGprmty.Where(w => w.ActiveStatus),
                          x => x.RoomTypeId,
                          y => y.RoomTypeId,
                          (x, y) => new DO_BedMaster
                          {
                              RoomTypeId = x.RoomTypeId,
                              RoomNumber = x.RoomNumber,
                              BedNumber = x.BedNumber,
                              Gender = x.Gender,
                              ReservedStatus = rm_reservation.Where(w=>w.RoomTypeId == x.RoomTypeId && w.RoomNumber == x.RoomNumber && w.BedNumber == x.BedNumber).Count() > 0 ? true : false,
                              CheckedIn = x.CheckedIn,
                              CheckedOut = x.CheckedOut,
                              ReadyForOccupancy = x.ReadyForOccupancy,
                              ActiveStatus = x.ActiveStatus,
                              RoomTypeDesc = y.RoomTypeDesc
                          }).ToListAsync();
                    return await ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
