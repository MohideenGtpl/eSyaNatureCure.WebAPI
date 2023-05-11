using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IPolicyTypeRepository
    {
        #region Policy Type
        Task<List<DO_ApplicationCodes>> GetPolicyTyesbyCodeType(int codetype);

        Task<List<DO_PolicyType>> GetAllPolicyTypebyId(int policytypeId);

        Task<DO_ReturnParameter> InsertPolicyType(DO_PolicyType obj);

        Task<DO_ReturnParameter> UpdatePolicyType(DO_PolicyType obj);

        Task<DO_ReturnParameter> ActiveOrDeActivePolicyType(bool status, int policytypeId, int serialNo);
        #endregion Policy Type
    }
}
