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
   public class MembershipRegistrationRepository: IMembershipRegistrationRepository
    {
        #region MemberShip Header
        public async Task<List<DO_MembershipHeader>> GetMembershipHeaderByNamePrefix(string memberNamePrefix)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtGptrgh
                        .Where(w => (!String.IsNullOrEmpty(memberNamePrefix) && (memberNamePrefix != "All"))
                        ? w.FirstName.ToUpper().Trim().StartsWith(memberNamePrefix.ToUpper().Trim()) : true)
                        .Select(r => new DO_MembershipHeader
                        {
                            BusinessKey = r.BusinessKey,
                            MemberId = r.MemberId,
                            RegisteredDate = r.RegisteredDate,
                            FirstName = r.FirstName,
                            MiddleName = r.MiddleName,
                            LastName = r.LastName,
                           MemberName = r.FirstName + " " + r.LastName,
                           Gender =r.Gender,
                           AgeYy=r.AgeYy,
                           Isdcode=r.Isdcode,
                           MobileNumber=r.MobileNumber,
                           EmailId=r.EmailId,
                           CityCode=r.CityCode,
                           StateCode=r.StateCode,
                           Uhid=r.Uhid,
                           DonationAmount=r.DonationAmount,
                           ActiveStatus = r.ActiveStatus
                        }).OrderBy(o => o.FirstName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_MembershipHeader> GetMembershipHeaderByMemberId(DO_MembershipHeader objm)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtGptrgh.Where(w => w.BusinessKey == objm.BusinessKey && w.MemberId == objm.MemberId)
                        .Select(x => new DO_MembershipHeader
                        {
                            BusinessKey = x.BusinessKey,
                            MemberId = x.MemberId,
                            RegisteredDate =x.RegisteredDate,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            Gender = x.Gender,
                            AgeYy = x.AgeYy,
                            Isdcode = x.Isdcode,
                            MobileNumber = x.MobileNumber,
                            EmailId = x.EmailId,
                            CityCode = x.CityCode,
                            StateCode = x.StateCode,
                            Uhid = x.Uhid,
                            DonationAmount = x.DonationAmount,
                            ActiveStatus = x.ActiveStatus
                        }).FirstOrDefaultAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameterwithMemberId> InsertIntoMembershipHeader(DO_MembershipHeader obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var c_year = DateTime.Now.Year.ToString();
                        var c_month = DateTime.Now.Month.ToString();
                        var c_res = c_year.Substring(c_year.Length - 2);
                        var memId = c_res + c_month;
                        var Exists_maxval = db.GtGptrgh.Select(a => a.MemberId).DefaultIfEmpty().Max().ToString();
                        if (Exists_maxval == "0")
                        {
                            memId = memId + "000001";
                        }
                        else
                        {
                            var val=Exists_maxval.Substring(4);
                            int number = Convert.ToInt32(val)+1;
                            int num = number;
                            int count = FindNumberOfDigit(ref number);
                            if (count == 1)
                            {
                                memId = memId + "00000"+ num;
                            }
                            if (count == 2)
                            {
                                memId = memId + "0000" + num;
                            }
                            if (count == 3)
                            {
                                memId = memId + "000" + num;
                            }
                            if (count == 4)
                            {
                                memId = memId + "00" + num;
                            }
                            if (count == 5)
                            {
                                memId = memId + "0" + num;
                            }
                            if (count >= 6)
                            {
                                memId = memId + num;
                            }
                            
                        }
                        obj.MemberId =Convert.ToInt64(memId);
                        var mh_Exists =await db.GtGptrgh.Where(x => x.BusinessKey == obj.BusinessKey && x.MemberId == obj.MemberId).FirstOrDefaultAsync();
                        if (mh_Exists != null)
                        {
                            return new DO_ReturnParameterwithMemberId() { Status = false, Message = "Member Ship already Exists" };
                        }
                         GtGptrgh mh = new GtGptrgh
                        {
                            BusinessKey = obj.BusinessKey,
                            MemberId = obj.MemberId,
                            RegisteredDate = System.DateTime.Now.Date,
                            FirstName = obj.FirstName,
                            MiddleName = obj.MiddleName,
                            LastName = obj.LastName,
                            Gender = obj.Gender,
                            AgeYy = obj.AgeYy,
                            Isdcode = obj.Isdcode,
                            MobileNumber = obj.MobileNumber,
                            EmailId = obj.EmailId,
                            CityCode = obj.CityCode,
                            StateCode = obj.StateCode,
                            Uhid = obj.Uhid,
                            DonationAmount = obj.DonationAmount,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };
                        db.GtGptrgh.Add(mh);
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameterwithMemberId() { Status = true, Message = "Member Ship Register Successfully", MId = obj.MemberId,bKey= obj.BusinessKey };
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

        private static int FindNumberOfDigit(ref int number)
        {
            int count = 0;
            while (number > 0)
            {
                number /= 10;
                count++;
            }
            return count;
        }

        public async Task<DO_ReturnParameterwithMemberId> UpdateMembershipHeader(DO_MembershipHeader obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGptrgh mh = await db.GtGptrgh.Where(x => x.BusinessKey == obj.BusinessKey && x.MemberId == obj.MemberId).FirstOrDefaultAsync();
                        if (mh == null)
                        {
                            return new DO_ReturnParameterwithMemberId() { Status = false, Message = "Member Ship Header not Exists" };
                        }
                        else
                        {
                            mh.FirstName = obj.FirstName;
                            mh.MiddleName = obj.MiddleName;
                            mh.LastName = obj.LastName;
                            mh.Gender = obj.Gender;
                            mh.AgeYy = obj.AgeYy;
                            mh.Isdcode = obj.Isdcode;
                            mh.MobileNumber = obj.MobileNumber;
                            mh.EmailId = obj.EmailId;
                            mh.CityCode = obj.CityCode;
                            mh.StateCode = obj.StateCode;
                            mh.Uhid = obj.Uhid;
                            mh.DonationAmount = obj.DonationAmount;
                            mh.ActiveStatus = obj.ActiveStatus;
                            mh.ModifiedBy = obj.UserID;
                            mh.ModifiedOn = DateTime.Now;
                            mh.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameterwithMemberId() { Status = true, Message = "Member Ship Header Updated sucessfully.", MId = obj.MemberId, bKey = obj.BusinessKey };
                           
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveMembershipHeader(bool status, int businesskey,long memberId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGptrgh mh = db.GtGptrgh.Where(p => p.BusinessKey == businesskey && p.MemberId==memberId).FirstOrDefault();
                        if (mh == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Member Ship header is not exist" };
                        }
                        if (mh != null)
                        {
                            mh.ActiveStatus = status;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                        }
                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Member Ship Header Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Member Ship Header De Activated Successfully." };
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

        #region MemberShip Types
        public async Task<List<DO_MembershipType>> GetMembershipTypes(int businesskey, long memberId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtGptrgc.Where(x=>x.BusinessKey==businesskey && x.MemberId==memberId)
                        .Join(db.GtEcapcd, lkey => new { lkey.MembershipType },
                           ent => new { MembershipType=ent.ApplicationCode },
                           (lkey, ent) => new { lkey, ent }).Join(db.GtGprmty,
                           Bloc => new { Bloc.lkey.RoomType },
                           seg => new { RoomType=seg.RoomTypeId },
                           (Bloc, seg) => new { Bloc, seg })
                           .Select(c => new DO_MembershipType
                           {
                               BusinessKey= c.Bloc.lkey.BusinessKey,
                               MemberId = c.Bloc.lkey.MemberId,
                               CouponId = c.Bloc.lkey.CouponId,
                               MembershipType = c.Bloc.lkey.MembershipType,
                               NoOfYear = c.Bloc.lkey.NoOfYear,
                               ValidFrom = c.Bloc.lkey.ValidFrom,
                               ValidTill = c.Bloc.lkey.ValidTill,
                               RoomType = c.Bloc.lkey.RoomType,
                               BookingDiscountPercentage = c.Bloc.lkey.BookingDiscountPercentage,
                               NoOfPersons = c.Bloc.lkey.NoOfPersons,
                               ActiveStatus = c.Bloc.lkey.ActiveStatus,
                               MemberTypedesc = c.Bloc.ent.CodeDesc,
                               RoomTypedesc = c.seg.RoomTypeDesc
                           }).ToListAsync();
                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateIntoMembershipType(DO_MembershipType obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _mtype = await db.GtGptrgc.Where(x => x.BusinessKey == obj.BusinessKey && x.MemberId == obj.MemberId && x.CouponId.ToUpper().Replace(" ", "") == obj.CouponId.ToUpper().Replace(" ", "")).FirstOrDefaultAsync();
                        if (_mtype == null)
                        {

                            GtGptrgc mtype = new GtGptrgc
                            {
                                BusinessKey = obj.BusinessKey,
                                MemberId = obj.MemberId,
                                CouponId = obj.CouponId,
                                MembershipType = obj.MembershipType,
                                NoOfYear = obj.NoOfYear,
                                ValidFrom = obj.ValidFrom,
                                ValidTill = obj.ValidTill,
                                RoomType = obj.RoomType,
                                BookingDiscountPercentage = obj.BookingDiscountPercentage,
                                NoOfPersons = obj.NoOfPersons,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtGptrgc.Add(mtype);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Type Successfully" };
                        }
                        else
                        {
                            _mtype.MembershipType = obj.MembershipType;
                            _mtype.NoOfYear = obj.NoOfYear;
                            _mtype.ValidFrom = obj.ValidFrom;
                            _mtype.ValidTill = obj.ValidTill;
                            _mtype.RoomType = obj.RoomType;
                            _mtype.BookingDiscountPercentage = obj.BookingDiscountPercentage;
                            _mtype.NoOfPersons = obj.NoOfPersons;
                            _mtype.ActiveStatus = obj.ActiveStatus;
                            _mtype.ModifiedBy = obj.UserID;
                            _mtype.ModifiedOn = DateTime.Now;
                            _mtype.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Type Updated Successfully" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveMembershipType(bool status, int businesskey, long memberId, string couponId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mtype = await db.GtGptrgc.Where(x => x.BusinessKey == businesskey && x.MemberId ==memberId && x.CouponId.ToUpper().Replace(" ", "") == couponId.ToUpper().Replace(" ", "")).FirstOrDefaultAsync();
                        if (mtype == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "MemberShip Type is not exist" };
                        }
                        if (mtype != null)
                        {
                            mtype.ActiveStatus = status;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                        }
                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Type Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Type De Activated Successfully." };
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

        #region MemberShip Donation
        public async Task<List<DO_MembershipDonation>> GetMembershipDonations(int businesskey, long memberId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtGptrgd.Where(x=>x.BusinessKey==businesskey && x.MemberId==memberId)
                        .Select(r => new DO_MembershipDonation
                        {
                            BusinessKey = r.BusinessKey,
                            MemberId = r.MemberId,
                            SerialNumber = r.SerialNumber,
                            DonationDate = r.DonationDate,
                            DonationAmount = r.DonationAmount,
                            ReceiptVoucherReference = r.ReceiptVoucherReference,
                            Comments = r.Comments,
                            ActiveStatus = r.ActiveStatus
                        }).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateIntoMembershipDonation(DO_MembershipDonation obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _mdonation = await db.GtGptrgd.Where(x => x.BusinessKey == obj.BusinessKey && x.MemberId == obj.MemberId && x.SerialNumber==obj.SerialNumber).FirstOrDefaultAsync();
                        if (_mdonation == null)
                        {
                            int maxval = db.GtGptrgd.Select(d => d.SerialNumber).DefaultIfEmpty().Max();
                            int serial_no = maxval + 1;
                            obj.SerialNumber = serial_no;
                            GtGptrgd md = new GtGptrgd
                            {
                                BusinessKey = obj.BusinessKey,
                                MemberId = obj.MemberId,
                                SerialNumber = obj.SerialNumber,
                                DonationDate = obj.DonationDate,
                                DonationAmount = obj.DonationAmount,
                                ReceiptVoucherReference = obj.ReceiptVoucherReference,
                                Comments = obj.Comments,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtGptrgd.Add(md);
                            await db.SaveChangesAsync();
                            var mh = db.GtGptrgh.Where(x => x.BusinessKey == obj.BusinessKey && x.MemberId == obj.MemberId).FirstOrDefault();
                            if (mh != null)
                            {
                                mh.DonationAmount = mh.DonationAmount + obj.DonationAmount;
                                db.SaveChanges();
                            }
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Member Ship Donation Successfully" };
                        }
                        else
                        {
                            _mdonation.DonationDate = obj.DonationDate;
                            _mdonation.DonationAmount = obj.DonationAmount;
                            _mdonation.ReceiptVoucherReference = obj.ReceiptVoucherReference;
                            _mdonation.Comments = obj.Comments;
                            _mdonation.ActiveStatus = obj.ActiveStatus;
                            _mdonation.ModifiedBy = obj.UserID;
                            _mdonation.ModifiedOn = DateTime.Now;
                            _mdonation.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            var mh = db.GtGptrgh.Where(x => x.BusinessKey == obj.BusinessKey && x.MemberId == obj.MemberId).FirstOrDefault();
                            if (mh != null)
                            {
                                mh.DonationAmount = mh.DonationAmount + obj.DonationAmount;
                                db.SaveChanges();
                            }
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Member Ship Donation Updated Successfully" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveMembershipDonation(bool status, int businesskey, long memberId,int serialno)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGptrgd md = db.GtGptrgd.Where(p => p.BusinessKey == businesskey && p.MemberId == memberId && p.SerialNumber==serialno).FirstOrDefault();
                        if (md == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Member Ship Donation is not exist" };
                        }
                        if (md != null)
                        {
                            md.ActiveStatus = status;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                        }
                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Member Ship Donation Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Member Ship Donation De Activated Successfully." };
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

        #region Common Methods
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

        public List<DO_ApplicationCodes> GetMembershipTypebyPatientId(int patientTypeId)
        {
            using (var db = new eSyaEnterprise())
            {
                var mtypes = db.GtEapcms.Where(x => x.PatientTypeId == patientTypeId && x.ActiveStatus)
                .Join(db.GtEcapcd,
                    a => new { a.PatientCategoryId },
                    c => new { PatientCategoryId = c.ApplicationCode },
                    (a, c) => new { a, c })
               .Select(s => new DO_ApplicationCodes
               {
                   ApplicationCode = s.a.PatientCategoryId,
                   CodeDesc = s.c.CodeDesc
               }).ToList();
                return mtypes.GroupBy(x => x.ApplicationCode).Select(y => y.First()).Distinct().ToList();
            }
        }
        #endregion
    }
}
