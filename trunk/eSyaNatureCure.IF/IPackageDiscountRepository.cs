using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IPackageDiscountRepository
    {
        #region Package discount

        Task<List<DO_PackageDiscount>> GetAllPackageDiscountbyPackageId(int packageId, int roomtypeId, string occupancyType);

        Task<DO_ReturnParameter> InsertPackageDiscount(DO_PackageDiscount obj);

        Task<DO_ReturnParameter> UpdatePackageDiscount(DO_PackageDiscount obj);

        Task<DO_ReturnParameter> ActiveOrDeActivePackageDiscount(DO_PackageDiscount obj);

        #endregion Package 
    }
}
