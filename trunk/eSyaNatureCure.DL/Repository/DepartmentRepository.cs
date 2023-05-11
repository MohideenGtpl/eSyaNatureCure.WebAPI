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
   public class DepartmentRepository: IDepartmentRepository
    {
        #region Department

        public async Task<List<DO_Department>> GetAllDepartments()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdept
                        .Select(d => new DO_Department
                        {
                            DepartmentId = d.DepartmentId,
                            DepartmentDesc = d.DepartmentDesc,
                            ShortCode = d.ShortCode,
                            SequenceNumber=d.SequenceNumber,
                            ActiveStatus = d.ActiveStatus
                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertIntoDepartment(DO_Department obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGpdept is_deptExists = db.GtGpdept.FirstOrDefault(a => a.DepartmentDesc.ToUpper().Replace(" ", "") == obj.DepartmentDesc.ToUpper().Replace(" ", ""));
                        if (is_deptExists == null)
                        {
                            int maxval = db.GtGpdept.Select(a => a.SequenceNumber).DefaultIfEmpty().Max();
                            int deptId = maxval + 1;
                            var dept = new GtGpdept
                            {
                                DepartmentId = deptId,
                                SequenceNumber=obj.SequenceNumber,
                                DepartmentDesc = obj.DepartmentDesc,
                                ShortCode = obj.ShortCode,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };

                            db.GtGpdept.Add(dept);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Department Created Successfully" };

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Department Description  is already Exists try another one." };
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

        public async Task<DO_ReturnParameter> UpdateDepartment(DO_Department obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {

                    try
                    {
                        GtGpdept is_deptExists = db.GtGpdept.FirstOrDefault(a => a.DepartmentId != obj.DepartmentId && a.DepartmentDesc.ToUpper().Replace(" ", "") == obj.DepartmentDesc.ToUpper().Replace(" ", ""));

                        var dept = db.GtGpdept.FirstOrDefault(x => x.DepartmentId == obj.DepartmentId);
                        if (dept != null)
                        {
                            if (is_deptExists == null)
                            {
                                dept.DepartmentId = obj.DepartmentId;
                                dept.DepartmentDesc = obj.DepartmentDesc;
                                dept.ShortCode = obj.ShortCode;
                                dept.SequenceNumber = obj.SequenceNumber;
                                dept.ActiveStatus = obj.ActiveStatus;
                                dept.ModifiedBy = obj.UserID;
                                dept.ModifiedOn = DateTime.Now;
                                dept.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();
                                dbContext.Commit();
                                return new DO_ReturnParameter() { Status = true, Message = "Department Updated sucessfully." };
                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Department Description  is already Exists try another one." };
                            }
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Couldn't find Department" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveDepartment(bool status, int deptId)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtGpdept dept = db.GtGpdept.Where(p => p.DepartmentId == deptId).FirstOrDefault();
                        if (dept == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Department  is not exist" };
                        }

                        dept.ActiveStatus = status;
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "Department  Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "Department  De Activated Successfully." };
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

        #endregion Department

        #region User Department Link
        public async Task<List<DO_Department>> GetActiveDepartments()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtGpdept.Where(x => x.ActiveStatus == true)
                        .Select(d => new DO_Department
                        {
                            DepartmentId = d.DepartmentId,
                            DepartmentDesc = d.DepartmentDesc

                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_User>> GetActiveUsers()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtEuusms.Where(x => x.ActiveStatus == true)
                        .Select(d => new DO_User
                        {
                            UserId = d.UserId,
                            LoginDesc = d.LoginDesc

                        }).ToListAsync();
                    return await ds;


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_DepartmentUserLink>> GetAllUsersbyDepartmentLink(int deptId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {

                   
                        var ds = db.GtGpdpus.Where(x=>x.DepartmentId==deptId).Join(db.GtGpdept, lkey => new { lkey.DepartmentId },
                            ent => new { ent.DepartmentId },
                            (lkey, ent) => new { lkey, ent }).Join(db.GtEuusms,
                            Bloc => new { Bloc.lkey.UserId },
                            seg => new { seg.UserId },
                            (Bloc, seg) => new { Bloc, seg })
                            .Select(c => new DO_DepartmentUserLink
                            {
                                DepartmentId = c.Bloc.lkey.DepartmentId,
                                UserId = c.Bloc.lkey.UserId,
                                ActiveStatus = c.Bloc.lkey.ActiveStatus,
                                DepartmentName = c.Bloc.ent.DepartmentDesc,
                                UserName = c.seg.LoginDesc

                            }).ToListAsync();
                        return await ds;
                    




                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateUserDepartmentLink(DO_DepartmentUserLink obj)
        {
            using (eSyaEnterprise db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        GtGpdpus _isdeptlink = db.GtGpdpus.FirstOrDefault(a => a.UserId==obj.UserId && a.DepartmentId==obj.DepartmentId);
                        if (_isdeptlink == null)
                        {
                          
                            var deptlink = new GtGpdpus
                            {
                                UserId = obj.UserId,
                                DepartmentId = obj.DepartmentId,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtGpdpus.Add(deptlink);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "User Linked  Successfully to Department" };

                        }
                        else
                        {
                            _isdeptlink.ActiveStatus = obj.ActiveStatus;
                            _isdeptlink.ModifiedBy = obj.UserID;
                            _isdeptlink.ModifiedOn = DateTime.Now;
                            _isdeptlink.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Updated Sucessfully" +
                                "" };
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
    }
}
