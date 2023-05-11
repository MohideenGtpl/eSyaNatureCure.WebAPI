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
   public class PackageAmenitiesRepository:IPackageAmenitiesRepository
    {
        #region Package Amenities

        public async Task<List<DO_PackageAmenities>> GetAllPackageAmenitiesbyPackageId(int pacakgeId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    if (pacakgeId == 0)
                    {
                        var ds = db.GtGppkop.Join(db.GtGppkms,
                          x => x.PackageId,
                          y => y.PackageId,
                          (x, y) => new DO_PackageAmenities

                          {
                              PackageId = x.PackageId,
                              OptionType = x.OptionType,
                              SerialNumber = x.SerialNumber,
                              OptionValues = x.OptionValues,
                              OptionDesc = x.OptionDesc,
                              ActiveStatus = x.ActiveStatus,
                              PackageDesc=y.PackageDesc
                          }).ToListAsync();
                        return await ds;
                    }

                    else
                    {

                        var ds = db.GtGppkop.Where(x => x.PackageId == pacakgeId).Join(db.GtGppkms,
                         x => x.PackageId,
                         y => y.PackageId,
                        (x, y) => new DO_PackageAmenities

                        {
                            PackageId = x.PackageId,
                            OptionType = x.OptionType,
                            SerialNumber = x.SerialNumber,
                            OptionValues = x.OptionValues,
                            OptionDesc = x.OptionDesc,
                            ActiveStatus = x.ActiveStatus,
                            PackageDesc = y.PackageDesc
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

        public async Task<DO_ReturnParameter> InsertPackageAmenities(DO_PackageAmenities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGppkop is_pkAmenities = db.GtGppkop.FirstOrDefault(b => b.PackageId == obj.PackageId && b.OptionType.ToUpper().Replace(" ", "") == obj.OptionType.ToUpper().Replace(" ", "")
                        && b.SerialNumber == obj.SerialNumber);
                        if (is_pkAmenities == null)
                        {

                            var pkAmenities = new GtGppkop
                            {
                                PackageId = obj.PackageId,
                                OptionType = obj.OptionType,
                                SerialNumber = obj.SerialNumber,
                                OptionValues = obj.OptionValues,
                                OptionDesc = obj.OptionDesc,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGppkop.Add(pkAmenities);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Package Amenities Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Package Amenities already already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdatePackageAmenities(DO_PackageAmenities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGppkop pkgAmenities = db.GtGppkop.FirstOrDefault(b => b.PackageId == obj.PackageId && b.OptionType.ToUpper().Replace(" ", "") == obj.OptionType.ToUpper().Replace(" ", "")
                                              && b.SerialNumber == obj.SerialNumber);

                        if (pkgAmenities != null)
                        {

                            pkgAmenities.PackageId = obj.PackageId;
                            pkgAmenities.OptionType = obj.OptionType;
                            pkgAmenities.SerialNumber = obj.SerialNumber;
                            pkgAmenities.OptionValues = obj.OptionValues;
                            pkgAmenities.OptionDesc = obj.OptionDesc;
                            pkgAmenities.ActiveStatus = obj.ActiveStatus;
                            pkgAmenities.ModifiedBy = obj.UserID;
                            pkgAmenities.ModifiedOn = DateTime.Now;
                            pkgAmenities.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Package Amenities updated sucessfully." };


                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Package Amenities" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActivePackageAmenities(DO_PackageAmenities obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGppkop pkgAmenities = db.GtGppkop.FirstOrDefault(b => b.PackageId == obj.PackageId && b.OptionType.ToUpper().Replace(" ", "") == obj.OptionType.ToUpper().Replace(" ", "")
                                               && b.SerialNumber == obj.SerialNumber);
                        if (pkgAmenities == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Package Amenities  is not exist" };
                        }

                        pkgAmenities.ActiveStatus = obj.Status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (obj.Status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Package Amenities  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Package Amenities De Activated Successfully." };
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

        public async Task<DO_PackageAmenities> GetPackageAmenitiesbyOptiontype(int packageId, string optionType, int serilalNo)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {


                    var ds = db.GtGppkop.Where(x => x.PackageId == packageId && x.OptionType.ToUpper().Replace(" ", "") == optionType.ToUpper().Replace(" ", "")
                    && x.SerialNumber == serilalNo).Join(db.GtGppkms,
                     x => x.PackageId,
                     y => y.PackageId,
                    (x, y) => new DO_PackageAmenities

                    {
                        PackageId = x.PackageId,
                        OptionType = x.OptionType,
                        SerialNumber = x.SerialNumber,
                        OptionValues = x.OptionValues,
                        OptionDesc = x.OptionDesc,
                        ActiveStatus = x.ActiveStatus,
                        PackageDesc = y.PackageDesc
                    }).FirstOrDefaultAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion Package Amenities
    }
}
