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
    public class DonorMasterRepository: IDonorMasterRepository
    {
        #region Donor Rules

        public async Task<List<DO_DonorRules>> GetAllDonorRules()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdorl.Join(db.GtGprmty,
                      x => new { x.RoomType },
                      y => new { RoomType = y.RoomTypeId },
                     (x, y) => new { x, y })
                       .Select(d => new DO_DonorRules
                       {
                           DonorType = d.x.DonorType,
                           DonorTypeDesc = d.x.DonorTypeDesc,
                           DonationRangeFrom = d.x.DonationRangeFrom,
                           DonationRangeTo = d.x.DonationRangeTo,
                           DiscountPercentage = d.x.DiscountPercentage,
                           RoomType = d.x.RoomType,
                           NoOfPersons = d.x.NoOfPersons,
                           DonorValidityInYears = d.x.DonorValidityInYears,
                           RoomTypeDesc = d.y.RoomTypeDesc,
                           ActiveStatus = d.x.ActiveStatus
                       }).ToListAsync();
                    return await ds;

                    //var dc_ms = db.GtGpdorl
                    //    .GroupJoin(db.GtGprmty,
                    //    d => new { d.RoomType },
                    //    a => new { RoomType= a.RoomTypeId },
                    //    (d, a) => new { d, a = a.FirstOrDefault() })

                    //    .AsNoTracking()
                    //    .Select(x => new DO_DonorRules
                    //    {
                    //        DonorType = x.d.DonorType,
                    //        RoomTypeDesc = x.a != null ? x.a.RoomTypeDesc : string.Empty,

                    //    }).ToListAsync();

                    //return await dc_ms;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DonorRules>> GetActiveDonorRules()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdorl.Where(x => x.ActiveStatus == true)
                        .Select(r => new DO_DonorRules
                        {
                            DonorType = r.DonorType,
                            DonorTypeDesc = r.DonorTypeDesc

                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertIntoDonorRule(DO_DonorRules obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGpdorl is_donorExists = db.GtGpdorl.FirstOrDefault(p => p.DonorTypeDesc.ToUpper().Replace(" ", "") == obj.DonorTypeDesc.ToUpper().Replace(" ", ""));
                        if (is_donorExists == null)
                        {
                            int maxval = db.GtGpdorl.Select(p => p.DonorType).DefaultIfEmpty().Max();
                            int donortype = maxval + 1;
                            var d_rule = new GtGpdorl
                            {
                                DonorType = donortype,
                                DonorTypeDesc = obj.DonorTypeDesc,
                                DonationRangeFrom = obj.DonationRangeFrom,
                                DonationRangeTo = obj.DonationRangeTo,
                                DiscountPercentage = obj.DiscountPercentage,
                                RoomType = obj.RoomType,
                                NoOfPersons = obj.NoOfPersons,
                                DonorValidityInYears = obj.DonorValidityInYears,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGpdorl.Add(d_rule);
                            await db.SaveChangesAsync();
                            
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Donor Type Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor Type Description  is already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateDonorRule(DO_DonorRules obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGpdorl is_dtypeExists = db.GtGpdorl.FirstOrDefault(p => p.DonorType != obj.DonorType && p.DonorTypeDesc.ToUpper().Replace(" ", "") == obj.DonorTypeDesc.ToUpper().Replace(" ", ""));

                        var d_rules = db.GtGpdorl.FirstOrDefault(x => x.DonorType == obj.DonorType);
                        if (d_rules != null)
                        {
                            if (is_dtypeExists == null)
                            {
                                d_rules.DonorTypeDesc = obj.DonorTypeDesc;
                                d_rules.DonationRangeFrom = obj.DonationRangeFrom;
                                d_rules.DonationRangeTo = obj.DonationRangeTo;
                                d_rules.DiscountPercentage = obj.DiscountPercentage;
                                d_rules.RoomType = obj.RoomType;
                                d_rules.NoOfPersons = obj.NoOfPersons;
                                d_rules.DonorValidityInYears = obj.DonorValidityInYears;
                                d_rules.ActiveStatus = obj.ActiveStatus;
                                d_rules.ModifiedBy = obj.UserID;
                                d_rules.ModifiedOn = DateTime.Now;
                                d_rules.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();

                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Donor Type Description  is already Exists try another one." };
                            }

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Donor Type" };
                        }

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Donor Type Updated sucessfully." };

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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveDonorRule(bool status, int donortype)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGpdorl d_type = db.GtGpdorl.Where(p => p.DonorType == donortype).FirstOrDefault();
                        if (d_type == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor Type  is not exist" };
                        }

                        d_type.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Donor Type  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Donor Type  De Activated Successfully." };
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

        #region Donor Package Link
        public async Task<List<DO_DonorPackageLink>> GetDonorLinkbyPackage(int packageId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdopl.
                                 Join(db.GtGppkms,
                                 dl => new { dl.PackageId },
                                 pm => new { pm.PackageId },
                                 (dl, pm) => new { dl, pm }).
                                 Join(db.GtGpdorl,
                                 dlr => new { dlr.dl.DonorType},
                                 dr => new { dr.DonorType },
                                (dlr, dr) => new { dlr, dr })
                                .Where(x=>x.dlr.dl.PackageId==packageId)
                                .Select(x => new DO_DonorPackageLink
                               {
                                  DonorType =x.dlr.dl.DonorType,
                                  PackageId =x.dlr.dl.PackageId,
                                  ActiveStatus = x.dlr.dl.ActiveStatus,
                                  UsageStatus = x.dlr.dl.UsageStatus,
                                  PackageDesc = x.dlr.pm.PackageDesc,
                                  DonorTypeDesc =x.dr.DonorTypeDesc

                               }).ToListAsync();
                        return await ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateDonorLinkwithPackage(DO_DonorPackageLink obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGpdopl is_link = db.GtGpdopl.FirstOrDefault(a => a.PackageId == obj.PackageId && a.DonorType==obj.DonorType);
                        if (is_link == null)
                        {
                            var _pdl = new GtGpdopl
                            {
                                DonorType = obj.DonorType,
                                PackageId = obj.PackageId,
                                //UsageStatus=obj.UsageStatus,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtGpdopl.Add(_pdl);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Donor Linked with Package Successfully" };

                        }
                        else
                        {
                            //is_link.UsageStatus = obj.UsageStatus;
                            is_link.ActiveStatus = obj.ActiveStatus;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Updated Successfully" };
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
        #endregion

        #region Donor Rgistration
        public async Task<List<DO_DonorRegistration>> GetDonorsListbyBusinesskey(int businesskey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtGpdorn.
                                  Join(db.GtGpdorl,
                                  dr => new { dr.DonorType },
                                  dt => new { dt.DonorType },
                                  (dr, dt) => new { dr, dt }).
                                  Join(db.GtGprmty,
                                  drt => new { RoomTypeId= drt.dr.RoomType},
                                  rt => new { rt.RoomTypeId },
                                 (drt, rt) => new { drt, rt })
                                 .Where(x => x.drt.dr.BusinessKey == businesskey)
                                 .Select(r => new DO_DonorRegistration
                                 {
                                     BusinessKey=r.drt.dr.BusinessKey,
                                     DonorId= r.drt.dr.DonorId,
                                     DonorRegistrationNo = r.drt.dr.DonorRegistrationNo,
                                     DateOfRegistration = r.drt.dr.DateOfRegistration,
                                     DonorType = r.drt.dr.DonorType,
                                     DonorFirstName = r.drt.dr.DonorFirstName,
                                     DonorMiddleName = r.drt.dr.DonorMiddleName,
                                     DonorLastName = r.drt.dr.DonorLastName,
                                     AgeYy = r.drt.dr.AgeYy,
                                     Gender = r.drt.dr.Gender,
                                     Isdcode = r.drt.dr.Isdcode,
                                     RegisteredMobileNumber = r.drt.dr.RegisteredMobileNumber,
                                     EmailId = r.drt.dr.EmailId,
                                     Password = eSyaCryptGeneration.Decrypt(r.drt.dr.Password),
                                     Address = r.drt.dr.Address,
                                     StateCode = r.drt.dr.StateCode,
                                     CityCode = r.drt.dr.CityCode,
                                     Pincode = r.drt.dr.Pincode,
                                     AreaCode = r.drt.dr.AreaCode,
                                     RoomType = r.drt.dr.RoomType,
                                     NoOfPersons = r.drt.dr.NoOfPersons,
                                     ValidFrom = r.drt.dr.ValidFrom,
                                     ValidTill = r.drt.dr.ValidTill,
                                     Discount = r.drt.dr.Discount,
                                     DonatedSoFar = r.drt.dr.DonatedSoFar,
                                     ActiveStatus = r.drt.dr.ActiveStatus,
                                     DonorTypeDesc = r.drt.dt.DonorTypeDesc,
                                     RoomTypeDesc = r.rt.RoomTypeDesc

                                 }).ToListAsync();
                    return await ds;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertIntoDonorRegistration(DO_DonorRegistration obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        var dor_Exists = await db.GtGpdorn.Where(x => x.BusinessKey == obj.BusinessKey && x.DonorId == obj.DonorId).FirstOrDefaultAsync();
                        if (dor_Exists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor already Exists" };
                        }
                        var _regtno = await db.GtGpdorn.Where(x => x.DonorRegistrationNo.ToUpper().Replace(" ", "") == obj.DonorRegistrationNo.ToUpper().Replace(" ", "")).FirstOrDefaultAsync();
                        if (_regtno != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor Registration Number already Exists" };
                        }
                        var _mobno = await db.GtGpdorn.Where(x => x.RegisteredMobileNumber.ToUpper().Replace(" ", "") == obj.RegisteredMobileNumber.ToUpper().Replace(" ", "")).FirstOrDefaultAsync();
                        if (_mobno != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Mobile Number already Exists" };
                        }
                        var _emailId = await db.GtGpdorn.Where(x => x.EmailId.ToUpper().Replace(" ", "") == obj.EmailId.ToUpper().Replace(" ", "")).FirstOrDefaultAsync();
                        if (_emailId != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Email Id already Exists" };
                        }
                        int maxval = db.GtGpdorn.Select(a => a.DonorId).DefaultIfEmpty().Max();
                        int donorId = maxval + 1;
                         var  _dr = new GtGpdorn
                         {
                            BusinessKey = obj.BusinessKey,
                            DonorId = donorId,
                            DonorRegistrationNo =obj.DonorRegistrationNo,
                            DateOfRegistration = System.DateTime.Now.Date,
                            DonorType = obj.DonorType,
                            DonorFirstName = obj.DonorFirstName,
                            DonorMiddleName = obj.DonorMiddleName,
                            DonorLastName = obj.DonorLastName,
                            Gender = obj.Gender,
                            AgeYy = obj.AgeYy,
                            Isdcode = obj.Isdcode,
                            RegisteredMobileNumber = obj.RegisteredMobileNumber,
                            EmailId = obj.EmailId,
                            Password = eSyaCryptGeneration.Encrypt(obj.Password),
                            Address = obj.Address,
                            StateCode = obj.StateCode,
                            CityCode = obj.CityCode,
                            Pincode = obj.Pincode,
                            AreaCode = obj.AreaCode,
                            RoomType = obj.RoomType,
                            NoOfPersons = obj.NoOfPersons,
                            ValidFrom = obj.ValidFrom,
                            ValidTill = obj.ValidTill,
                            Discount = obj.Discount,
                            DonatedSoFar = obj.DonatedSoFar,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };
                        db.GtGpdorn.Add(_dr);
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Donor Registered Successfully"};
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

        public async Task<DO_ReturnParameter> UpdateIntoDonorRegistration(DO_DonorRegistration obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGpdorn _dr = await db.GtGpdorn.Where(x => x.BusinessKey == obj.BusinessKey && x.DonorId == obj.DonorId).FirstOrDefaultAsync();
                        if (_dr == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor not Exists" };
                        }
                        var _regtno = await db.GtGpdorn.Where(x => x.DonorRegistrationNo.ToUpper().Replace(" ", "") == obj.DonorRegistrationNo.ToUpper().Replace(" ", "") && x.DonorId!=obj.DonorId).FirstOrDefaultAsync();
                        if (_regtno != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor Registration Number already Exists" };
                        }
                        var _mobno = await db.GtGpdorn.Where(x => x.RegisteredMobileNumber.ToUpper().Replace(" ", "") == obj.RegisteredMobileNumber.ToUpper().Replace(" ", "") && x.DonorId != obj.DonorId).FirstOrDefaultAsync();
                        if (_mobno != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Mobile Number already Exists" };
                        }
                        var _emailId = await db.GtGpdorn.Where(x => x.EmailId.ToUpper().Replace(" ", "") == obj.EmailId.ToUpper().Replace(" ", "") && x.DonorId != obj.DonorId).FirstOrDefaultAsync();
                        if (_emailId != null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Email Id already Exists" };
                        }
                        else
                        {

                            _dr.DonorRegistrationNo = obj.DonorRegistrationNo;
                            _dr.DateOfRegistration = System.DateTime.Now.Date;
                            _dr.DonorType = obj.DonorType;
                            _dr.DonorFirstName = obj.DonorFirstName;
                            _dr.DonorMiddleName = obj.DonorMiddleName;
                            _dr.DonorLastName = obj.DonorLastName;
                            _dr.Gender = obj.Gender;
                            _dr.AgeYy = obj.AgeYy;
                            _dr.Isdcode = obj.Isdcode;
                            _dr.RegisteredMobileNumber = obj.RegisteredMobileNumber;
                            _dr.EmailId = obj.EmailId;
                            //_dr.Password = eSyaCryptGeneration.Encrypt(obj.Password);
                            _dr.Address = obj.Address;
                            _dr.StateCode = obj.StateCode;
                            _dr.CityCode = obj.CityCode;
                            _dr.Pincode = obj.Pincode;
                            _dr.AreaCode = obj.AreaCode;
                            _dr.RoomType = obj.RoomType;
                            _dr.NoOfPersons = obj.NoOfPersons;
                            _dr.ValidFrom = obj.ValidFrom;
                            _dr.ValidTill = obj.ValidTill;
                            _dr.Discount = obj.Discount;
                            _dr.DonatedSoFar = obj.DonatedSoFar;
                            _dr.ActiveStatus = obj.ActiveStatus;
                            _dr.ModifiedBy = obj.UserID;
                            _dr.ModifiedOn = DateTime.Now;
                            _dr.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Donor Updated sucessfully."};

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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveDonorRegistration(bool status, int businesskey, int donorId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGpdorn _dr = db.GtGpdorn.Where(p => p.BusinessKey == businesskey && p.DonorId == donorId).FirstOrDefault();
                        if (_dr == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Donor is not exist" };
                        }
                        if (_dr != null)
                        {
                            _dr.ActiveStatus = status;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                        }
                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Donor Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Donor De Activated Successfully." };
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

        public async Task<List<DO_DonorRules>> GetRoomTypesbyDonorId(int donortype)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdorl
                        .Join(db.GtGprmty,
                      x => new { x.RoomType },
                      y => new { RoomType = y.RoomTypeId },
                     (x, y) => new { x, y }).Where(z => z.x.DonorType == donortype && z.x.ActiveStatus && z.y.ActiveStatus)
                       .Select(d => new DO_DonorRules
                       {
                           RoomType = d.x.RoomType,
                           RoomTypeDesc = d.y.RoomTypeDesc,
                           NoOfPersons = d.x.NoOfPersons,
                           DiscountPercentage = d.x.DiscountPercentage
                       }).ToListAsync();
                    return await ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_DonorRules> GetDiscountbyDonorId(int donortype, int roomType)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdorl.Where(k => k.DonorType == donortype && k.RoomType == roomType)
                                .Select(x => new DO_DonorRules
                                {
                                    DiscountPercentage = x.DiscountPercentage,
                                    NoOfPersons = x.NoOfPersons
                                }).FirstOrDefaultAsync();
                    return await ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion 

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
    }
}
