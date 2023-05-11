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
    public class PackageMasterRepository : IPackageMasterRepository
    {
        #region Package Master

        public async Task<List<DO_PackageMaster>> GetAllPackageMasters()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGppkms
                        .Select(p => new DO_PackageMaster
                        {
                            PackageId = p.PackageId,
                            PackageDesc = p.PackageDesc,
                            ServiceDesc=p.ServiceDesc,
                            BookingRule=p.BookingRule,
                            BookingWindow=p.BookingWindow,
                            NoOfNights = p.NoOfNights,
                            CheckInWeekDays = p.CheckInWeekDays,
                            CheckInFromTime = p.CheckInFromTime,
                            CheckInToTime = p.CheckInToTime,
                            CheckOutToTime = p.CheckOutToTime,
                            CheckOutFromTime = p.CheckOutFromTime,
                            BookingApplicableFor=p.BookingApplicableFor,
                            ActiveStatus = p.ActiveStatus
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_PackageMaster>> GetActivePackageMasters()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGppkms.Where(x => x.ActiveStatus == true)
                        .Select(r => new DO_PackageMaster
                        {
                            PackageId = r.PackageId,
                            PackageDesc = r.PackageDesc

                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertPackageMaster(DO_PackageMaster obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGppkms is_packageExists = db.GtGppkms.FirstOrDefault(p => p.PackageDesc.ToUpper().Replace(" ", "") == obj.PackageDesc.ToUpper().Replace(" ", ""));
                        if (is_packageExists == null)
                        {
                            int maxval = db.GtGppkms.Select(p => p.PackageId).DefaultIfEmpty().Max();
                            int pckId = maxval + 1;
                            var package = new GtGppkms
                            {
                                PackageId = pckId,
                                PackageDesc = obj.PackageDesc,
                                ServiceDesc=obj.ServiceDesc,
                                BookingRule=obj.BookingRule,
                                BookingWindow=obj.BookingWindow,
                                NoOfNights = obj.NoOfNights,
                                CheckInFromTime = obj.CheckInFromTime,
                                CheckInToTime = obj.CheckInToTime,
                                CheckOutToTime = obj.CheckOutToTime,
                                CheckInWeekDays = obj.CheckInWeekDays,
                                CheckOutFromTime = obj.CheckOutFromTime,
                                BookingApplicableFor=obj.BookingApplicableFor,
                                ActiveStatus=obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGppkms.Add(package);
                            await db.SaveChangesAsync();
                            //
                            if (obj._lstweekdays != null)
                            {
                                foreach (var objday in obj._lstweekdays)
                                {
                                    GtGppkwk objdays = new GtGppkwk
                                    {
                                        PackageId = pckId,
                                        CheckInWeekDays = objday.CheckInWeekdays,
                                        ActiveStatus = objday.ActiveStatus,
                                        FormId = obj.FormId,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtGppkwk.Add(objdays);
                                    await db.SaveChangesAsync();

                                }
                            }
                        //

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Package Created Successfully" };
                            
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Package Description  is already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdatePackageMaster(DO_PackageMaster obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGppkms is_packageExists = db.GtGppkms.FirstOrDefault(p => p.PackageId != obj.PackageId && p.PackageDesc.ToUpper().Replace(" ", "") == obj.PackageDesc.ToUpper().Replace(" ", ""));

                        var package = db.GtGppkms.FirstOrDefault(x => x.PackageId == obj.PackageId);
                        if (package != null)
                        {
                            if (is_packageExists == null)
                            {
                                package.PackageDesc = obj.PackageDesc;
                                package.ServiceDesc = obj.ServiceDesc;
                                package.BookingRule = obj.BookingRule;
                                package.BookingWindow = obj.BookingWindow;
                                package.NoOfNights = obj.NoOfNights;
                                package.CheckInFromTime = obj.CheckInFromTime;
                                package.CheckInToTime = obj.CheckInToTime;
                                package.CheckOutToTime = obj.CheckOutToTime;
                                package.CheckInWeekDays = obj.CheckInWeekDays;
                                package.CheckOutFromTime = obj.CheckOutFromTime;
                                package.BookingApplicableFor = obj.BookingApplicableFor;
                                package.ModifiedBy = obj.UserID;
                                package.ModifiedOn = DateTime.Now;
                                package.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();

                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Package Description  is already Exists try another one." };
                            }

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Package" };
                        }


                        List<GtGppkwk> days = db.GtGppkwk.Where(c => c.PackageId == obj.PackageId).ToList();
                       
                        if (days.Count > 0)
                        {
                            foreach (var d in days)
                            {
                                db.GtGppkwk.Remove(d);
                                db.SaveChanges();
                            }

                        }
                        if (obj._lstweekdays != null)
                        {
                            foreach (var objday in obj._lstweekdays)
                            {
                                GtGppkwk objdays = new GtGppkwk
                                {
                                    PackageId = obj.PackageId,
                                    CheckInWeekDays = objday.CheckInWeekdays,
                                    ActiveStatus = objday.ActiveStatus,
                                    FormId = obj.FormId,
                                    CreatedBy = obj.UserID,
                                    CreatedOn = DateTime.Now,
                                    CreatedTerminal = obj.TerminalID
                                };
                                db.GtGppkwk.Add(objdays);
                                await db.SaveChangesAsync();

                            }
                        }
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Package updated sucessfully." };
                       
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

        public async Task<DO_ReturnParameter> ActiveOrDeActivePackageMaster(bool status, int packageId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGppkms package = db.GtGppkms.Where(p => p.PackageId == packageId).FirstOrDefault();
                        if (package == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Package  is not exist" };
                        }

                        package.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Package  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Package  De Activated Successfully." };
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

        public async Task<List<Do_WeekDays>> GetCheckInWeekDaysByPackageId(int packageId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {

                    var result = db.GtGppkwk.Where(x => x.PackageId == packageId).
                      Select(x => new Do_WeekDays
                      {
                          PackageId=x.PackageId,
                          CheckInWeekdays = x.CheckInWeekDays,
                          ActiveStatus = x.ActiveStatus
                      }).ToListAsync();
                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Package Master

        #region Blocked Package
        public async Task<List<DO_BlockedPackage>> GetBlockedPackagesbyBusinessKey(int businesskey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGppkbl.Where(b=>b.BusinessKey==businesskey).Join(db.GtGppkms,
                        x=>x.PackageId,
                        y=>y.PackageId,
                        (x,y)=> new DO_BlockedPackage
                        {
                            BusinessKey=x.BusinessKey,
                            PackageId = x.PackageId,
                            BlockedPackageDate=x.BlockedPackageDate,
                            TillDate=x.TillDate,
                            Reason=x.Reason,
                            PackageDesc = y.PackageDesc,
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

        public async Task<DO_ReturnParameter> InserBlockedPackage(DO_BlockedPackage obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGppkbl is_blockPack = db.GtGppkbl.FirstOrDefault(a => a.BusinessKey == obj.BusinessKey && a.PackageId==obj.PackageId && a.BlockedPackageDate==obj.BlockedPackageDate);

                        var blockPack_list = db.GtGppkbl.Where(x => x.BusinessKey == obj.BusinessKey && x.PackageId == obj.PackageId
                                     && x.BlockedPackageDate == obj.BlockedPackageDate && x.ActiveStatus).ToList();

                        bool isexists = false;
                        foreach (var item in blockPack_list)
                        {
                            if ((obj.BlockedPackageDate >= item.BlockedPackageDate && obj.BlockedPackageDate < item.TillDate)
                                   || (obj.TillDate > item.BlockedPackageDate && obj.TillDate <= item.TillDate))
                            {
                                isexists = true;
                            }
                        }
                        if (isexists == true)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Selected Package is already blocked for selected dates." };
                        }

                        if (is_blockPack == null)
                        {
                           
                            var bpckage = new GtGppkbl
                            {
                                BusinessKey = obj.BusinessKey,
                                PackageId =obj.PackageId,
                                BlockedPackageDate=obj.BlockedPackageDate,
                                TillDate=obj.TillDate,
                                Reason=obj.Reason,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtGppkbl.Add(bpckage);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Saved/Updated Successfully" };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Already Exists" };
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

        public async Task<DO_ReturnParameter> UpdateBlockedPackage(DO_BlockedPackage obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGppkbl _blockPack = db.GtGppkbl.FirstOrDefault(a => a.BusinessKey == obj.BusinessKey && a.PackageId == obj.PackageId && a.BlockedPackageDate == obj.BlockedPackageDate);

                        if (_blockPack != null)
                        {
                            _blockPack.BlockedPackageDate = obj.BlockedPackageDate;
                            _blockPack.TillDate = obj.TillDate;
                            _blockPack.Reason = obj.Reason;
                            _blockPack.ActiveStatus = obj.ActiveStatus;
                            _blockPack.ModifiedBy = obj.UserID;
                            _blockPack.ModifiedOn = System.DateTime.Now;
                            _blockPack.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Updated Successfully" };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Not Exists" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveBlockedPackage(DO_BlockedPackage obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGppkbl _blockPack = db.GtGppkbl.FirstOrDefault(a => a.BusinessKey == obj.BusinessKey && a.PackageId == obj.PackageId && a.BlockedPackageDate == obj.BlockedPackageDate);
                        if (_blockPack == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Not Exists" };
                        }

                        _blockPack.ActiveStatus = obj.a_status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        if (obj.a_status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "De Activated Successfully." };
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
    }
}
