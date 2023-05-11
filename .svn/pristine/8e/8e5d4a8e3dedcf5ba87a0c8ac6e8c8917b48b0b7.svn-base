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
   public class MemberShipCardRepository: IMemberShipCardRepository
    {
        #region MemberShip Card
        public async Task<List<DO_MemberShipCard>> GetMembershipCard()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtGptrmc
                        .Join(db.GtEcapcd, lkey => new { lkey.MembershipType },
                           ent => new { MembershipType = ent.ApplicationCode },
                           (lkey, ent) => new { lkey, ent }).Join(db.GtGprmty,
                           Bloc => new { Bloc.lkey.RoomType },
                           seg => new { RoomType = seg.RoomTypeId },
                           (Bloc, seg) => new { Bloc, seg })
                           .Select(c => new DO_MemberShipCard
                           {
                               MembershipType = c.Bloc.lkey.MembershipType,
                               DonationRangeFrom = c.Bloc.lkey.DonationRangeFrom,
                               DonationRangeTo = c.Bloc.lkey.DonationRangeTo,
                               BookingDiscountPercentage = c.Bloc.lkey.BookingDiscountPercentage,
                               RoomType = c.Bloc.lkey.RoomType,
                               NoOfPersons = c.Bloc.lkey.NoOfPersons,
                               ActiveStatus = c.Bloc.lkey.ActiveStatus,
                               MembershipTypeDesc = c.Bloc.ent.CodeDesc,
                               RoomTypeDesc = c.seg.RoomTypeDesc
                           }).ToListAsync();
                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateMembershipCard(DO_MemberShipCard obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _mcard = await db.GtGptrmc.Where(x => x.MembershipType == obj.MembershipType ).FirstOrDefaultAsync();
                        if (_mcard == null)
                        {

                            GtGptrmc mcard = new GtGptrmc
                            {
                                MembershipType = obj.MembershipType,
                                DonationRangeFrom = obj.DonationRangeFrom,
                                DonationRangeTo = obj.DonationRangeTo,
                                BookingDiscountPercentage = obj.BookingDiscountPercentage,
                                RoomType = obj.RoomType,
                                NoOfPersons = obj.NoOfPersons,
                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtGptrmc.Add(mcard);
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Card Created Successfully" };
                        }
                        else
                        {
                            _mcard.DonationRangeFrom = obj.DonationRangeFrom;
                            _mcard.DonationRangeTo = obj.DonationRangeTo;
                            _mcard.BookingDiscountPercentage = obj.BookingDiscountPercentage;
                            _mcard.RoomType = obj.RoomType;
                            _mcard.NoOfPersons = obj.NoOfPersons;
                            _mcard.ActiveStatus = obj.ActiveStatus;
                            _mcard.ModifiedBy = obj.UserID;
                            _mcard.ModifiedOn = DateTime.Now;
                            _mcard.ModifiedTerminal = obj.TerminalID;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Card Updated Successfully" };
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

        public async Task<DO_ReturnParameter> ActiveOrDeActiveMembershipCard(bool status, int membershiptype)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mcard = await db.GtGptrmc.Where(x => x.MembershipType == membershiptype ).FirstOrDefaultAsync();
                        if (mcard == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "MemberShip Card is not exist" };
                        }
                        if (mcard != null)
                        {
                            mcard.ActiveStatus = status;
                            await db.SaveChangesAsync();
                            dbContext.Commit();
                        }
                        if (status == true)
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Card Activated Successfully." };
                        else
                            return new DO_ReturnParameter() { Status = true, Message = "MemberShip Card De Activated Successfully." };
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
