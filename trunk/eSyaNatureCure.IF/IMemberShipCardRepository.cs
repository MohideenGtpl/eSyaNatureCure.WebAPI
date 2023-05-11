using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IMemberShipCardRepository
    {
        Task<List<DO_MemberShipCard>> GetMembershipCard();

        Task<DO_ReturnParameter> InsertOrUpdateMembershipCard(DO_MemberShipCard obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveMembershipCard(bool status, int membershiptype);
    }
}
