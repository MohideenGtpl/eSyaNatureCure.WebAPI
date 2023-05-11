using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IPackageAmenitiesRepository
    {
        Task<List<DO_PackageAmenities>> GetAllPackageAmenitiesbyPackageId(int pacakgeId);

        Task<DO_ReturnParameter> InsertPackageAmenities(DO_PackageAmenities obj);

        Task<DO_ReturnParameter> UpdatePackageAmenities(DO_PackageAmenities obj);

        Task<DO_ReturnParameter> ActiveOrDeActivePackageAmenities(DO_PackageAmenities obj);

        Task<DO_PackageAmenities> GetPackageAmenitiesbyOptiontype(int packageId, string optionType, int serilalNo);
    }
}
