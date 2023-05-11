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
   public class DaywiseActivitiesRepository:IDaywiseActivitiesRepository
    {
        #region Day wise Activities

        public async Task<List<DO_DaywiseActivities>> GetAllDaywiseActivitiesbyPackageId(int packageId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    if (packageId == 0)
                    {
                        var result = db.GtGppkcv.Join(db.GtGpacms, lkey => new { lkey.ActivityId },
                            ent => new { ent.ActivityId },
                            (lkey, ent) => new { lkey, ent }).Join(db.GtGppkms,
                            Bloc => new { Bloc.lkey.PackageId },
                            seg => new { seg.PackageId },
                            (Bloc, seg) => new { Bloc, seg })
                            .Select(c => new DO_DaywiseActivities
                            {
                                PackageId = c.Bloc.lkey.PackageId,
                                DayId = c.Bloc.lkey.DayId,
                                ActivityId = c.Bloc.lkey.ActivityId,
                                FromTime = c.Bloc.lkey.FromTime,
                                ToTime = c.Bloc.lkey.ToTime,
                                ActiveStatus = c.Bloc.lkey.ActiveStatus,
                                ActivityDesc = c.Bloc.ent.ActivityDesc,
                                PackageDesc = c.seg.PackageDesc
                            }).ToListAsync();
                        return await result;
                    }

                    else
                    {

                        var result = db.GtGppkcv.Where(x=>x.PackageId==packageId).Join(db.GtGpacms, lkey => new { lkey.ActivityId },
                             ent => new { ent.ActivityId },
                             (lkey, ent) => new { lkey, ent }).Join(db.GtGppkms,
                             Bloc => new { Bloc.lkey.PackageId },
                             seg => new { seg.PackageId },
                             (Bloc, seg) => new { Bloc, seg })
                             .Select(c => new DO_DaywiseActivities
                             {
                                 PackageId = c.Bloc.lkey.PackageId,
                                 DayId = c.Bloc.lkey.DayId,
                                 ActivityId = c.Bloc.lkey.ActivityId,
                                 FromTime = c.Bloc.lkey.FromTime,
                                 ToTime = c.Bloc.lkey.ToTime,
                                 ActiveStatus = c.Bloc.lkey.ActiveStatus,
                                 ActivityDesc = c.Bloc.ent.ActivityDesc,
                                 PackageDesc = c.seg.PackageDesc
                             }).ToListAsync();
                        return await result;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertDaywiseActivities(DO_DaywiseActivities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGppkcv is_daywiseExists = db.GtGppkcv.FirstOrDefault(b => b.PackageId == obj.PackageId && b.DayId == obj.PackageId
                        && b.ActivityId == obj.ActivityId);
                        if (is_daywiseExists == null)
                        {

                            var dayactivity = new GtGppkcv
                            {
                                PackageId = obj.PackageId,
                                DayId = obj.DayId,
                                ActivityId = obj.ActivityId,
                                FromTime = obj.FromTime,
                                ToTime = obj.ToTime,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGppkcv.Add(dayactivity);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Day Wise Activity Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Day Wise Activity already already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateDaywiseActivities(DO_DaywiseActivities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGppkcv dayactivity = db.GtGppkcv.FirstOrDefault(b => b.PackageId == obj.PackageId && b.DayId == obj.DayId
                        && b.ActivityId == obj.ActivityId);

                        if (dayactivity != null)
                        {

                            dayactivity.ActivityId = obj.ActivityId;
                            dayactivity.PackageId = obj.PackageId;
                            dayactivity.DayId = obj.DayId;
                            dayactivity.FromTime = obj.FromTime;
                            dayactivity.ToTime = obj.ToTime;
                            dayactivity.ActiveStatus = obj.ActiveStatus;
                            dayactivity.ModifiedBy = obj.UserID;
                            dayactivity.ModifiedOn = DateTime.Now;
                            dayactivity.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Day Wise Activity Updated sucessfully." };


                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Day Wise Activity" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveDayWiseActivities(DO_DaywiseActivities obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGppkcv dayactivity = db.GtGppkcv.FirstOrDefault(b => b.PackageId == obj.PackageId && b.DayId == obj.DayId
                        && b.ActivityId == obj.ActivityId);
                        if (dayactivity == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Day Wise Activity  is not exist" };
                        }

                        dayactivity.ActiveStatus = obj.Status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (obj.Status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Day Wise Activity  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Day Wise Activity  De Activated Successfully." };
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

        #endregion Day wise Activities
    }
}
