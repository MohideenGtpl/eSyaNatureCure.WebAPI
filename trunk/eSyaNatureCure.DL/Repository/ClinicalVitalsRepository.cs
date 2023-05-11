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
    public class ClinicalVitalsRepository : IClinicalVitalsRepository
    {
        public async Task<List<DO_ClinicalInformation>> GetClinicalInformation(int businessKey, long UHID, long ipNumber, string clType)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var cl = await db.GtGptbav
                    .Where(w => w.BusinessKey == businessKey && w.Uhid == UHID && (w.Ipnumber == ipNumber || w.Ipnumber == 0)
                       && clType.Contains(w.Cltype) && w.ActiveStatus)
                    .Select(x => new DO_ClinicalInformation
                    {
                        CLControlID = x.ClcontrolId,
                        CLType = x.Cltype,
                        Value = x.Value,
                        ValueType = x.ValueType
                    }).ToListAsync();


                    return cl;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public async Task<DO_ReturnParameter> InsertIntoClinicalInformation(DO_ClinicalInformation obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var c in obj.l_ControlValue)
                        {
                            var exist = db.GtGptbav.Where(w => w.BusinessKey == obj.BusinessKey && w.Uhid == obj.UHID && w.Ipnumber == obj.ipNumber && w.ClcontrolId == c.CLControlID).FirstOrDefault();
                            if (exist != null)
                            {
                                if (c.Value == null)
                                {
                                    exist.ActiveStatus = false;
                                }
                                else
                                {
                                    exist.ValueType = c.ValueType;
                                    exist.Value = c.Value;
                                    exist.ActiveStatus = true;
                                    exist.ModifiedBy = obj.UserID;
                                    exist.ModifiedOn = System.DateTime.Now;
                                    exist.ModifiedTerminal = obj.TerminalID;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(c.Value))
                                {
                                    GtGptbav cl = new GtGptbav
                                    {
                                        BusinessKey = obj.BusinessKey,
                                        Uhid = obj.UHID,
                                        Ipnumber = obj.ipNumber,
                                        TransactionId = 0,
                                        TransactionDate = obj.TransactionDate,
                                        Cltype = c.CLType,
                                        ClcontrolId = c.CLControlID,
                                        ValueType = c.ValueType,
                                        Value = c.Value,
                                        ActiveStatus = true,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtGptbav.Add(cl);

                                }
                            }
                        }
                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public async Task<List<DO_ClinicalInformation>> GetInformationValueView(int businessKey, long UHID, long ipNumber, string clType)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ip = await db.GtGptbav
                        .Where(w => w.BusinessKey == businessKey && w.Uhid == UHID && (w.Ipnumber == ipNumber || ipNumber == -1)
                           && w.Cltype == clType && w.ActiveStatus)
                        .Select(x => new DO_ClinicalInformation
                        {
                            //TransactionID = x.TransactionId,
                            TransactionDate = x.TransactionDate,
                            ipNumber = Convert.ToInt32(x.Ipnumber)

                        }).Distinct().ToListAsync();

                    var cl = ip.Select(x => new DO_ClinicalInformation
                    {
                        TransactionID = x.TransactionID,
                        TransactionDate = x.TransactionDate,
                        ipNumber = x.ipNumber,
                        ChartNumber = x.ChartNumber,
                        l_ControlValue = db.GtGptbav.Where(w => w.BusinessKey == businessKey && w.Uhid == UHID && w.Ipnumber == x.ipNumber
                                                                && w.Cltype == clType && w.TransactionId == x.TransactionID && w.ActiveStatus)
                                            .Select(c => new DO_ControlValue
                                            {
                                                CLControlID = c.ClcontrolId,
                                                CLType = c.Cltype,
                                                Value = c.Value,

                                            }).ToList()
                    }).OrderBy(o => o.TransactionDate).ToList();


                    return cl;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<DO_ReturnParameter> InsertPatientClinicalInformation(DO_ClinicalInformation obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var sl = db.GtGptbav.Where(w => w.BusinessKey == obj.BusinessKey && w.Uhid == obj.UHID && w.Ipnumber == obj.ipNumber).Select(s => s.TransactionId).DefaultIfEmpty(0).Max() + 1;

                        foreach (var c in obj.l_ControlValue)
                        {
                            if (!string.IsNullOrEmpty(c.Value))
                            {
                                GtGptbav cl = new GtGptbav
                                {
                                    BusinessKey = obj.BusinessKey,
                                    Uhid = obj.UHID,
                                    Ipnumber = obj.ipNumber,
                                    TransactionId = sl,
                                    TransactionDate = obj.TransactionDate,
                                    Cltype = c.CLType,
                                    ClcontrolId = c.CLControlID,
                                    ValueType = c.ValueType,
                                    Value = c.Value,
                                    //ChartNumber = chartNumber,
                                    ActiveStatus = true,
                                    FormId = obj.FormID,
                                    CreatedBy = obj.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = obj.TerminalID
                                };
                                db.GtGptbav.Add(cl);
                            }
                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }

                }
            }

        }
        public async Task<DO_ReturnParameter> UpdatePatientClinicalInformation(DO_ClinicalInformation obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {

                        foreach (var c in obj.l_ControlValue)
                        {
                            if (!string.IsNullOrEmpty(c.Value))
                            {
                                var cl = db.GtGptbav.Where(w => w.BusinessKey == obj.BusinessKey
                                            && w.Uhid == obj.UHID && w.Ipnumber == obj.ipNumber
                                            && w.TransactionId == obj.TransactionID
                                            && w.ClcontrolId == c.CLControlID).FirstOrDefault();
                                if (cl == null)
                                {
                                    cl = new GtGptbav
                                    {
                                        BusinessKey = obj.BusinessKey,
                                        Uhid = obj.UHID,
                                        Ipnumber = obj.ipNumber,
                                        TransactionId = obj.TransactionID,
                                        TransactionDate = obj.TransactionDate,
                                        Cltype = c.CLType,
                                        ClcontrolId = c.CLControlID,
                                        ValueType = c.ValueType,
                                        Value = c.Value,
                                        ActiveStatus = true,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtGptbav.Add(cl);
                                }
                                else
                                {
                                    cl.ValueType = c.ValueType;
                                    cl.Value = c.Value;
                                    cl.ActiveStatus = obj.ActiveStatus;
                                    cl.ModifiedBy = obj.UserID;
                                    cl.ModifiedOn = System.DateTime.Now;
                                    cl.ModifiedTerminal = obj.TerminalID;
                                }
                            }
                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }

        }
        public async Task<List<DO_ClinicalInformation>> GetClinicalInformationValueByTransaction(int businessKey, long UHID, long ipNumber, int transactionID)
        {


            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var r = await db.GtGptbav
                    .Where(w => w.BusinessKey == businessKey && w.Uhid == UHID && w.Ipnumber == ipNumber
                       && w.TransactionId == transactionID
                       && w.ActiveStatus)
                    .Select(x => new DO_ClinicalInformation
                    {
                        TransactionID = x.TransactionId,
                        TransactionDate = x.TransactionDate,
                        CLControlID = x.ClcontrolId,
                        ValueType = x.ValueType,
                        Value = x.Value
                    }).OrderBy(o => o.TransactionDate).ToListAsync();

                    return r;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public async Task<DO_ReturnParameter> DeletePatientClinicalInformation(DO_ClinicalInformation obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var cl = db.GtGptbav.Where(w => w.BusinessKey == obj.BusinessKey
                            && w.Uhid == obj.UHID && w.Ipnumber == obj.ipNumber
                            && w.TransactionId == obj.TransactionID
                            && w.Cltype == obj.CLType).ToList();
                        foreach (var c in cl)
                        {
                            c.ActiveStatus = false;
                            c.ModifiedBy = obj.UserID;
                            c.ModifiedOn = System.DateTime.Now;
                            c.ModifiedTerminal = obj.TerminalID;
                        }


                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Deleted Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
