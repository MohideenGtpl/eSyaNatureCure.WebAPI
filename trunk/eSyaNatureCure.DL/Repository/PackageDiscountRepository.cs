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
   public class PackageDiscountRepository: IPackageDiscountRepository
    {
        #region Package discount

        public async Task<List<DO_PackageDiscount>> GetAllPackageDiscountbyPackageId(int packageId,int roomtypeId,string occupancyType)
        {
            //using (var db = new eSyaEnterprise())
            //{
            try
            {
                //if (packageId == 0 && roomtypeId==0 && occupancyType !="All")
                //{
                //    var result = db.GtGppkdc.Join(db.GtGppkms, lkey => new { lkey.PackageId },
                //        ent => new { ent.PackageId },
                //        (lkey, ent) => new { lkey, ent }).Join(db.GtGprmty,
                //        Bloc => new { Bloc.lkey.RoomTypeId },
                //        seg => new { seg.RoomTypeId },
                //        (Bloc, seg) => new { Bloc, seg })
                //        .Select(c => new DO_PackageDiscount
                //        {
                //            PackageId = c.Bloc.lkey.PackageId,
                //            RoomTypeId = c.Bloc.lkey.RoomTypeId,
                //            OccupancyType = c.Bloc.lkey.OccupancyType,
                //            EffectiveDate = c.Bloc.lkey.EffectiveDate,
                //            DiscountAmount = c.Bloc.lkey.DiscountAmount,
                //            TillDate = c.Bloc.lkey.TillDate,
                //            ActiveStatus = c.Bloc.lkey.ActiveStatus,
                //            RoomTypeDesc = c.seg.RoomTypeDesc,
                //            PackageDesc = c.Bloc.ent.PackageDesc

                //        }).ToListAsync();
                //    return await result;
                //}

                //else
                //{

                //    var result = db.GtGppkdc.Where(x => x.PackageId == packageId &&
                //     x.RoomTypeId==roomtypeId && x.OccupancyType.ToUpper().Trim()== occupancyType.ToUpper().Trim())
                //    .Join(db.GtGppkms, lkey => new { lkey.PackageId },
                //        ent => new { ent.PackageId },
                //        (lkey, ent) => new { lkey, ent }).Join(db.GtGprmty,
                //        Bloc => new { Bloc.lkey.RoomTypeId },
                //        seg => new { seg.RoomTypeId },
                //        (Bloc, seg) => new { Bloc, seg })
                //        .Select(c => new DO_PackageDiscount
                //        {
                //            PackageId = c.Bloc.lkey.PackageId,
                //            RoomTypeId = c.Bloc.lkey.RoomTypeId,
                //            OccupancyType = c.Bloc.lkey.OccupancyType,
                //            EffectiveDate = c.Bloc.lkey.EffectiveDate,
                //            DiscountAmount = c.Bloc.lkey.DiscountAmount,
                //            TillDate = c.Bloc.lkey.TillDate,
                //            ActiveStatus = c.Bloc.lkey.ActiveStatus,
                //            RoomTypeDesc = c.seg.RoomTypeDesc,
                //            PackageDesc = c.Bloc.ent.PackageDesc
                //        }).ToListAsync();
                //    return await result;
                //}
                using (var db = new eSyaEnterprise())
                {
                    if (packageId == 0)
                    {
                        var ds = db.GtGppkdc
                            .Join(db.GtGppkms,
                                 a => new { a.PackageId },
                                 p => new { p.PackageId },
                                 (a, p) => new { a, p })
                            .Join(db.GtGprmty,
                                apd => apd.a.RoomTypeId,
                                s => s.RoomTypeId,
                                (apd, s) => new { apd, s })
                            .Where(w =>packageId==0
                              && (roomtypeId == 0 || w.apd.a.RoomTypeId == roomtypeId)
                                && (occupancyType == "0" || w.apd.a.OccupancyType == occupancyType))
                            //.Where(w => w.apd.a.PackageId == packageId || packageId == 0
                            //    && (roomtypeId == 0||w.apd.a.RoomTypeId == roomtypeId)
                            //    && (occupancyType == "0"||w.apd.a.OccupancyType == occupancyType ))
                            .Select(r => new DO_PackageDiscount
                            {
                                PackageId = r.apd.a.PackageId,
                                RoomTypeId = r.apd.a.RoomTypeId,
                                OccupancyType = r.apd.a.OccupancyType,
                                EffectiveDate = r.apd.a.EffectiveDate,
                                DiscountAmount = r.apd.a.DiscountAmount,
                                TillDate = r.apd.a.TillDate,
                                ActiveStatus = r.apd.a.ActiveStatus,
                                RoomTypeDesc = r.s.RoomTypeDesc,
                                PackageDesc = r.apd.p.PackageDesc

                            }).ToListAsync();
                        return await ds;
                    }
                    else
                    {
                        var ds = db.GtGppkdc
                        .Join(db.GtGppkms,
                             a => new { a.PackageId },
                             p => new { p.PackageId },
                             (a, p) => new { a, p })
                        .Join(db.GtGprmty,
                            apd => apd.a.RoomTypeId,
                            s => s.RoomTypeId,
                            (apd, s) => new { apd, s })
                        .Where(w => w.apd.a.PackageId == packageId
                            && (roomtypeId == 0 || w.apd.a.RoomTypeId == roomtypeId)
                            && (occupancyType == "0" || w.apd.a.OccupancyType == occupancyType))
                        //.Where(w => w.apd.a.PackageId == packageId || packageId == 0
                        //    && (roomtypeId == 0||w.apd.a.RoomTypeId == roomtypeId)
                        //    && (occupancyType == "0"||w.apd.a.OccupancyType == occupancyType ))
                        .Select(r => new DO_PackageDiscount
                        {
                            PackageId = r.apd.a.PackageId,
                            RoomTypeId = r.apd.a.RoomTypeId,
                            OccupancyType = r.apd.a.OccupancyType,
                            EffectiveDate = r.apd.a.EffectiveDate,
                            DiscountAmount = r.apd.a.DiscountAmount,
                            TillDate = r.apd.a.TillDate,
                            ActiveStatus = r.apd.a.ActiveStatus,
                            RoomTypeDesc = r.s.RoomTypeDesc,
                            PackageDesc = r.apd.p.PackageDesc

                        }).ToListAsync();

                        return await ds;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
        }

        public async Task<DO_ReturnParameter> InsertPackageDiscount(DO_PackageDiscount obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGppkdc is_pkdisExists = db.GtGppkdc.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.OccupancyType.ToUpper().Replace(" ", "") == obj.OccupancyType.ToUpper().Replace(" ", "")
                        && b.PackageId == obj.PackageId && b.EffectiveDate==obj.EffectiveDate);
                        if (is_pkdisExists == null)
                        {

                            var p_dis = new GtGppkdc
                            {
                                RoomTypeId = obj.RoomTypeId,
                                PackageId = obj.PackageId,
                                OccupancyType = obj.OccupancyType,
                                EffectiveDate = obj.EffectiveDate,
                                TillDate=obj.TillDate,
                                DiscountAmount = obj.DiscountAmount,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGppkdc.Add(p_dis);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Package discount Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Package discount already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdatePackageDiscount(DO_PackageDiscount obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGppkdc pkgdis = db.GtGppkdc.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.OccupancyType.ToUpper().Replace(" ", "") == obj.OccupancyType.ToUpper().Replace(" ", "")
                        && b.PackageId == obj.PackageId && b.EffectiveDate==obj.EffectiveDate);

                        if (pkgdis != null)
                        {

                            pkgdis.RoomTypeId = obj.RoomTypeId;
                            pkgdis.PackageId = obj.PackageId;
                            pkgdis.DiscountAmount = obj.DiscountAmount;
                            pkgdis.TillDate = obj.TillDate;
                            pkgdis.ActiveStatus = obj.ActiveStatus;
                            pkgdis.ModifiedBy = obj.UserID;
                            pkgdis.ModifiedOn = DateTime.Now;
                            pkgdis.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Package discount Updated sucessfully." };


                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Package discount" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActivePackageDiscount(DO_PackageDiscount obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGppkdc pkgdis = db.GtGppkdc.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.OccupancyType.ToUpper().Replace(" ", "") == obj.OccupancyType.ToUpper().Replace(" ", "")
                                             && b.PackageId == obj.PackageId && b.EffectiveDate==obj.EffectiveDate);
                        if (pkgdis == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Package discount  is not exist" };
                        }

                        pkgdis.ActiveStatus = obj.Status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (obj.Status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Package discount  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Package discount  De Activated Successfully." };
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

        #endregion Package 
    }
}
