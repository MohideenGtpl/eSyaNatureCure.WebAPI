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
   public class DepartmentClearanceRepository:IDepartmentClearanceRepository
    {
        public async Task <List<DO_BookinDetails>> GetDepartmentNotClearedGuests(int businessKey)
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
                       .Where(w => w.h.BusinessKey == businessKey &&
                        w.h.CheckOutDate.Date < System.DateTime.Now.Date && w.h.ActiveStatus && !w.g.IsCheckedOut && w.g.IsCheckedIn).AsNoTracking()
                      .Select(
                        l => new DO_BookinDetails
                        {
                            BusinessKey = l.h.BusinessKey,
                            BookingKey = l.h.BookingKey,
                            BookingDate = l.h.BookingDate,
                            CheckInDate = l.h.CheckInDate,
                            CheckOutDate = l.h.CheckOutDate,
                            BookingStatus = l.h.BookingStatus,
                            FirstName = l.g.FirstName,
                            LastName = l.g.LastName,
                            GuestName = l.g.FirstName + " " + l.g.LastName,
                            Gender = l.g.Gender,
                            MobileNumber = l.g.MobileNumber,
                            EmailId = l.g.EmailId,
                            Place = l.g.Place,
                            Uhid = l.g.Uhid,
                            GuestId = l.g.GuestId,
                            IsCheckedIn = l.g.IsCheckedIn,
                            ActualCheckedInDate = l.g.ActualCheckedInDate,
                            IsCheckedOut = l.g.IsCheckedOut,
                            ActualCheckedOutDate = l.g.ActualCheckedOutDate,
                            DeptStatus=false
                        }).ToListAsync();
                    var deptlis = GetAllDO_DepartmentClearance();
                    if (deptlis != null)
                    {
                        foreach(var d in deptlis)
                        {
                            var dept = ds.Where(x => x.BusinessKey == d.BusinessKey && x.BookingKey == d.BookingKey && x.GuestId == d.GuestId).FirstOrDefault();
                            if (dept != null)
                            {
                                ds.Remove(dept);

                            }
                        }
                    }
                    return  ds;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public async Task<DO_ReturnParameter> InsertIntoDepartmentClearance(DO_DepartmentClearance obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGptbdc is_deptExists = db.GtGptbdc.FirstOrDefault(a => a.BusinessKey == obj.BusinessKey && a.BookingKey==obj.BookingKey && a.GuestId==obj.GuestId && a.DepartmentId==obj.DepartmentId);
                        if (is_deptExists == null)
                        {
                           
                            var dept = new GtGptbdc
                            {
                                BusinessKey = obj.BusinessKey,
                                BookingKey = obj.BookingKey,
                                GuestId = obj.GuestId,
                                DepartmentId = obj.DepartmentId,
                                ClearanceStatus=obj.ClearanceStatus,
                                Comments=obj.Comments,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGptbdc.Add(dept);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Department Clearance Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Department Clearance  is already Exists try another one." };
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

        public async Task<DO_DepartmentUserLink> GetDepartmentbyUserId(int UserId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {


                    var ds = db.GtGpdpus.Where(x => x.UserId == UserId).Join(db.GtGpdept, lkey => new { lkey.DepartmentId },
                        ent => new { ent.DepartmentId },
                        (lkey, ent) => new { lkey, ent }).Join(db.GtEuusms,
                        Bloc => new { Bloc.lkey.UserId },
                        seg => new { seg.UserId },
                        (Bloc, seg) => new { Bloc, seg })
                        .Select(c => new DO_DepartmentUserLink
                        {
                            DepartmentId = c.Bloc.lkey.DepartmentId,
                            UserId = c.Bloc.lkey.UserId,
                            ActiveStatus = c.Bloc.lkey.ActiveStatus,
                            DepartmentName = c.Bloc.ent.DepartmentDesc,
                            UserName = c.seg.LoginDesc

                        }).FirstOrDefaultAsync();
                    return await ds;





                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<DO_DepartmentClearance> GetAllDO_DepartmentClearance()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbdc.Select(x =>
                         new DO_DepartmentClearance
                         {
                             BusinessKey = x.BusinessKey,
                             BookingKey = x.BookingKey,
                             GuestId = x.GuestId,
                             ActiveStatus = x.ActiveStatus,
                             DepartmentId = x.DepartmentId,
                             ClearanceStatus=x.ClearanceStatus
                         }).ToList();
                    return  ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_BookinDetails>> GetAllDepartmentClearedGuestbyBusinessKey(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = await db.GtGptbdc
                    .Join(db.GtGptbkh,
                      h => h.BookingKey,
                      g => g.BookingKey,
                      (h, g) => new { h, g })
                       .Join(db.GtGptbkg,
                      hg => new { hg.h.BookingKey, hg.h.GuestId },
                      p => new { p.BookingKey, p.GuestId },
                      (hg, p) => new { hg, p })
                      .Where(w => w.hg.h.BusinessKey == businessKey)
                      .Select(
                        l => new DO_BookinDetails
                        {
                            BusinessKey = l.hg.h.BusinessKey,
                            BookingKey = l.hg.h.BookingKey,
                            BookingDate = l.hg.g.BookingDate,
                            CheckInDate = l.hg.g.CheckInDate,
                            CheckOutDate = l.hg.g.CheckOutDate,
                            BookingStatus = l.hg.g.BookingStatus,
                            FirstName = l.p.FirstName,
                            LastName = l.p.LastName,
                            GuestName = l.p.FirstName + " " + l.p.LastName,
                            Gender = l.p.Gender,
                            MobileNumber = l.p.MobileNumber,
                            EmailId = l.p.EmailId,
                            Place = l.p.Place,
                            Uhid = l.p.Uhid,
                            GuestId = l.p.GuestId,
                            IsCheckedIn = l.p.IsCheckedIn,
                            ActualCheckedInDate = l.p.ActualCheckedInDate,
                            IsCheckedOut = l.p.IsCheckedOut,
                            ActualCheckedOutDate = l.p.ActualCheckedOutDate,
                            DeptStatus=true
                        }).ToListAsync();
                  
                    return ds;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public async Task<List<DO_DepartmentClearenceDetails>> GetDepartmentClearencePreviousCheckoutdetails(int businesskey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    var ds = await db.GtGptbdc
                        .Join(db.GtGptbkh,
                             dc => new { dc.BusinessKey, dc.BookingKey },
                             gh => new { gh.BusinessKey, gh.BookingKey },
                             (dc, gh) => new { dc, gh })
                             .Join(db.GtGptbkg,
                             dcc => new { dcc.dc.BusinessKey, dcc.dc.BookingKey, dcc.dc.GuestId, },
                             gd => new { gd.BusinessKey, gd.BookingKey, gd.GuestId },
                            (dcc, gd) => new { dcc, gd })
                         .Join(db.GtGpdept,
                            dccc => new { dccc.dcc.dc.DepartmentId },
                             dm => new { dm.DepartmentId },
                            (dccc, dm) => new { dccc, dm })
                           .Where(w => w.dccc.dcc.dc.BusinessKey == businesskey && w.dccc.dcc.gh.CheckOutDate.Date < System.DateTime.Now.Date)

                        .Select(r => new DO_DepartmentClearenceDetails
                        {
                            BusinessKey = r.dccc.dcc.gh.BusinessKey,
                            BookingKey = r.dccc.dcc.gh.BookingKey,
                            BookingDate = r.dccc.dcc.gh.BookingDate.Date,
                            CheckInDate = r.dccc.dcc.gh.CheckInDate.Date,
                            CheckOutDate = r.dccc.dcc.gh.CheckOutDate.Date,
                            GuestName = r.dccc.gd != null ? r.dccc.gd.FirstName + " " + r.dccc.gd.LastName : "",
                            FirstName = r.dccc.gd != null ? r.dccc.gd.FirstName : "",
                            LastName = r.dccc.gd != null ? r.dccc.gd.LastName : "",
                            Age = r.dccc.gd.AgeYy,
                            Gender = r.dccc.gd.Gender,
                            MobileNo = r.dccc.gd.MobileNumber,
                            Place = r.dccc.gd.Place,
                            NetPackageAmount = r.dccc.dcc.gh.NetPackageAmount,
                            PaymentMethod = r.dccc.dcc.gh.PaymentMethod,
                            PaymentReceived = r.dccc.dcc.gh.PaymentReceived,
                            GuestId = r.dccc.dcc.dc.GuestId,
                            DepartmentName = r.dm.DepartmentDesc,
                            DepartmentStatus = r.dccc.gd.IsCheckedOut ? "CLEARED" : (r.dccc.gd.IsCheckedIn ? "UNCLEARED" : r.dccc.dcc.gh.BookingStatus)
                        }).ToListAsync();


                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_DepartmentClearenceDetails>> GetDepartmentClearenceCurrentCheckoutdetails(int businesskey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    var ds = await db.GtGptbdc
                        .Join(db.GtGptbkh,
                             dc => new { dc.BusinessKey, dc.BookingKey },
                             gh => new { gh.BusinessKey, gh.BookingKey },
                             (dc, gh) => new { dc, gh })
                             .Join(db.GtGptbkg,
                             dcc => new { dcc.dc.BusinessKey, dcc.dc.BookingKey, dcc.dc.GuestId, },
                             gd => new { gd.BusinessKey, gd.BookingKey, gd.GuestId },
                            (dcc, gd) => new { dcc, gd })
                         .Join(db.GtGpdept,
                            dccc => new { dccc.dcc.dc.DepartmentId },
                             dm => new { dm.DepartmentId },
                            (dccc, dm) => new { dccc, dm })
                           .Where(w => w.dccc.dcc.dc.BusinessKey == businesskey && w.dccc.dcc.gh.CheckOutDate.Date ==System.DateTime.Now.Date)

                        .Select(r => new DO_DepartmentClearenceDetails
                        {
                            BusinessKey = r.dccc.dcc.gh.BusinessKey,
                            BookingKey = r.dccc.dcc.gh.BookingKey,
                            BookingDate = r.dccc.dcc.gh.BookingDate.Date,
                            CheckInDate = r.dccc.dcc.gh.CheckInDate.Date,
                            CheckOutDate = r.dccc.dcc.gh.CheckOutDate.Date,
                            GuestName = r.dccc.gd != null ? r.dccc.gd.FirstName + " " + r.dccc.gd.LastName : "",
                            FirstName = r.dccc.gd != null ? r.dccc.gd.FirstName : "",
                            LastName = r.dccc.gd != null ? r.dccc.gd.LastName : "",
                            Age = r.dccc.gd.AgeYy,
                            Gender = r.dccc.gd.Gender,
                            MobileNo = r.dccc.gd.MobileNumber,
                            Place = r.dccc.gd.Place,
                            NetPackageAmount = r.dccc.dcc.gh.NetPackageAmount,
                            PaymentMethod = r.dccc.dcc.gh.PaymentMethod,
                            PaymentReceived = r.dccc.dcc.gh.PaymentReceived,
                            GuestId = r.dccc.dcc.dc.GuestId,
                            DepartmentName = r.dm.DepartmentDesc,
                            DepartmentStatus = r.dccc.gd.IsCheckedOut ? "CLEARED" : (r.dccc.gd.IsCheckedIn ? "UNCLEARED" : r.dccc.dcc.gh.BookingStatus)
                        }).ToListAsync();


                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
