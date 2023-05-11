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
    public class BedMasterRepository: IBedMasterRepository
    {
        #region Bed Master

        public async Task<List<DO_BedMaster>> GetAllBedMastersbyRoomType(int roomtype)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    if (roomtype == 0)
                    {
                    var ds = db.GtGprmbm.Join(db.GtGprmty,
                      x => x.RoomTypeId,
                      y => y.RoomTypeId,
                      (x, y) => new DO_BedMaster
                       
                        {
                            RoomTypeId = x.RoomTypeId,
                            RoomNumber = x.RoomNumber,
                            BedNumber = x.BedNumber,
                            Gender = x.Gender,
                            ReservedStatus = x.ReservedStatus,
                            CheckedIn = x.CheckedIn,
                            CheckedOut = x.CheckedOut,
                            ReadyForOccupancy = x.ReadyForOccupancy,
                            ActiveStatus = x.ActiveStatus,
                            RoomTypeDesc=y.RoomTypeDesc
                        }).ToListAsync();
                    return await ds;
                    }

                    else
                    {

                     var ds = db.GtGprmbm.Where(x => x.RoomTypeId == roomtype).Join(db.GtGprmty,
                      x => x.RoomTypeId,
                      y => y.RoomTypeId,
                      (x, y) => new DO_BedMaster

                      {
                          RoomTypeId = x.RoomTypeId,
                          RoomNumber = x.RoomNumber,
                          BedNumber = x.BedNumber,
                          Gender = x.Gender,
                          ReservedStatus = x.ReservedStatus,
                          CheckedIn = x.CheckedIn,
                          CheckedOut = x.CheckedOut,
                          ReadyForOccupancy = x.ReadyForOccupancy,
                          ActiveStatus = x.ActiveStatus,
                          RoomTypeDesc = y.RoomTypeDesc
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

        public async Task<DO_ReturnParameter> InsertBedmaster(DO_BedMaster obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGprmbm is_bedmasterExists = db.GtGprmbm.FirstOrDefault(b =>b.RoomTypeId==obj.RoomTypeId && b.RoomNumber.ToUpper().Replace(" ", "") == obj.RoomNumber.ToUpper().Replace(" ", "")
                        && b.BedNumber.ToUpper().Replace(" ", "") == obj.BedNumber.ToUpper().Replace(" ", ""));
                        if (is_bedmasterExists == null)
                        {
                            
                            var bedmaster = new GtGprmbm
                            {
                                RoomTypeId = obj.RoomTypeId,
                                RoomNumber = obj.RoomNumber,
                                BedNumber = obj.BedNumber,
                                Gender = obj.Gender,
                                ReservedStatus = obj.ReservedStatus,
                                CheckedIn = obj.CheckedIn,
                                CheckedOut = obj.CheckedOut,
                                ReadyForOccupancy = obj.ReadyForOccupancy,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGprmbm.Add(bedmaster);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Bed Master Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Bed Master already already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateBedmaster(DO_BedMaster obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGprmbm bedmaster = db.GtGprmbm.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.RoomNumber.ToUpper().Replace(" ", "") == obj.RoomNumber.ToUpper().Replace(" ", "")
                                              && b.BedNumber.ToUpper().Replace(" ", "") == obj.BedNumber.ToUpper().Replace(" ", ""));
                        
                        if (bedmaster != null)
                        {

                            bedmaster.Gender = obj.Gender;
                            bedmaster.ReservedStatus = obj.ReservedStatus;
                            bedmaster.CheckedIn = obj.CheckedIn;
                            bedmaster.CheckedOut = obj.CheckedOut;
                            bedmaster.ReadyForOccupancy = obj.ReadyForOccupancy;
                            bedmaster.ActiveStatus = obj.ActiveStatus;
                            bedmaster.ModifiedBy = obj.UserID;
                            bedmaster.ModifiedOn = DateTime.Now;
                            bedmaster.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Bed Master updated sucessfully." };
                            
                           
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Bed Master" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveBedMaster(DO_BedMaster obj )
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGprmbm bedmaster = db.GtGprmbm.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.RoomNumber.ToUpper().Replace(" ", "") == obj.RoomNumber.ToUpper().Replace(" ", "")
                                               && b.BedNumber.ToUpper().Replace(" ", "") == obj.BedNumber.ToUpper().Replace(" ", ""));
                        if (bedmaster == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Bed Master  is not exist" };
                        }

                        bedmaster.ActiveStatus = obj.Status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (obj.Status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Bed Master  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Bed Master  De Activated Successfully." };
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

        public async Task<List<DO_BedMaster>> GetActiveRoomNumber()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    
                        var ds = db.GtGprmbm.Where(x=>x.ActiveStatus==true).Select(
                           r=> new DO_BedMaster

                          {
                              RoomTypeId=r.RoomTypeId,
                               RoomNumber = r.RoomNumber
                              
                          }).GroupBy(z => new { z.RoomNumber }).Select(c => c.First()).ToListAsync();
                    return await ds;
                    

                    

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_BedMaster>> GetActiveBedNumber()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                   
                        var ds = db.GtGprmbm.Where(x=>x.ActiveStatus==true).Select
                          (x => new DO_BedMaster

                          {
                              RoomTypeId = x.RoomTypeId,
                              BedNumber = x.BedNumber
                          }).GroupBy(z=>new { z.BedNumber }).Select(c => c.First()).ToListAsync();
                        return await ds;
                  
                     



                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion Bed Master
    }
}
