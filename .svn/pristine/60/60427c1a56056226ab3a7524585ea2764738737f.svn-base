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
   public class RoomAmenitiesRepository: IRoomAmenitiesRepository
    {
        #region Room Amenities

        public async Task<List<DO_RoomAmenities>> GetAllRoomAmenitiesbyRoomType(int roomtype)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    if (roomtype == 0)
                    {
                        var ds = db.GtGprmop.Join(db.GtGprmty,
                          x => x.RoomTypeId,
                          y => y.RoomTypeId,
                          (x, y) => new DO_RoomAmenities

                          {
                              RoomTypeId = x.RoomTypeId,
                              OptionType = x.OptionType,
                              SerialNumber = x.SerialNumber,
                              OptionValues = x.OptionValues,
                              OptionDesc = x.OptionDesc,
                              ActiveStatus = x.ActiveStatus,
                              RoomTypeDesc = y.RoomTypeDesc
                          }).ToListAsync();
                        return await ds;
                    }

                    else
                    {

                        var ds = db.GtGprmop.Where(x => x.RoomTypeId == roomtype).Join(db.GtGprmty,
                         x => x.RoomTypeId,
                         y => y.RoomTypeId,
                        (x, y) => new DO_RoomAmenities

                        {
                            RoomTypeId = x.RoomTypeId,
                            OptionType = x.OptionType,
                            SerialNumber = x.SerialNumber,
                            OptionValues = x.OptionValues,
                            OptionDesc = x.OptionDesc,
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

        public async Task<DO_ReturnParameter> InsertRoomAmenities(DO_RoomAmenities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGprmop is_roomAmenitiesExists = db.GtGprmop.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.OptionType.ToUpper().Replace(" ", "") == obj.OptionType.ToUpper().Replace(" ", "")
                        && b.SerialNumber == obj.SerialNumber);
                        if (is_roomAmenitiesExists == null)
                        {

                            var roomAmenities = new GtGprmop
                            {
                                RoomTypeId = obj.RoomTypeId,
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

                            db.GtGprmop.Add(roomAmenities);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Room Amenities Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Amenities already already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateRoomAmenities(DO_RoomAmenities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGprmop roomAmenities = db.GtGprmop.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.OptionType.ToUpper().Replace(" ", "") == obj.OptionType.ToUpper().Replace(" ", "")
                                              && b.SerialNumber == obj.SerialNumber);

                        if (roomAmenities != null)
                        {

                            roomAmenities.RoomTypeId = obj.RoomTypeId;
                            roomAmenities.OptionType = obj.OptionType;
                            roomAmenities.SerialNumber = obj.SerialNumber;
                            roomAmenities.OptionValues = obj.OptionValues;
                            roomAmenities.OptionDesc = obj.OptionDesc;
                            roomAmenities.ActiveStatus = obj.ActiveStatus;
                            roomAmenities.ModifiedBy = obj.UserID;
                            roomAmenities.ModifiedOn = DateTime.Now;
                            roomAmenities.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Room Amenities updated sucessfully." };


                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Room Amenities" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveRoomAmenities(DO_RoomAmenities obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGprmop RoomAmenities = db.GtGprmop.FirstOrDefault(b => b.RoomTypeId == obj.RoomTypeId && b.OptionType.ToUpper().Replace(" ", "") == obj.OptionType.ToUpper().Replace(" ", "")
                                               && b.SerialNumber == obj.SerialNumber);
                        if (RoomAmenities == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Amenities  is not exist" };
                        }

                        RoomAmenities.ActiveStatus = obj.Status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (obj.Status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Room Amenities  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Room Amenities De Activated Successfully." };
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


        public async Task<DO_RoomAmenities> GetRoomAmenitiesbyroomtype(int roomTypeId, string optionType, int serilalNo)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    
                   
                        var ds = db.GtGprmop.Where(x => x.RoomTypeId == roomTypeId && x.OptionType.ToUpper().Replace(" ", "") == optionType.ToUpper().Replace(" ", "")
                        && x.SerialNumber==serilalNo).Join(db.GtGprmty,
                         x => x.RoomTypeId,
                         y => y.RoomTypeId,
                        (x, y) => new DO_RoomAmenities

                        {
                            RoomTypeId = x.RoomTypeId,
                            OptionType = x.OptionType,
                            SerialNumber = x.SerialNumber,
                            OptionValues = x.OptionValues,
                            OptionDesc = x.OptionDesc,
                            ActiveStatus = x.ActiveStatus,
                            RoomTypeDesc = y.RoomTypeDesc
                        }).FirstOrDefaultAsync();
                        return await ds;
                    

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion Room Amenities
    }
}
