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
   public class LaundryRepository:ILaundryRepository
    {
        public async Task<List<DO_GuestCheckInDetails>> GetCheckInGuestDetailsByBookingKey(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                var gd = await db.GtGptbkh
                    .Join(db.GtGptbkp,
                        h => new { h.BusinessKey, h.BookingKey },
                        p => new { p.BusinessKey, p.BookingKey },
                        (h, p) => new { h, p })
                    .Join(db.GtGptbkg,
                        hp => new { hp.p.BusinessKey, hp.p.BookingKey, hp.p.GuestId },
                        g => new { g.BusinessKey, g.BookingKey, g.GuestId },
                        (hp, g) => new { hp, g })
                    .Where(w => w.hp.p.BusinessKey == businessKey && w.g.IsCheckedIn==true && w.g.IsCheckedOut==false)
                    .Select(r => new DO_GuestCheckInDetails
                    {
                        BookingKey = r.hp.h.BookingKey,
                        PackageId = r.hp.h.PackageId,
                        PackageDesc = db.GtGppkms.Where(w => w.PackageId == r.hp.h.PackageId).FirstOrDefault().PackageDesc,
                        TotalPackageAmount = r.hp.h.TotalPackageAmount,
                        TotalDiscountAmount = r.hp.h.TotalDiscountAmount,
                        NetPackageAmount = r.hp.h.NetPackageAmount,
                        CheckedInDate = r.hp.h.CheckInDate,
                        CheckedOutDate = r.hp.h.CheckOutDate,
                        RoomTypeName = db.GtGprmty.Where(w => w.RoomTypeId == r.hp.p.RoomTypeId).FirstOrDefault().RoomTypeDesc,
                        RoomNumber = r.hp.p.RoomNumber,
                        BedNumber = r.hp.p.BedNumber,
                        OccupancyType = r.hp.p.OccupancyType,
                        PackagePrice = r.hp.p.PackagePrice,
                        GuestId = r.hp.p.GuestId,
                        FirstName = r.g.FirstName,
                        LastName = r.g.LastName,
                        Gender = r.g.Gender,
                        AgeYy = r.g.AgeYy,
                        MobileNumber = r.g.MobileNumber,
                        EmailId = r.g.EmailId,
                        Place = r.g.Place,
                        UHID = r.g.Uhid,
                        Address = r.g.Address,
                        AreaCode = r.g.AreaCode,
                        CityCode = r.g.CityCode,
                        StateCode = r.g.StateCode,
                        Pincode = r.g.Pincode,
                        IsCheckedIn = r.g.IsCheckedIn,
                        IsCheckedOut = r.g.IsCheckedOut,
                        Isdcode = r.g.Isdcode
                    }).ToListAsync();
                return gd;
            }
        }

        public async Task<List<DO_ServiceRates>> GetLaundryServiceList(int businessKey,string gender,string ServiceCriteria)
        {
            using (var db = new eSyaEnterprise())
            {
                var sr = await db.GtEssrms
                    .Join(db.GtEssrbl,
                        s => new { s.ServiceId },
                        b => new { b.ServiceId },
                        (s, b) => new { s, b })
                    .Join(db.GtEssrcl,
                        sb => new { sb.s.ServiceClassId },
                        c => new { c.ServiceClassId },
                        (sb, c) => new { sb, c })
                   .Join(db.GtEssrgr,
                        sbc => new { sbc.c.ServiceGroupId },
                        g => new { g.ServiceGroupId },
                        (sbc, g) => new { sbc, g })
                    .Where(w => w.sbc.sb.b.BusinessKey == businessKey && w.sbc.sb.s.Gender.ToUpper().Replace(" ", "") == gender.ToUpper().Replace(" ", "")
                            || w.sbc.sb.s.Gender=="A"
                            && w.sbc.sb.s.ActiveStatus && w.sbc.sb.b.ActiveStatus
                            && w.sbc.c.ActiveStatus && w.g.ActiveStatus && w.g.ServiceCriteria.ToUpper().Replace(" ", "")== ServiceCriteria.ToUpper().Replace(" ", ""))
                    .Select(r => new DO_ServiceRates
                    {
                        ServiceTypeId = r.g.ServiceTypeId,
                        ServiceId = r.sbc.sb.s.ServiceId,
                        ServiceDesc = r.sbc.sb.s.ServiceDesc
                    })
                    .ToListAsync();

                return sr;
            }
        }

        public async Task<DO_ServiceRates> GetLaundryServiceRates(int businessKey, int serviceId, int rateType, string currencyCode)
        {
            using (var db = new eSyaEnterprise())
            {
                var sr = await db.GtEssrms
                    .Join(db.GtEssrbl,
                        s => new { s.ServiceId },
                        b => new { b.ServiceId },
                        (s, b) => new { s, b })
                    .Join(db.GtEssrbr
                        .Where(w => w.RateType == rateType && w.CurrencyCode == currencyCode
                            && w.ActiveStatus
                            // && w.EffectiveDate.Date >= System.DateTime.Now.Date 
                            && DateTime.Now.Date <= (w.EffectiveTill == null ? DateTime.Now.Date : w.EffectiveTill.Value.Date)),
                        sb => new { sb.b.BusinessKey, sb.b.ServiceId },
                        r => new { r.BusinessKey, r.ServiceId },
                        (sb, r) => new { sb, r })
                        .Where(w => w.sb.b.BusinessKey == businessKey && w.sb.s.ServiceId == serviceId

                            && w.sb.s.ActiveStatus && w.sb.b.ActiveStatus && w.r.ActiveStatus
                        )
                    .Select(r => new DO_ServiceRates
                    {
                        ServiceId = r.sb.s.ServiceId,
                        ServiceDesc = r.sb.s.ServiceDesc,
                        ServiceRule = r.r.ServiceRule,
                        ServiceRate = r.r.OpbaseRate
                    })
                    .FirstOrDefaultAsync();

                return sr;
            }
        }

        public async Task<List<DO_Service>> GetGuestLaundryServiceByBookingKey(int businessKey, long bookingKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbsv.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey).
                        Join(db.GtEssrms,
                          x => x.ServiceId,
                          y => y.ServiceId,
                        (x, y) => new DO_Service
                        {
                            BusinessKey = x.BusinessKey,
                            BookingKey = x.BookingKey,
                            SerialNumber = x.SerialNumber,
                            ServiceDate = x.ServiceDate,
                            ServiceTypeId = x.ServiceTypeId,
                            ServiceId = x.ServiceId,
                            Quantity = x.Quantity,
                            Rate = x.Rate,
                            DiscountAmount = x.DiscountAmount,
                            ConcessionAmount = x.ConcessionAmount,
                            ServiceChargeAmount = x.ServiceChargeAmount,
                            TotalAmount = x.TotalAmount,
                            ServiceName = y.ServiceDesc,
                            ActiveStatus = x.ActiveStatus
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertGuestLaundryService(DO_Service obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        int maxval = db.GtGptbsv.Select(d => d.SerialNumber).DefaultIfEmpty().Max();
                        int serial_no = maxval + 1;
                        if (obj.ServiceDate != null)
                        {
                            TimeSpan time = DateTime.Now.TimeOfDay;
                            obj.ServiceDate = obj.ServiceDate + time;
                        }
                        var svc = new GtGptbsv
                        {
                            BusinessKey = obj.BusinessKey,
                            BookingKey = obj.BookingKey,
                            SerialNumber = serial_no,
                            ServiceDate = obj.ServiceDate,
                            ServiceTypeId = obj.ServiceTypeId,
                            ServiceId = obj.ServiceId,
                            Quantity = obj.Quantity,
                            Rate = obj.Rate,
                            DiscountAmount = obj.DiscountAmount,
                            ConcessionAmount = obj.ConcessionAmount,
                            ServiceChargeAmount = obj.ServiceChargeAmount,
                            TotalAmount = obj.TotalAmount,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };

                        db.GtGptbsv.Add(svc);
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Service Added Successfully" };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateGuestLaundryService(DO_Service obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        var _Service = db.GtGptbsv.FirstOrDefault(x => x.BusinessKey == obj.BusinessKey && x.BookingKey==obj.BookingKey && x.SerialNumber==obj.SerialNumber);
                        if (_Service != null)
                        {
                            _Service.ServiceDate = obj.ServiceDate;
                            _Service.ServiceTypeId = obj.ServiceTypeId;
                            _Service.ServiceId = obj.ServiceId;
                            _Service.Quantity = obj.Quantity;
                            _Service.Rate = obj.Rate;
                            _Service.DiscountAmount = obj.DiscountAmount;
                            _Service.ConcessionAmount = obj.ConcessionAmount;
                            _Service.ServiceChargeAmount = obj.ServiceChargeAmount;
                            _Service.TotalAmount = obj.TotalAmount;
                            _Service.ActiveStatus = obj.ActiveStatus;
                            _Service.ModifiedBy = obj.UserID;
                            _Service.ModifiedOn = DateTime.Now;
                            _Service.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Updated sucessfully." };
                           
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Service not Exists" };
                        }

                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> ActiveOrDeActiveGuestLaundryService(bool status, int businessKey, long bookingKey,int SerialNumber)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _Service = db.GtGptbsv.FirstOrDefault(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey && x.SerialNumber == SerialNumber);
                        if (_Service == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Service  does not exist" };
                        }

                        _Service.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Service  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Service  De Activated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));

                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
