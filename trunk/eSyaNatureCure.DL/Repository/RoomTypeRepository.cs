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
    public class RoomTypeRepository: IRoomTypeRepository
    {
        #region Room Type

        public async Task<List<DO_RoomType>> GetAllRoomTypes()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGprmty
                        .Select(r => new DO_RoomType
                        {
                            RoomTypeId = r.RoomTypeId,
                            RoomTypeDesc = r.RoomTypeDesc,
                            BedType = r.BedType,
                            SqFeet = r.SqFeet,
                            MaxOccupancy = r.MaxOccupancy,
                            SharingStatus = r.SharingStatus,
                            ActiveStatus = r.ActiveStatus
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_RoomType>> GetActiveRoomTypes()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGprmty.Where(x=>x.ActiveStatus==true)
                        .Select(r => new DO_RoomType
                        {
                            RoomTypeId = r.RoomTypeId,
                            RoomTypeDesc = r.RoomTypeDesc
                           
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertRoomType(DO_RoomType obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGprmty is_roomtypeExists = db.GtGprmty.FirstOrDefault(r => r.RoomTypeDesc.ToUpper().Replace(" ", "") == obj.RoomTypeDesc.ToUpper().Replace(" ", ""));
                        if (is_roomtypeExists == null)
                        {
                            int maxval = db.GtGprmty.Select(r => r.RoomTypeId).DefaultIfEmpty().Max();
                            int roommtype_Id = maxval + 1;
                            var roomtype = new GtGprmty
                            {
                                RoomTypeId = roommtype_Id,
                                RoomTypeDesc = obj.RoomTypeDesc,
                                BedType = obj.BedType,
                                SqFeet = obj.SqFeet,
                                MaxOccupancy = obj.MaxOccupancy,
                                SharingStatus = obj.SharingStatus,
                                ActiveStatus=obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGprmty.Add(roomtype);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Room Type Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Type Description  is already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateRoomType(DO_RoomType obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGprmty is_roomtypeExists = db.GtGprmty.FirstOrDefault(r => r.RoomTypeId != obj.RoomTypeId && r.RoomTypeDesc.ToUpper().Replace(" ", "") == obj.RoomTypeDesc.ToUpper().Replace(" ", ""));

                        var roomtype = db.GtGprmty.FirstOrDefault(x => x.RoomTypeId == obj.RoomTypeId);
                        if (roomtype != null)
                        {
                            if (is_roomtypeExists == null)
                            {
                                roomtype.RoomTypeDesc = obj.RoomTypeDesc;
                                roomtype.BedType = obj.BedType;
                                roomtype.SqFeet = obj.SqFeet;
                                roomtype.MaxOccupancy = obj.MaxOccupancy;
                                roomtype.SharingStatus = obj.SharingStatus;
                                roomtype.ActiveStatus = obj.ActiveStatus;
                                roomtype.ModifiedBy = obj.UserID;
                                roomtype.ModifiedOn = DateTime.Now;
                                roomtype.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();
                                dbContext.Commit();
                                return new DO_ReturnParameter() { Status = true, Message = "Room Type updated sucessfully." };
                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Room Type Description  is already Exists try another one." };
                            }
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Package" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveRoomType(bool status, int roomTypeId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGprmty roomtype = db.GtGprmty.Where(r => r.RoomTypeId == roomTypeId).FirstOrDefault();
                        if (roomtype == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room type  is not exist" };
                        }

                        roomtype.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Room type  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Room type  De Activated Successfully." };
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

        #endregion Room Type
    }
}
