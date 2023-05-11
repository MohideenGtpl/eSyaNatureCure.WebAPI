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
    public class GuestCheckInRepository : IGuestCheckInRepository
    {
        //public async Task<DO_GuestCheckInDetails> GetGuestDetailById(int businessKey, long bookingKey, int guestId)
        //{
        //    using (var db = new eSyaEnterprise())
        //    {
        //        var gd = await db.GtGptbkh
        //            .Join(db.GtGptbkp,
        //                h => new { h.BusinessKey, h.BookingKey},
        //                p => new { p.BusinessKey, p.BookingKey},
        //                (h, p) => new { h, p })
        //            .Join(db.GtGptbkg,
        //                hp => new { hp.p.BusinessKey, hp.p.BookingKey, hp.p.GuestId },
        //                g => new { g.BusinessKey, g.BookingKey, g.GuestId },
        //                (hp, g) => new { hp, g })
        //            .Where(w => w.hp.p.BusinessKey == businessKey && w.hp.h.BookingKey == bookingKey && w.hp.p.GuestId == guestId)
        //            .Select(r=> new DO_GuestCheckInDetails
        //            {
        //                BookingKey = r.hp.h.BookingKey,
        //                PackageId = r.hp.h.PackageId,
        //                PackageDesc =  db.GtGppkms.Where(w=>w.PackageId == r.hp.h.PackageId).FirstOrDefault().PackageDesc,
        //                TotalPackageAmount = r.hp.h.TotalPackageAmount,
        //                CheckedInDate = r.hp.h.CheckInDate,
        //                CheckedOutDate = r.hp.h.CheckOutDate,
        //                RoomTypeName = db.GtGprmty.Where(w=>w.RoomTypeId == r.hp.p.RoomTypeId).FirstOrDefault().RoomTypeDesc,
        //                RoomNumber = r.hp.p.RoomNumber,
        //                BedNumber = r.hp.p.BedNumber,
        //                OccupancyType = r.hp.p.OccupancyType,
        //                PackagePrice = r.hp.p.PackagePrice,
        //                GuestId = r.hp.p.GuestId,
        //                FirstName = r.g.FirstName,
        //                LastName = r.g.LastName,
        //                Gender = r.g.Gender,
        //                AgeYy = r.g.AgeYy,
        //                MobileNumber = r.g.MobileNumber,
        //                EmailId = r.g.EmailId,
        //                UHID = r.g.Uhid,
        //                Address = r.g.Address,
        //                AreaCode = r.g.AreaCode,
        //                CityCode = r.g.CityCode,
        //                Pincode = r.g.Pincode,
        //                IsCheckedIn = r.g.IsCheckedIn,
        //                IsCheckedOut = r.g.IsCheckedOut
        //            })
        //            .FirstOrDefaultAsync();

        //        return gd;
        //    }
        //}

        public async Task<DO_GuestCheckInDetails> GetGuestDetailById(int businessKey, long bookingKey, int guestId)
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
                        lst_Patient = db.GtEfoppr.Where(x => x.MobileNumber == r.g.MobileNumber && x.Gender == r.g.Gender )
                        .Select(h => new Do_PatientMaster
                        {
                            FirstName = h.FirstName,
                            MiddleName = h.MiddleName,
                            LastName = h.LastName,
                            RUhid = h.RUhid,
                            SUhid = h.SUhid,
                            PatientId = h.PatientId,
                            Isdcode = h.Isdcode,
                            MobileNumber = h.MobileNumber,
                            ImageUrl=h.ImageUrl
                        }).ToList()

                    })
                    .FirstOrDefaultAsync();

                if(gd.UHID > 0)
                {
                    var pp = await db.GtEfoppr.Where(x => x.RUhid == gd.UHID).FirstOrDefaultAsync();
                    gd.IsDOBApplicable = pp.IsDobapplicable;
                    gd.DateOfBirth = pp.DateOfBirth;
                }
               var url= db.GtEfoppr.Where(x => x.MobileNumber == gd.MobileNumber && x.RUhid==gd.UHID).FirstOrDefault();
                if (url != null)
                {
                    gd.ImageUrl = url.ImageUrl;
                }

                return gd;
            }
        }

        public async Task<List<DO_GuestCheckInDetails>> GetGuestDetailsByBookingKey(int businessKey, long bookingKey)
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
                    .Where(w => w.hp.p.BusinessKey == businessKey && w.hp.h.BookingKey == bookingKey)
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
                        Isdcode=r.g.Isdcode
                    })
                    .ToListAsync();
                if (gd.Count > 0)
                {
                    foreach (var d in gd)
                    {
                        var pp = await db.GtEfoppr.Where(x => x.RUhid == d.UHID).FirstOrDefaultAsync();
                        if (pp != null) { 
                        d.IsDOBApplicable = pp.IsDobapplicable;
                        d.DateOfBirth = pp.DateOfBirth;
                        }
                    }

                }
                return gd;
            }
        }

        public async Task<DO_ReturnParameter> CreateGuestCheckin(DO_GuestCheckInDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        //var exists = db.GtEfoppr.Where(w => w.MobileNumber == obj.PatientMobileNumber).Count();
                        //if (exists > 0)
                        //{
                        //    return new DO_ReturnParameter() { Status = false, Message = "Mobile Number Already Exists" };
                        //}

                        var gh = await db.GtGptbkh.Where(w => w.BusinessKey == obj.BusinessKey && w.BookingKey == obj.BookingKey).FirstOrDefaultAsync();
                        if (gh.CheckInDate.Date > System.DateTime.Now.Date)
                        {
                            return new DO_ReturnParameter { Status = false, Message = "please check the checked-in date." };
                        }

                        var gd = await db.GtGptbkg.Where(w => w.BusinessKey == obj.BusinessKey && w.BookingKey == obj.BookingKey && w.GuestId == obj.GuestId).FirstOrDefaultAsync();

                        if (gd.Uhid != null)
                        {
                            return new DO_ReturnParameter { Status = false, Message = "Guest has beed already checkedin." };
                        }

                        GtEfoppr pp;
                        DateTime? dob;
                        bool isDobapplicable = false;
                        if (obj.DateOfBirth != null)
                        {
                            isDobapplicable = true;
                            dob = obj.DateOfBirth;
                        }
                        else
                            dob = System.DateTime.Now.AddYears(-gd.AgeYy);

                        if (obj.UHID == 0 || obj.UHID == null)
                        {
                            var dc_pm = await db.GtEcdcsn
                             .Where(w => w.BusinessKey == obj.BusinessKey
                                 && w.DocumentId == 1).FirstOrDefaultAsync();
                            dc_pm.CurrentDocNumber = dc_pm.CurrentDocNumber + 1;
                            var patient_id = System.DateTime.Now.ToString("yMM") + (dc_pm.CurrentDocNumber).ToString().PadLeft(4, '0');

                            pp = new GtEfoppr();
                            //{
                            pp.RUhid = dc_pm.CurrentDocNumber;
                            pp.SUhid = dc_pm.CurrentDocNumber;
                            pp.RegistrationDate = System.DateTime.Now;
                            pp.BusinessKey = obj.BusinessKey;
                            pp.FirstName = obj.FirstName;
                            pp.LastName = obj.LastName;
                            pp.Gender = gd.Gender;
                            pp.IsDobapplicable = isDobapplicable;
                            pp.DateOfBirth = dob;
                            pp.AgeYy = obj.AgeYy;
                            pp.AgeMm = 0;
                            pp.AgeDd = 0;
                            pp.Isdcode = 0;
                            pp.MobileNumber = obj.MobileNumber;
                            pp.EMailId = obj.EmailId;
                            pp.PatientStatus = "Y";
                            pp.RecordStatus = 0;
                            pp.BillStatus = "O";
                            pp.PatientId = patient_id;
                            pp.ActiveStatus = true;
                            if (obj.ImageUrl != null)
                            {
                                pp.ImageUrl = obj.ImageUrl;
                            }
                            pp.CreatedBy = obj.UserID;
                            pp.CreatedOn = System.DateTime.Now;
                            pp.CreatedTerminal = obj.TerminalID;
                            //};
                            db.GtEfoppr.Add(pp);
                        }
                        else
                        {
                            pp = await db.GtEfoppr.Where(w => w.RUhid == obj.UHID).FirstAsync();
                            pp.FirstName = gd.FirstName;
                            pp.LastName = gd.LastName;
                            pp.Gender = gd.Gender;
                            pp.IsDobapplicable = isDobapplicable;
                            pp.DateOfBirth = dob;
                            pp.AgeYy = gd.AgeYy;
                            pp.AgeMm = 0;
                            pp.AgeDd = 0;
                            pp.Isdcode = 0;
                            pp.MobileNumber = gd.MobileNumber;
                            pp.EMailId = gd.EmailId;
                            if (obj.ImageUrl != null)
                            {
                                pp.ImageUrl = obj.ImageUrl;
                            }
                        }

                        var p_ad = await db.GtEfopa1.Where(w => w.RUhid == pp.RUhid).FirstOrDefaultAsync();
                        if (p_ad == null)
                        {
                            p_ad = new GtEfopa1
                            {
                                RUhid = pp.RUhid,
                                AddressId = 1,
                                Address = obj.Address,
                                StateCode = obj.StateCode ?? 0,
                                CityCode = obj.CityCode ?? 0,
                                AreaCode = obj.AreaCode ?? 0,
                                Pincode = obj.Pincode,
                                ActiveStatus = true,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtEfopa1.Add(p_ad);
                        }
                        else
                        {
                            p_ad.Address = obj.Address;
                            p_ad.StateCode = obj.StateCode ?? 0;
                            p_ad.CityCode = obj.CityCode ?? 0;
                            p_ad.AreaCode = obj.AreaCode ?? 0;
                            p_ad.Pincode = obj.Pincode;
                            p_ad.ModifiedBy = obj.UserID;
                            p_ad.ModifiedOn = System.DateTime.Now;
                            p_ad.ModifiedTerminal = obj.TerminalID;
                        }

                        gd.Uhid = pp.RUhid;
                        gd.Address = obj.Address;
                        gd.AreaCode = obj.AreaCode;
                        gd.CityCode = obj.CityCode;
                        gd.StateCode = obj.StateCode;
                        gd.Pincode = obj.Pincode;
                        gd.IsCheckedIn = true;
                        gd.ActualCheckedInDate = System.DateTime.Now;

                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, ID = pp.RUhid };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public async Task<DO_ReturnParameter> UpdateGuestCheckin(DO_GuestCheckInDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var gd = await db.GtGptbkg.Where(w => w.BusinessKey == obj.BusinessKey && w.BookingKey == obj.BookingKey && w.GuestId == obj.GuestId).FirstOrDefaultAsync();
                        GtEfoppr pp;
                        DateTime? dob;
                        bool isDobapplicable = false;
                        if (obj.DateOfBirth != null)
                        {
                            isDobapplicable = true;
                            dob = obj.DateOfBirth;
                        }
                        else
                            dob = System.DateTime.Now.AddYears(-gd.AgeYy);
                        if (gd != null)
                        {
                            gd.FirstName = obj.FirstName;
                            gd.LastName = obj.LastName;
                            gd.Gender = obj.Gender;
                            gd.AgeYy = obj.AgeYy;
                            gd.Isdcode = obj.Isdcode;
                            gd.MobileNumber = obj.MobileNumber;
                            gd.EmailId = obj.EmailId;
                            gd.Uhid = obj.UHID;
                            gd.Address = obj.Address;
                            gd.AreaCode = obj.AreaCode;
                            gd.CityCode = obj.CityCode;
                            gd.StateCode = obj.StateCode;
                            gd.Pincode = obj.Pincode;
                            gd.ModifiedBy = obj.UserID;
                            gd.ModifiedOn = System.DateTime.Now;
                            gd.ModifiedTerminal = obj.TerminalID;
                        }
                        pp = await db.GtEfoppr.Where(w => w.RUhid == obj.UHID).FirstAsync();
                        if (pp != null)
                        {
                            pp.FirstName = obj.FirstName;
                            pp.LastName = obj.LastName;
                            pp.Gender = obj.Gender;
                            pp.DateOfBirth = obj.DateOfBirth;
                            pp.AgeYy = obj.AgeYy;
                            pp.Isdcode = obj.Isdcode;
                            pp.MobileNumber = obj.MobileNumber;
                            pp.IsDobapplicable = isDobapplicable;
                            pp.EMailId = obj.EmailId;
                            pp.BusinessKey = obj.BusinessKey;
                            if (obj.ImageUrl != null)
                            {
                                pp.ImageUrl = obj.ImageUrl;
                            }
                            pp.ModifiedBy = obj.UserID;
                            pp.ModifiedOn = System.DateTime.Now;
                            pp.ModifiedTerminal = obj.TerminalID;
                        }
                        var p_ad = await db.GtEfopa1.Where(w => w.RUhid == pp.RUhid).FirstOrDefaultAsync();
                        if (p_ad != null)
                        {
                            p_ad.Address = obj.Address;
                            p_ad.StateCode = obj.StateCode ?? 0;
                            p_ad.CityCode = obj.CityCode ?? 0;
                            p_ad.AreaCode = obj.AreaCode ?? 0;
                            p_ad.Pincode = obj.Pincode;
                            p_ad.ModifiedBy = obj.UserID;
                            p_ad.ModifiedOn = System.DateTime.Now;
                            p_ad.ModifiedTerminal = obj.TerminalID;
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

        #region Document Upload
        public async Task<List<DO_GuestDocumentUpload>> GetGuestDocumentUploadDetailsByBookingKey(int businessKey, long bookingKey, int guestId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbkd.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey && x.GuestId == guestId)
                        .Select(d => new DO_GuestDocumentUpload
                        {
                            BusinessKey = d.BusinessKey,
                            BookingKey = d.BookingKey,
                            GuestId = d.GuestId,
                            SerialNo = d.SerialNo,
                            DocumentName = d.DocumentName,
                            DocumentUrl = d.DocumentUrl,
                            IdentificationNumber=d.IdentificationNumber,
                            ActiveStatus = d.ActiveStatus
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertGuestDocumentUpload(DO_GuestDocumentUpload obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        //GtGptbkd is_documentExists = db.GtGptbkd.FirstOrDefault(d => d.BusinessKey == obj.BusinessKey && d.BookingKey==d.BookingKey && d.GuestId==obj.GuestId && d.SerialNo==obj.SerialNo);
                        //if (is_documentExists == null)
                        //{
                        int maxval = db.GtGptbkd.Select(d => d.SerialNo).DefaultIfEmpty().Max();
                        int serial_no = maxval + 1;
                        var document = new GtGptbkd
                        {
                            BusinessKey = obj.BusinessKey,
                            BookingKey = obj.BookingKey,
                            GuestId = obj.GuestId,
                            SerialNo = serial_no,
                            DocumentName = obj.DocumentName,
                            DocumentUrl = obj.DocumentUrl,
                            IdentificationNumber=obj.IdentificationNumber,   
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };

                        db.GtGptbkd.Add(document);
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Document Uploaded Successfully" };

                        //}
                        //else
                        //{
                        //    return new DO_ReturnParameter() { Status = false, Message = "Document is already Exists try another one." };
                        //}
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

        public async Task<DO_ReturnParameter> UpdateGuestDocumentUpload(DO_GuestDocumentUpload obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGptbkd doc = db.GtGptbkd.FirstOrDefault(d => d.BusinessKey == obj.BusinessKey && d.BookingKey == d.BookingKey && d.GuestId == obj.GuestId && d.SerialNo == obj.SerialNo);

                        if (doc != null)
                        {

                            doc.BusinessKey = obj.BusinessKey;
                            doc.BookingKey = obj.BookingKey;
                            doc.GuestId = obj.GuestId;
                            doc.SerialNo = obj.SerialNo;
                            doc.DocumentName = obj.DocumentName;
                            doc.DocumentUrl = obj.DocumentUrl;
                            doc.IdentificationNumber = obj.IdentificationNumber;
                            doc.ActiveStatus = obj.ActiveStatus;
                            doc.ModifiedBy = obj.UserID;
                            doc.ModifiedOn = DateTime.Now;
                            doc.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Document Updated sucessfully." };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Document" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveGuestDocumentUpload(DO_GuestDocumentUpload obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGptbkd doc = db.GtGptbkd.FirstOrDefault(d => d.BusinessKey == obj.BusinessKey && d.BookingKey == d.BookingKey && d.GuestId == obj.GuestId && d.SerialNo == obj.SerialNo);

                        if (doc != null)
                        {
                            doc.ActiveStatus = obj.Status;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            if (obj.Status == true)
                                return new DO_ReturnParameter() { Status = true, Message = "Document  Activated Successfully." };
                            else
                                return new DO_ReturnParameter() { Status = true, Message = "Document  De Activated Successfully." };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Document" };
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

        public async Task<DO_GuestDocumentUpload> GetDocumentUploadbySerialNumber(int businessKey, long bookingKey, int guestId, int serialno)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbkd.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey && x.GuestId == guestId && x.SerialNo == serialno)
                        .Select(d => new DO_GuestDocumentUpload
                        {
                            BusinessKey = d.BusinessKey,
                            BookingKey = d.BookingKey,
                            GuestId = d.GuestId,
                            SerialNo = d.SerialNo,
                            DocumentName = d.DocumentName,
                            DocumentUrl = d.DocumentUrl,
                            IdentificationNumber=d.IdentificationNumber,
                            ActiveStatus = d.ActiveStatus
                        }).FirstOrDefaultAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_GuestDocumentUpload> DeleteDocument(int businessKey, long bookingKey, int guestId, int serialno)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        var document = db.GtGptbkd.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey && x.GuestId == guestId && x.SerialNo == serialno).FirstOrDefault();
                        if (document != null)
                        {
                            DO_GuestDocumentUpload d = new DO_GuestDocumentUpload();
                            d.DocumentUrl = document.DocumentUrl;
                            db.GtGptbkd.Remove(document);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_GuestDocumentUpload() { Status = true, DocumentUrl = d.DocumentUrl };

                        }
                        else
                        {
                            return new DO_GuestDocumentUpload() { Status = false, DocumentUrl = "" };
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
        #endregion Document Upload

        #region Address
        public async Task<List<DO_Place>> GetStateList(int isdCode)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtEccnpl
               .Where(w => w.ActiveStatus && w.PlaceType == PlaceTypeValues.State && w.Isdcode == isdCode)
               .Select(s => new DO_Place
               {
                   IsdCode = s.Isdcode,
                   PlaceId = s.PlaceId,
                   PlaceName = s.PlaceName
               })
               .ToListAsync();
                return await pf;
            }
        }

        public async Task<List<DO_Place>> GetCityList(int isdCode, int? stateCode)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtAddrin
                .Join(db.GtEccnpl.Where(w => w.PlaceType == PlaceTypeValues.City && w.ActiveStatus),
                    a => new { a.CityCode },
                    c => new { CityCode = c.PlaceId },
                    (a, c) => new { a, c })
               .Where(w => w.a.ActiveStatus && (w.a.StateCode == stateCode || stateCode == null))
               .Select(s => new DO_Place
               {
                   IsdCode = s.a.Isdcode,
                   PlaceId = s.c.PlaceId,
                   PlaceName = s.c.PlaceName
               })
               .Distinct()
               .ToListAsync();
                return await pf;
            }
        }

        public async Task<List<DO_AddressIN>> GetAreaList(int isdCode, int? stateCode, int? cityCode)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtAddrin
               .Where(w => w.ActiveStatus
                    && w.Isdcode == isdCode
                    && (w.StateCode == stateCode || stateCode == null)
                    && (w.CityCode == cityCode || cityCode == null))
               .Select(s => new DO_AddressIN
               {
                   IsdCode = s.Isdcode,
                   AreaCode = s.AreaCode,
                   AreaName = s.AreaName,
                   StateCode = s.StateCode,
                   CityCode = s.CityCode,
                   District = s.District,
                   Pincode = s.Pincode
               })
               .ToListAsync();
                return await pf;
            }
        }

        public async Task<DO_AddressIN> GetAreaDetailsbyPincode(int isdCode, string pincode)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtAddrin
               .Where(w => w.ActiveStatus
                    && w.Isdcode == isdCode && w.Pincode == pincode)
               .Select(s => new DO_AddressIN
               {
                   IsdCode = s.Isdcode,
                   AreaCode = s.AreaCode,
                   AreaName = s.AreaName,
                   StateCode = s.StateCode,
                   CityCode = s.CityCode,
                   District = s.District,
                   Pincode = s.Pincode
               })
               .FirstOrDefaultAsync();
                return await pf;
            }
        }
        #endregion

        #region Rescheduling
        public async Task<List<DO_Rescheduling>> GetGuestReschedulingByBookingKey(int businessKey, long bookingKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbrs.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey)
                        .Select(d => new DO_Rescheduling
                        {
                            BusinessKey = d.BusinessKey,
                            BookingKey = d.BookingKey,
                            SerialNumber = d.SerialNumber,
                            PrevCheckInDate = d.PrevCheckInDate,
                            PrevCheckOutDate = d.PrevCheckOutDate,
                            CheckInDate = d.CheckInDate,
                            CheckOutDate = d.CheckOutDate,
                            ActiveStatus = d.ActiveStatus
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertGuestRescheduling(DO_Rescheduling obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var b_values = db.GtGptbkh.Where(x => x.BusinessKey == obj.BusinessKey && x.BookingKey == obj.BookingKey).
                         Join(db.GtGptbkp.Where(x => x.BusinessKey == obj.BusinessKey && x.BookingKey == obj.BookingKey),
                           x => x.BookingKey,
                           y => y.BookingKey,
                         (x, y) => new DO_GuestCheckInDetails
                         {
                             CheckedInDate = x.CheckInDate.Date,
                             CheckedOutDate = x.CheckOutDate.Date,
                             RoomTypeId = y.RoomTypeId,
                             RoomNumber = y.RoomNumber,
                             BedNumber = y.BedNumber
                         }).FirstOrDefault();

                        if (b_values != null)
                        {
                            var r_booked = GetRoomBedBookedDetail(b_values.RoomTypeId, b_values.RoomNumber, b_values.BedNumber, obj.CheckInDate, obj.CheckOutDate);
                            if (r_booked.Where(w=>w.BookingKey != obj.BookingKey).Count() > 0)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Rooms are not available" };
                            }
                        }
                        var _header = db.GtGptbkh.Where(x => x.BusinessKey == obj.BusinessKey && x.BookingKey == obj.BookingKey).FirstOrDefault();
                        if (_header != null)
                        {
                            obj.PrevCheckInDate = _header.CheckInDate;
                            obj.PrevCheckOutDate = _header.CheckOutDate;
                           
                        }
                        int maxval = db.GtGptbrs.Select(d => d.SerialNumber).DefaultIfEmpty().Max();
                        int serial_no = maxval + 1;
                        TimeSpan time = DateTime.Now.TimeOfDay;
                        obj.CheckInDate = obj.CheckInDate + time;
                        obj.CheckOutDate = obj.CheckOutDate + time;
                        var r_scheduling = new GtGptbrs
                        {
                            BusinessKey = obj.BusinessKey,
                            BookingKey = obj.BookingKey,
                            SerialNumber = serial_no,
                            PrevCheckInDate = obj.PrevCheckInDate,
                            PrevCheckOutDate = obj.PrevCheckOutDate,
                            CheckInDate = obj.CheckInDate,
                            CheckOutDate = obj.CheckOutDate,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };

                        db.GtGptbrs.Add(r_scheduling);
                        await db.SaveChangesAsync();
                        _header.CheckInDate = obj.CheckInDate;
                        _header.CheckOutDate = obj.CheckOutDate;
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Rescheduling Created Successfully" };
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

        #endregion

        #region Room change
        public async Task<List<DO_RoomChange>> GetGuestRoomchangeByBookingKey(int businessKey, long bookingKey, int guestId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbrc.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey && x.GuestId==guestId)
                        .Join(db.GtGprmty,
                          x => x.RoomTypeId,
                          y => y.RoomTypeId,
                         (x, y) => new DO_RoomChange
                        {
                            BusinessKey = x.BusinessKey,
                            BookingKey = x.BookingKey,
                            GuestId=x.GuestId,
                            SerialNumber = x.SerialNumber,
                            DocumentDate = x.DocumentDate,
                            PrevRoomTypeId = x.PrevRoomTypeId,
                            PrevRoomNumber = x.PrevRoomNumber,
                            PrevBedNumber = x.PrevBedNumber,
                            RoomTypeId=x.RoomTypeId,
                            RoomNumber=x.RoomNumber,
                            BedNumber=x.BedNumber,
                            Comment=x.Comment,
                            ActiveStatus = x.ActiveStatus,
                            RoomTypeDesc=y.RoomTypeDesc
                         }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertGuestRoomchange(DO_RoomChange obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var b_values = db.GtGptbkh.Where(x => x.BusinessKey == obj.BusinessKey && x.BookingKey == obj.BookingKey).
                       Join(db.GtGptbkp.Where(x => x.BusinessKey == obj.BusinessKey && x.BookingKey == obj.BookingKey),
                         x => x.BookingKey,
                         y => y.BookingKey,
                       (x, y) => new DO_GuestCheckInDetails
                       {
                           CheckedInDate = x.CheckInDate.Date,
                           CheckedOutDate = x.CheckOutDate.Date,
                           RoomTypeId = y.RoomTypeId,
                           RoomNumber = y.RoomNumber,
                           BedNumber = y.BedNumber
                       }).FirstOrDefault();

                        if (b_values != null)
                        {
                            var r_booked = GetRoomBedBookedDetail(obj.RoomTypeId, obj.RoomNumber,obj.BedNumber,b_values.CheckedInDate,b_values.CheckedOutDate);
                            if (r_booked.Where(w=>w.BookingKey != obj.BookingKey).Count() > 0)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Rooms are not available" };
                            }
                        }

                        var _roomheader = db.GtGptbkp.Where(x => x.BusinessKey == obj.BusinessKey && x.BookingKey == obj.BookingKey &&x.GuestId==obj.GuestId && x.RoomTypeId==obj.RoomTypeId).FirstOrDefault();
                        if (_roomheader != null)
                        {
                            obj.PrevRoomTypeId = _roomheader.RoomTypeId;
                            obj.PrevRoomNumber = _roomheader.RoomNumber;
                            obj.PrevBedNumber = _roomheader.BedNumber;

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "you have selected Invalid Room Type please select the same header Room Type" };
                        }
                        int maxval = db.GtGptbrc.Select(d => d.SerialNumber).DefaultIfEmpty().Max();
                        int serial_no = maxval + 1;
                        var r_change = new GtGptbrc
                        {
                            BusinessKey = obj.BusinessKey,
                            BookingKey = obj.BookingKey,
                            GuestId=obj.GuestId,
                            SerialNumber = serial_no,
                            //DocumentDate = obj.DocumentDate,
                            DocumentDate = DateTime.Now,
                            PrevRoomTypeId = obj.PrevRoomTypeId,
                            PrevRoomNumber = obj.PrevRoomNumber,
                            PrevBedNumber = obj.PrevBedNumber,
                            RoomTypeId=obj.RoomTypeId,
                            RoomNumber=obj.RoomNumber,
                            BedNumber=obj.BedNumber,
                            Comment=obj.Comment,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };

                        db.GtGptbrc.Add(r_change);
                        await db.SaveChangesAsync();

                        _roomheader.RoomNumber = obj.RoomNumber;
                        _roomheader.BedNumber = obj.BedNumber;
                        await db.SaveChangesAsync();

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Room Changed Successfully" };
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

        public List<DO_RoomChange> GetRoomBedBookedDetail(int roomTypeId,string roomNumber, string bedNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            using (var db = new eSyaEnterprise())
            {
                var rm_booked = db.GtGptbkh
                .Join(db.GtGptbkp,
                    h => new { h.BusinessKey, h.BookingKey },
                    p => new { p.BusinessKey, p.BookingKey },
                    (h, p) => new { h, p })
                .Where(w => (
                              (checkInDate.Date == w.h.CheckInDate.Date)
                           || (checkInDate.Date == w.h.CheckOutDate.Date)
                           || (checkInDate.Date < w.h.CheckInDate.Date && checkOutDate >= w.h.CheckInDate.Date)
                           || (checkInDate.Date > w.h.CheckInDate.Date && checkInDate.Date <= w.h.CheckOutDate.Date))
                           && w.p.RoomTypeId == roomTypeId && w.p.RoomNumber== roomNumber && w.p.BedNumber== bedNumber
                           && (w.h.ActiveStatus))
                .Select(r => new DO_RoomChange
                {
                    RoomTypeId = r.p.RoomTypeId,
                    RoomNumber = r.p.RoomNumber,
                    BedNumber = r.p.BedNumber,
                    BookingKey = r.h.BookingKey,
                }).ToList();

               return rm_booked;
            }
        }
        #endregion

        #region Service
        public async Task<List<DO_Service>> GetGuestServiceByBookingKey(int businessKey, long bookingKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGptbsv.Where(x => x.BusinessKey == businessKey && x.BookingKey == bookingKey ).
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
                            ServiceName=y.ServiceDesc,
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

        public async Task<DO_ReturnParameter> InsertGuestService(DO_Service obj)
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
                            TotalAmount=obj.TotalAmount,
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
        #endregion

        #region Update Guest Personal Details
        public async Task<DO_ReturnParameter> UpdateGuestPersonalDetails(DO_GuestCheckInDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var gd = await db.GtGptbkg.Where(w => w.BusinessKey == obj.BusinessKey && w.BookingKey == obj.BookingKey && w.GuestId == obj.GuestId).FirstOrDefaultAsync();
                        if (gd != null)
                        {
                            gd.FirstName = obj.FirstName;
                            gd.LastName = obj.LastName;
                            gd.Gender = obj.Gender;
                            gd.AgeYy = obj.AgeYy;
                            gd.Isdcode = obj.Isdcode;
                            gd.MobileNumber = obj.MobileNumber;
                            gd.EmailId = obj.EmailId;
                            gd.Address = obj.Address;
                            gd.AreaCode = obj.AreaCode;
                            gd.CityCode = obj.CityCode;
                            gd.StateCode = obj.StateCode;
                            gd.Pincode = obj.Pincode;
                            gd.ModifiedBy = obj.UserID;
                            gd.ModifiedOn = System.DateTime.Now;
                            gd.ModifiedTerminal = obj.TerminalID;
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
        #endregion
    }
}
