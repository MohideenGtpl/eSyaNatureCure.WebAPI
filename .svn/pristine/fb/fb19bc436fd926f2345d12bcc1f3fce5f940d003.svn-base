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
    public class FirstConsultationRepository : IFirstConsultationRepository
    {
        public async Task<List<DO_BookinDetails>> GetConsultaionList(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbkg
                        .Join(db.GtGptbkh,
                        d=> new { d.BusinessKey, d.BookingKey },
                        h=> new { h.BusinessKey, h.BookingKey },
                        (d, h) => new { d, h })
                        .Where(w=> w.d.BusinessKey == businessKey 
                        && w.h.CheckInDate.Date <= System.DateTime.Now.Date 
                        && w.d.IsCheckedIn==true
                        && w.d.IsCheckedOut==false
                        && w.d.IsDoctorConsulted==false
                        && w.d.ActiveStatus)
                        .Select(r =>
                         new DO_BookinDetails
                         {
                             BookingKey=r.d.BookingKey,
                             GuestId = r.d.GuestId,
                             PackageId=r.h.PackageId,
                             Uhid=r.d.Uhid,
                             FirstName = r.d.FirstName,
                             LastName = r.d.LastName,
                             Gender = r.d.Gender,
                             AgeYy = r.d.AgeYy,
                             MobileNumber = r.d.MobileNumber,
                             EmailId = r.d.EmailId

                         }).ToListAsync();

                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<DO_ReturnParameter> ConsultaionConfirmation(DO_GuestCheckInDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var bd = await db.GtGptbkg.Where(w => w.BusinessKey == obj.BusinessKey && w.BookingKey == obj.BookingKey && w.GuestId == obj.GuestId).FirstOrDefaultAsync();                       
                        if (bd != null)
                        {
                            bd.IsDoctorConsulted  = true;
                            
                            bd.ModifiedBy = obj.UserID;
                            bd.ModifiedOn = System.DateTime.Now;
                            bd.ModifiedTerminal = obj.TerminalID;
                        }
                        var l_activity = await db.GtGppkcv
                             .Where(w => w.PackageId == obj.PackageId && w.ActiveStatus)
                             .Select(r =>
                          new GtGptbah 
                          {
                              BusinessKey = obj.BusinessKey,
                              Ipnumber = Convert.ToUInt32(obj.BookingKey.ToString() + obj.GuestId.ToString()),
                              SerialNumber = 0,
                              HospitalNumber = obj.UHID ?? 0,
                              ActivityId =r.ActivityId,
                              ActivityDayId=r.DayId,
                              ActivityDate= System.DateTime.Now.Date.AddDays(r.DayId-1),
                              ActivityFromTime=r.FromTime ?? new TimeSpan(),
                              ActivityToTime=r.ToTime ?? new TimeSpan(),
                              ActiveStatus=true,
                              ActivityStatus="N",

                              FormId=obj.FormID,
                              CreatedBy= obj.UserID,
                              CreatedOn = System.DateTime.Now,
                              CreatedTerminal = obj.TerminalID,
                          }
                            ).ToListAsync();
                        var _serial = db.GtGptbah
                            .Where(w=> w.BusinessKey==obj.BusinessKey && w.Ipnumber== Convert.ToUInt32(obj.BookingKey.ToString() + obj.GuestId.ToString()))
                            .Select(s => s.SerialNumber).DefaultIfEmpty().Max();
                        foreach (GtGptbah ac in l_activity)
                        {
                            _serial += 1;
                            ac.SerialNumber = _serial;
                            db.GtGptbah.Add(ac);
                        }
                        
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, Message = "Confirmed Sucessfully" };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public async Task<DO_GuestCheckInDetails> GetGuestDetails(int businessKey, long bookingKey, int guestId)
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
                    .Where(w => w.hp.p.BusinessKey == businessKey && w.hp.h.BookingKey == bookingKey && w.hp.p.GuestId == guestId)
                    .Select(r => new DO_GuestCheckInDetails
                    {
                        BookingKey = r.hp.h.BookingKey,
                        PackageId = r.hp.h.PackageId,
                        PackageDesc = db.GtGppkms.Where(w => w.PackageId == r.hp.h.PackageId).FirstOrDefault().PackageDesc,
                        CheckedInDate = r.hp.h.CheckInDate,
                        CheckedOutDate = r.hp.h.CheckOutDate,
                        RoomTypeName = db.GtGprmty.Where(w => w.RoomTypeId == r.hp.p.RoomTypeId).FirstOrDefault().RoomTypeDesc,
                        RoomNumber = r.hp.p.RoomNumber,
                        BedNumber = r.hp.p.BedNumber,
                        OccupancyType = r.hp.p.OccupancyType,
                        GuestId = r.hp.p.GuestId,
                        FirstName = r.g.FirstName,
                        LastName = r.g.LastName,
                        Gender = r.g.Gender,
                        AgeYy = r.g.AgeYy,
                        MobileNumber = r.g.MobileNumber,
                        EmailId = r.g.EmailId,
                        UHID = r.g.Uhid,                      
                    })
                    .FirstOrDefaultAsync();

                if (gd.UHID > 0)
                {
                    var pp = await db.GtEfoppr.Where(x => x.RUhid == gd.UHID).FirstOrDefaultAsync();
                    gd.FirstName = pp.FirstName;
                    gd.LastName = pp.LastName;
                    gd.EmailId = pp.EMailId;
                    gd.Isdcode = pp.Isdcode;
                    gd.MobileNumber = pp.MobileNumber;
                    gd.ImageUrl = pp.ImageUrl;

                    gd.IsDOBApplicable = pp.IsDobapplicable;
                    gd.DateOfBirth = pp.DateOfBirth;
                }

                return gd;
            }
        }
        public async Task<DO_GuestActivities> GetGuestActivities(int businessKey, long ipNumber)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ac = await db.GtGptbah
                   .Join(db.GtGpacms,
                       g => new { g.ActivityId },
                       a => new { a.ActivityId },
                       (g, a) => new { g, a })
                    .GroupJoin(db.GtGpdept,
                    ga => ga.a.DepartmentId,
                    d => d.DepartmentId,
                    (ga,d) => new { ga,d=d.FirstOrDefault()})
                    .GroupJoin(db.GtEuusms,
                    gad => gad.ga.g.CreatedBy,
                    c=> c.UserId,
                    (gad,c)=> new { gad,c=c.FirstOrDefault()})
                    .GroupJoin(db.GtEuusms,
                    gadc => gadc.gad.ga.g.ModifiedBy,
                    m => m.UserId,
                    (gadc, m) => new { gadc, m=m.FirstOrDefault() })
                   .Where(w => w.gadc.gad.ga.g.BusinessKey == businessKey && w.gadc.gad.ga.g.Ipnumber == ipNumber)
                   .Select(r => new DO_GuestActivity
                   {
                       BusinessKey = r.gadc.gad.ga.g.BusinessKey,
                       Ipnumber = r.gadc.gad.ga.g.Ipnumber,
                       SerialNumber = r.gadc.gad.ga.g.SerialNumber,
                       ActivityId = r.gadc.gad.ga.g.ActivityId,
                       ActivityDesc = r.gadc.gad.ga.a.ActivityDesc,
                       ActivityDayId = r.gadc.gad.ga.g.ActivityDayId,
                       ActivityDate = r.gadc.gad.ga.g.ActivityDate,
                       ActivityFromTime = r.gadc.gad.ga.g.ActivityFromTime,
                       ActivityToTime = r.gadc.gad.ga.g.ActivityToTime,
                       ActivityDurationHH = Math.Round( r.gadc.gad.ga.g.ActivityToTime.TotalHours - r.gadc.gad.ga.g.ActivityFromTime.TotalHours,2),
                       ActivityDurationMM = r.gadc.gad.ga.g.ActivityToTime.TotalMinutes - r.gadc.gad.ga.g.ActivityFromTime.TotalMinutes,
                       
                       DepartmentId= r.gadc.gad.ga.a.DepartmentId ?? 0,
                       DepartmentDesc = r.gadc.gad.d.DepartmentDesc ?? "N/A",

                       ActiveStatus= r.gadc.gad.ga.g.ActiveStatus,
                       ModifiedUser = r.gadc.gad.ga.g.ModifiedBy == null? r.gadc.c !=null? r.gadc.c.LoginDesc:"N/A" : r.m != null? r.m.LoginDesc:"N/A",
                       ModifiedOn = r.gadc.gad.ga.g.ModifiedOn == null ? r.gadc.gad.ga.g.CreatedOn : r.gadc.gad.ga.g.ModifiedOn


                   })
                   .OrderBy(o=> o.ActivityFromTime)
                   .ToListAsync();

                    var _header = ac.GroupBy(g => new { g.ActivityDate, g.ActivityDayId })
                        .Select(x => new DO_GuestActivityHeader
                        {
                            ActivityDayId=x.Key.ActivityDayId,
                            ActivityDate=x.Key.ActivityDate,
                            ActivityDurationHH = x.Sum(s => s.ActivityDurationHH)
                        }).ToList();

                    var _ac = new DO_GuestActivities();
                    
                    _ac.l_activityheader = _header;
                    _ac.l_activitydetails = ac;


                    return _ac;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
               
            }
        }
        public async Task<DO_ReturnParameter> AddOrUpdateGuestActivity(DO_GuestActivity obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (obj.SerialNumber == 0)
                        {
                            var _serial = db.GtGptbah
                            .Where(w => w.BusinessKey == obj.BusinessKey && w.Ipnumber == obj.Ipnumber)
                            .Select(s => s.SerialNumber).DefaultIfEmpty().Max();
                            _serial += 1;

                            var _activityDayId = db.GtGptbah
                            .Where(w => w.BusinessKey == obj.BusinessKey && w.Ipnumber == obj.Ipnumber && w.ActivityDate == obj.ActivityDate)
                            .Select(s => s.ActivityDayId).FirstOrDefault();

                            var ga = new GtGptbah
                            {
                                BusinessKey = obj.BusinessKey,
                                Ipnumber = obj.Ipnumber,
                                SerialNumber = _serial,
                                HospitalNumber = obj.HospitalNumber,
                                ActivityId = obj.ActivityId,
                                ActivityDayId = _activityDayId,
                                ActivityDate = obj.ActivityDate,
                                ActivityFromTime = obj.ActivityFromTime,
                                ActivityToTime = obj.ActivityToTime,
                                ActiveStatus = true,
                                ActivityStatus = "N",

                                FormId = obj.FormId,
                                CreatedBy = obj.CreatedBy,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.CreatedTerminal,
                            };
                            db.GtGptbah.Add(ga);
                        }
                        else
                        {
                            var ga = await db.GtGptbah.Where(w => w.BusinessKey == obj.BusinessKey && w.Ipnumber == obj.Ipnumber && w.SerialNumber == obj.SerialNumber).FirstOrDefaultAsync();
                            if (ga != null)
                            {
                                ga.ActiveStatus = obj.ActiveStatus;

                                ga.ModifiedBy = obj.CreatedBy;
                                ga.ModifiedOn = System.DateTime.Now;
                                ga.ModifiedTerminal = obj.CreatedTerminal;
                            }
                        }
                        
                        

                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, Message = "Updated Sucessfully" };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public async Task<List<DO_Activities>> GetActivities()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ac = await db.GtGpacms
                   .Where(w => w.ActiveStatus)
                   .Select(a => new DO_Activities
                   {                     
                       ActivityId = a.ActivityId,
                       ActivityDesc = a.ActivityDesc                    
                   })
                   .ToListAsync();

                    return ac;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}
