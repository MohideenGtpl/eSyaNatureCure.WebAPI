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
   public class ActivitiesRepository:IActivitiesRepository
    {
        #region Activities

        public async Task<List<DO_Activities>> GetAllActivities()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpacms.Select(x=>
                         new DO_Activities
                        {
                            ActivityId = x.ActivityId,
                            ActivityDesc = x.ActivityDesc,
                            ScheduleType = x.ScheduleType,
                            ActiveStatus = x.ActiveStatus,
                            DepartmentId=x.DepartmentId,
                            DepartmentName=x.DepartmentId !=0 ? db.GtGpdept.Where(y=>y.DepartmentId==x.DepartmentId).FirstOrDefault().DepartmentDesc:"None"
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_Activities>> GetActiveActivities()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpacms.Where(x => x.ActiveStatus == true)
                        .Select(r => new DO_Activities
                        {
                            ActivityId = r.ActivityId,
                            ActivityDesc = r.ActivityDesc

                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertActivities(DO_Activities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGpacms is_activitiesExists = db.GtGpacms.FirstOrDefault(a => a.ActivityDesc.ToUpper().Replace(" ", "") == obj.ActivityDesc.ToUpper().Replace(" ", ""));
                        if (is_activitiesExists == null)
                        {
                            int maxval = db.GtGpacms.Select(a => a.ActivityId).DefaultIfEmpty().Max();
                            int activityId = maxval + 1;
                            var activity = new GtGpacms
                            {
                                ActivityId = activityId,
                                ActivityDesc = obj.ActivityDesc,
                                ScheduleType = obj.ScheduleType,
                                DepartmentId=obj.DepartmentId,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGpacms.Add(activity);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Activity Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Activity Description  is already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateActivities(DO_Activities obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGpacms is_activityExists = db.GtGpacms.FirstOrDefault(a => a.ActivityId != obj.ActivityId && a.ActivityDesc.ToUpper().Replace(" ", "") == obj.ActivityDesc.ToUpper().Replace(" ", ""));

                        var activity = db.GtGpacms.FirstOrDefault(x => x.ActivityId == obj.ActivityId);
                        if (activity != null)
                        {
                            if (is_activityExists == null)
                            {
                                activity.ActivityId = obj.ActivityId;
                                activity.ActivityDesc = obj.ActivityDesc;
                                activity.ScheduleType = obj.ScheduleType;
                                activity.ActiveStatus = obj.ActiveStatus;
                                activity.DepartmentId = obj.DepartmentId;
                                activity.ModifiedBy = obj.UserID;
                                activity.ModifiedOn = DateTime.Now;
                                activity.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();
                                dbContext.Commit();
                                return new DO_ReturnParameter() { Status = true, Message = "Activity Updated sucessfully." };
                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Activity Description  is already Exists try another one." };
                            }
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Activity" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveActivities(bool status, int activityId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGpacms activity = db.GtGpacms.Where(p => p.ActivityId == activityId).FirstOrDefault();
                        if (activity == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Activity  is not exist" };
                        }

                        activity.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Activity  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Activity  De Activated Successfully." };
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

        #endregion Activities

    }
}
