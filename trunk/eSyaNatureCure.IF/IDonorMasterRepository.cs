﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eSyaNatureCure.DO;
namespace eSyaNatureCure.IF
{
    public interface IDonorMasterRepository
    {
        #region Donor Rules
        Task<List<DO_DonorRules>> GetAllDonorRules();

        Task<List<DO_DonorRules>> GetActiveDonorRules();

        Task<DO_ReturnParameter> InsertIntoDonorRule(DO_DonorRules obj);

        Task<DO_ReturnParameter> UpdateDonorRule(DO_DonorRules obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveDonorRule(bool status, int donortype);
        #endregion

        #region Donor Package Link
        Task<List<DO_DonorPackageLink>> GetDonorLinkbyPackage(int packageId);

        Task<DO_ReturnParameter> InsertOrUpdateDonorLinkwithPackage(DO_DonorPackageLink obj);
        #endregion

        #region Donor Rgistration
        Task<List<DO_DonorRegistration>> GetDonorsListbyBusinesskey(int businesskey);

        Task<DO_ReturnParameter> InsertIntoDonorRegistration(DO_DonorRegistration obj);

        Task<DO_ReturnParameter> UpdateIntoDonorRegistration(DO_DonorRegistration obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveDonorRegistration(bool status, int businesskey, int donorId);

        Task<List<DO_DonorRules>> GetRoomTypesbyDonorId(int donortype);

        Task<DO_DonorRules> GetDiscountbyDonorId(int donortype, int roomType);
        #endregion

        #region Address
        Task<List<DO_Place>> GetStateList(int isdCode);

        Task<List<DO_Place>> GetCityList(int isdCode, int? stateCode);

        Task<List<DO_AddressIN>> GetAreaList(int isdCode, int? stateCode, int? cityCode);

        Task<DO_AddressIN> GetAreaDetailsbyPincode(int isdCode, string pincode);
        #endregion
    }
}
