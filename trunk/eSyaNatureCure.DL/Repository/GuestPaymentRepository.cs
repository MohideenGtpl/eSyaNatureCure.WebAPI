using eSyaNatureCure.DL.Entities;
using eSyaNatureCure.DO;
using eSyaNatureCure.DO.StaticVariables;
using eSyaNatureCure.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.DL.Repository
{
    public class GuestPaymentRepository : IGuestPaymentRepository
    {
        public async Task<DO_ReturnParameter> InsertPatientReceipt(DO_GuestPaymentReceiptDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        //obj.FinancialYear = System.DateTime.Now.Year;
                        obj.VoucherDate = System.DateTime.Now;

                        var financialYear = db.GtEcclco.Where(w => w.BusinessKey == obj.BusinessKey
                                             && DateTime.Now.Date >= w.FromDate.Date
                                             && DateTime.Now.Date <= w.TillDate.Date)
                                 .First().FinancialYear;
                        obj.FinancialYear = Convert.ToInt32(financialYear);

                        int DocID_Receipt = DocumentIdValues.guest_ReceiptId;
                        if(obj.VoucherType == "P" || obj.VoucherType == "J")
                            DocID_Receipt = DocumentIdValues.guest_RefundId;
                      
                        var dc_pr = db.GtEcdcbn
                                        .Where(w => w.BusinessKey == obj.BusinessKey && w.FinancialYear == obj.FinancialYear
                                            && w.DocumentId == DocID_Receipt).FirstOrDefault();
                        dc_pr.CurrentDocNumber++;
                        obj.VoucherDate = System.DateTime.Now;
                        obj.VoucherKey = decimal.Parse(obj.FinancialYear.ToString().Substring(2, 2) + obj.BusinessKey.ToString()   + dc_pr.CurrentDocNumber);

                        GtEfprdt obj_PR = new GtEfprdt
                        {
                            BusinessKey = obj.BusinessKey,
                            FinancialYear = obj.FinancialYear,
                            BookTypeId = DocID_Receipt,
                            VoucherNumber = dc_pr.CurrentDocNumber,
                            VoucherKey = obj.VoucherKey,
                            VoucherType = obj.VoucherType,
                            VoucherDate = obj.VoucherDate,
                            VoucherAmount = obj.VoucherAmount,
                            CollectedAmount = obj.CollectedAmount,
                            RefundAmount = obj.RefundAmount,
                            CancelledAmount = obj.CancelledAmount,
                            Narration = obj.Narration,
                            RefundReason = obj.RefundReason,
                            BillDocumentKey = obj.BillDocumentKey,
                            IsApproved = obj.VoucherType != "J",
                            ActiveStatus = true,
                            FormId = obj.FormID,
                            CreatedBy = obj.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = System.Environment.MachineName,
                        };
                        db.GtEfprdt.Add(obj_PR);

                        db.SaveChanges();

                        GtEfprpm gt_PM = new GtEfprpm
                        {
                            BusinessKey = obj_PR.BusinessKey,
                            VoucherKey = obj_PR.VoucherKey,
                            PaymentMode = obj.PaymentMode,
                            CardType = obj.CardType,
                            CardNumber = obj.CardNumber,
                            CardExpiryDate = obj.CardExpiryDate,
                            ApprovalNumber = obj.ApprovalNumber,
                            ReferenceNumber = obj.ReferenceNumber,
                            MpreferenceNumber = obj.MPReferenceNumber,
                            MpreferenceDate = obj.MPReferenceDate,
                            ChequeNumber = obj.ChequeNumber,
                            ChequeDate = obj.ChequeDate,
                            DraweeBank = obj.DraweeBank,

                            ActiveStatus = true,
                            CreatedBy = obj.UserID,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = System.Environment.MachineName
                        };
                        db.GtEfprpm.Add(gt_PM);

                        db.SaveChanges();

                        var ah = await db.GtGptbkh.Where(w => w.BookingKey == obj.BillDocumentKey).FirstOrDefaultAsync();
                        if (obj.VoucherType == "R")
                        {
                            var totalBillAmount = ah.TotalPackageAmount;

                            var ph = await db.GtEfpbhd.Where(w => w.BusinessKey == obj.BusinessKey && w.BillDocumentKey == ah.BillDocumentKey).FirstOrDefaultAsync();
                            if (ph != null)
                            {
                                totalBillAmount = ph.NetBillAmount;
                            }

                            var totalCollectedAmount = db.GtEfprdt.Where(w => w.BillDocumentKey == obj.BillDocumentKey && w.ActiveStatus)
                                .Sum(s => (s.VoucherType == "R" ? 1 : -1) * s.VoucherAmount);
                            if (totalCollectedAmount > totalBillAmount)
                            {
                                dbContext.Rollback();
                                return new DO_ReturnParameter { Status = false, Message = "Please check the collected amount. Is more than package amount." };
                            }
                            if (ah != null)
                            {
                                ah.PaymentReceived = true;
                            }
                        }
                        if (obj.VoucherType == "P")
                        {
                            var totalCollectedAmount = db.GtEfprdt
                                .Where(w => w.BillDocumentKey == obj.BillDocumentKey && w.ActiveStatus)
                                .Sum(s => (s.VoucherType == "R" ? 1 : -1) * s.VoucherAmount);

                            if(totalCollectedAmount < obj.VoucherAmount)
                            {
                                dbContext.Rollback();
                                return new DO_ReturnParameter { Status = false, Message = "Please check the amount to be refunded. Is more than collected amount." };
                            }

                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter { Status = true };

                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw;
                    }
                }
            }

        }

        public async Task<List<DO_GuestPaymentReceiptDetails>> GetGuestPaymentReceiptDetails(int businessKey, long bookingKey)
        {
            using (var db = new eSyaEnterprise())
            {
                var gp = await db.GtEfprdt
                    .Join(db.GtEfprpm,
                        p => new { p.BusinessKey, p.VoucherKey },
                        m => new { m.BusinessKey, m.VoucherKey },
                        (p, m) => new { p, m })
                    .Where(w => w.p.BusinessKey == businessKey && w.p.BillDocumentKey == bookingKey)
                    .Select(r => new DO_GuestPaymentReceiptDetails
                    {
                        VoucherType = r.p.VoucherType,
                        VoucherTypeDesc = r.p.VoucherType == "R" ? "Receipt" : (r.p.VoucherType == "P"? "Payment" : "Request Refund"),
                        PaymentModeDesc = db.GtEcapcd.Where(w => w.ApplicationCode == r.m.PaymentMode).FirstOrDefault().CodeDesc,
                        VoucherKey = r.p.VoucherKey,
                        VoucherDate = r.p.VoucherDate,
                        VoucherAmount = r.p.VoucherAmount
                    }).ToListAsync();

                return gp;
            }
        }

        public async Task<DO_ReturnParameter> UpdateRefundRequestApproval(DO_GuestPaymentReceiptDetails obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var rf = await db.GtEfprdt.Where(w => w.BusinessKey == obj.BusinessKey && w.VoucherKey == obj.VoucherKey).FirstOrDefaultAsync();
                        rf.VoucherType = "P";
                        rf.IsApproved = true;
                        rf.ApprovedBy = obj.UserID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter() { Status = true, Message = "Updated Sucessfully" };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }


        public async Task<DO_GuestOnlinePaymentResponse> GetPaymentOrderResponseByBookingKey(int businessKey, long bookingKey)
        {
            using (var db = new eSyaEnterprise())
            {
                var gp = await db.GtGptbpi
                    .Where(w => w.BookingKey == bookingKey)
                    .Select(r => new DO_GuestOnlinePaymentResponse
                    {
                        order_id = r.OrderId,
                        amount = r.TransactionAmount,
                        status = r.IsSuccess ? "S":"E",
                        id = r.PaymentId,
                        created_at = r.CreatedOn.ToShortDateString()
                    }).OrderByDescending(o => o.created_at).FirstOrDefaultAsync();

                return gp;
            }
        }
        public async Task<DO_ReturnParameter> CheckOnlinePaymentAndMakePaymentReceipt(DO_GuestOnlinePaymentResponse obj)
        {
            using (var db = new eSyaEnterprise())
            {

                using (var dbContext = db.Database.BeginTransaction())
                {
                    var ord = await db.GtGptbpi.Where(w => w.OrderId == obj.order_id).FirstOrDefaultAsync();
                    if (ord != null)
                    {
                        if (ord.IsSuccess)
                        {
                            return new DO_ReturnParameter { Status = true };
                        }
                        ord.IsSuccess = true;
                        ord.PaymentId = obj.id;
                        ord.ModifiedOn = System.DateTime.Now;

                        await db.SaveChangesAsync();

                        await InsertPaymentGatewayLog(obj);

                        try
                        {
                            obj.BookingKey = ord.BookingKey;
                            var voucherAmount = ord.TransactionAmount;
                            //var financialYear = System.DateTime.Now.Year;
                            var financialYear = Convert.ToInt32(db.GtEcclco.Where(w => w.BusinessKey == obj.BusinessKey
                                           && DateTime.Now.Date >= w.FromDate.Date
                                           && DateTime.Now.Date <= w.TillDate.Date)
                               .First().FinancialYear);

                            int DocID_Receipt = DocumentIdValues.guest_ReceiptId;
                            var dc_pr = db.GtEcdcbn
                                            .Where(w => w.BusinessKey == obj.BusinessKey && w.FinancialYear == financialYear
                                                && w.DocumentId == DocID_Receipt).FirstOrDefault();
                            dc_pr.CurrentDocNumber++;
                            var voucherKey = decimal.Parse(financialYear.ToString().Substring(2, 2) + obj.BusinessKey.ToString() + dc_pr.CurrentDocNumber);

                            GtEfprdt obj_PR = new GtEfprdt
                            {
                                BusinessKey = obj.BusinessKey,
                                FinancialYear = financialYear,
                                BookTypeId = DocID_Receipt,
                                VoucherNumber = dc_pr.CurrentDocNumber,
                                VoucherKey = voucherKey,
                                VoucherType = "R",
                                VoucherDate = System.DateTime.Now,
                                VoucherAmount = voucherAmount,
                                CollectedAmount = voucherAmount,
                                RefundAmount = 0,
                                CancelledAmount = 0,
                                Narration = "",
                                BillDocumentKey = obj.BookingKey,
                                ActiveStatus = true,
                                FormId = "0",
                                CreatedBy = 1,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = System.Environment.MachineName,
                            };
                            db.GtEfprdt.Add(obj_PR);

                            GtEfprpm gt_PM = new GtEfprpm
                            {
                                BusinessKey = obj_PR.BusinessKey,
                                VoucherKey = obj_PR.VoucherKey,
                                PaymentMode = ApplicationCodesValues.PaymentGatewayCode,
                                ReferenceNumber = obj.id,
                                ActiveStatus = true,
                                CreatedBy = 0,
                                CreatedOn = DateTime.Now,
                                CreatedTerminal = System.Environment.MachineName
                            };
                            db.GtEfprpm.Add(gt_PM);

                            var ah = await db.GtGptbkh.Where(w => w.BookingKey == obj.BookingKey).FirstOrDefaultAsync();
                            if (ah != null)
                            {
                                ah.PaymentReceived = true;
                                if (ah.BookingStatus == "PY")
                                    ah.BookingStatus = "BK";
                                ah.ActiveStatus = true;
                            }

                            await db.SaveChangesAsync();
                            dbContext.Commit();

                            return new DO_ReturnParameter { Status = true };

                        }
                        catch (DbUpdateException ex)
                        {
                            dbContext.Rollback();
                            throw;
                        }
                        catch (Exception ex)
                        {
                            dbContext.Rollback();
                            throw;
                        }

                    }
                    else
                    {
                        return new DO_ReturnParameter { Status = false, ErrorCode = "PC", Message = "Payment already captured" };
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertPaymentGatewayLog(DO_GuestOnlinePaymentResponse obj)
        {
            using (var db = new eSyaEnterprise())
            {

                try
                {
                    var slNo = db.GtGptbpl.Where(w => w.BookingKey == obj.BookingKey).Select(s => s.SerialNo).DefaultIfEmpty(0).Max() + 1;
                    GtGptbpl gt_Pl = new GtGptbpl
                    {
                        BookingKey = obj.BookingKey,
                        SerialNo = slNo,
                        RequestType = "PY",
                        RequestData = null,
                        ResponseData = obj.ResponseData,
                        CreatedOn = DateTime.Now,
                    };
                    db.GtGptbpl.Add(gt_Pl);

                    await db.SaveChangesAsync();
                    return new DO_ReturnParameter { Status = true };

                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        //public async Task<List<DO_GuestRefundRequestApprovals>> GetRefundRequestApprovals(int businesskey)
        //{
        //    using (var db = new eSyaEnterprise())
        //    {
        //        var gp = await db.GtEfprdt
        //            .Join(db.GtEfprpm,
        //                p => new { p.BusinessKey, p.VoucherKey },
        //                m => new { m.BusinessKey, m.VoucherKey },
        //                (p, m) => new { p, m })
        //                .Join(db.GtGptbkh,
        //                 ph => new { ph.p.BusinessKey, ph.p.VoucherKey },
        //                 h => new { h.BusinessKey, VoucherKey = h.BookingKey },
        //                 (ph, h) => new { ph, h })
        //                .Join(db.GtGptbkp,
        //                php => new { php.ph.p.BusinessKey, php.ph.p.VoucherKey },
        //                kp => new { kp.BusinessKey, VoucherKey = kp.BookingKey },
        //                (php, kp) => new { php, kp })
        //              .Join(db.GtGptbkg,
        //                phpg => new { phpg.php.ph.p.BusinessKey, phpg.php.ph.p.VoucherKey },
        //                g => new { g.BusinessKey, VoucherKey = g.BookingKey },
        //                (phpg, g) => new { phpg, g })
        //            .Where(w => w.phpg.php.ph.p.BusinessKey == businesskey &&  w.phpg.php.ph.p.VoucherType == "J" && w.phpg.php.ph.p.IsApproved == false)
        //            .Select(r => new DO_GuestRefundRequestApprovals
        //            {
        //                VoucherType = r.phpg.php.ph.p.VoucherType,
        //                VoucherTypeDesc = r.phpg.php.ph.p.VoucherType == "R" ? "Receipt" : (r.phpg.php.ph.p.VoucherType == "P" ? "Payment" : "Request Refund"),
        //                PaymentModeDesc = db.GtEcapcd.Where(k => k.ApplicationCode == r.phpg.php.ph.m.PaymentMode).FirstOrDefault().CodeDesc,
        //                VoucherKey = r.phpg.php.ph.p.VoucherKey,
        //                VoucherDate = r.phpg.php.ph.p.VoucherDate,
        //                VoucherAmount = r.phpg.php.ph.p.VoucherAmount,
        //                RefundReason= r.phpg.php.ph.p.RefundReason,
        //                //for display 
        //                BookingKey = r.phpg.php.h.BookingKey,
        //                PackageId = r.phpg.php.h.PackageId,
        //                PackageDesc = db.GtGppkms.Where(w => w.PackageId == r.phpg.php.h.PackageId).FirstOrDefault().PackageDesc,
        //                TotalPackageAmount = r.phpg.php.h.TotalPackageAmount,
        //                TotalDiscountAmount = r.phpg.php.h.TotalDiscountAmount,
        //                NetPackageAmount = r.phpg.php.h.NetPackageAmount,
        //                CheckedInDate = r.phpg.php.h.CheckInDate,
        //                CheckedOutDate = r.phpg.php.h.CheckOutDate,
        //                RoomTypeName = db.GtGprmty.Where(w => w.RoomTypeId == r.phpg.kp.RoomTypeId).FirstOrDefault().RoomTypeDesc,
        //                RoomNumber = r.phpg.kp.RoomNumber,
        //                BedNumber = r.phpg.kp.BedNumber,
        //                OccupancyType = r.phpg.kp.OccupancyType,
        //                PackagePrice = r.phpg.kp.PackagePrice,
        //                GuestId = r.phpg.kp.GuestId,
        //                FirstName = r.g.FirstName,
        //                LastName = r.g.LastName,
        //                Gender = r.g.Gender,
        //                AgeYy = r.g.AgeYy,
        //                MobileNumber = r.g.MobileNumber,
        //                EmailId = r.g.EmailId,
        //                Place = r.g.Place,
        //                UHID = r.g.Uhid,
        //                Address = r.g.Address,
        //                AreaCode = r.g.AreaCode,
        //                CityCode = r.g.CityCode,
        //                StateCode = r.g.StateCode,
        //                Pincode = r.g.Pincode,
        //                IsCheckedIn = r.g.IsCheckedIn,
        //                IsCheckedOut = r.g.IsCheckedOut,

        //            }).ToListAsync();
        //        return  gp.GroupBy(x => x.VoucherKey).Select(g => g.FirstOrDefault()).ToList();
               
        //    }
        //}

        public async Task<List<DO_GuestRefundRequestApprovals>> GetRefundRequestApprovals(int businesskey)
        {
            using (var db = new eSyaEnterprise())
            {
                var gp = await db.GtEfprdt
                    .Join(db.GtEfprpm,
                        p => new { p.BusinessKey, p.VoucherKey },
                        m => new { m.BusinessKey, m.VoucherKey },
                        (p, m) => new { p, m })
                        .Join(db.GtGptbkh,
                         ph => new { ph.p.BusinessKey, ph.p.VoucherKey },
                         h => new { h.BusinessKey, VoucherKey = h.BookingKey },
                         (ph, h) => new { ph, h })
                        .Join(db.GtGptbkp,
                        php => new { php.ph.p.BusinessKey, php.ph.p.BillDocumentKey },
                        kp => new { kp.BusinessKey, BillDocumentKey = kp.BookingKey },
                        (php, kp) => new { php, kp })
                      .Join(db.GtGptbkg,
                        phpg => new { phpg.php.ph.p.BusinessKey, phpg.php.ph.p.BillDocumentKey },
                        g => new { g.BusinessKey, BillDocumentKey = g.BookingKey },
                        (phpg, g) => new { phpg, g })
                    .Where(w => w.phpg.php.ph.p.BusinessKey == businesskey && w.phpg.php.ph.p.VoucherType == "J" && w.phpg.php.ph.p.IsApproved == false)
                    .Select(r => new DO_GuestRefundRequestApprovals
                    {
                        VoucherType = r.phpg.php.ph.p.VoucherType,
                        VoucherTypeDesc = r.phpg.php.ph.p.VoucherType == "R" ? "Receipt" : (r.phpg.php.ph.p.VoucherType == "P" ? "Payment" : "Request Refund"),
                        PaymentModeDesc = db.GtEcapcd.Where(k => k.ApplicationCode == r.phpg.php.ph.m.PaymentMode).FirstOrDefault().CodeDesc,
                        VoucherKey = r.phpg.php.ph.p.VoucherKey,
                        VoucherDate = r.phpg.php.ph.p.VoucherDate,
                        VoucherAmount = r.phpg.php.ph.p.VoucherAmount,
                        RefundReason = r.phpg.php.ph.p.RefundReason,
                        //for display 
                        BookingKey = r.phpg.php.h.BookingKey,
                        PackageId = r.phpg.php.h.PackageId,
                        PackageDesc = db.GtGppkms.Where(w => w.PackageId == r.phpg.php.h.PackageId).FirstOrDefault().PackageDesc,
                        TotalPackageAmount = r.phpg.php.h.TotalPackageAmount,
                        TotalDiscountAmount = r.phpg.php.h.TotalDiscountAmount,
                        NetPackageAmount = r.phpg.php.h.NetPackageAmount,
                        CheckedInDate = r.phpg.php.h.CheckInDate,
                        CheckedOutDate = r.phpg.php.h.CheckOutDate,
                        RoomTypeName = db.GtGprmty.Where(w => w.RoomTypeId == r.phpg.kp.RoomTypeId).FirstOrDefault().RoomTypeDesc,
                        RoomNumber = r.phpg.kp.RoomNumber,
                        BedNumber = r.phpg.kp.BedNumber,
                        OccupancyType = r.phpg.kp.OccupancyType,
                        PackagePrice = r.phpg.kp.PackagePrice,
                        GuestId = r.phpg.kp.GuestId,
                        FirstName = r.g.FirstName,
                        LastName = r.g.LastName,
                        Gender = r.g.Gender,
                        AgeYy = r.g.AgeYy,
                        MobileNumber = r.g.MobileNumber,
                        EmailId = r.g.EmailId,
                        Place = r.g.Place,
                        UHID = r.g.Uhid,
                        Address = r.g.Address,
                        AreaCode = r.g.AreaCode,
                        CityCode = r.g.CityCode,
                        StateCode = r.g.StateCode,
                        Pincode = r.g.Pincode,
                        IsCheckedIn = r.g.IsCheckedIn,
                        IsCheckedOut = r.g.IsCheckedOut,

                    }).ToListAsync();
                return gp.GroupBy(x => x.VoucherKey).Select(g => g.FirstOrDefault()).ToList();

            }
        }
    }
}
