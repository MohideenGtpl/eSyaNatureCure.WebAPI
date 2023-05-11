﻿using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IPackageMasterRepository
    {
        #region  Package Master
        Task<List<DO_PackageMaster>> GetAllPackageMasters();

        Task<List<DO_PackageMaster>> GetActivePackageMasters();

        Task<DO_ReturnParameter> InsertPackageMaster(DO_PackageMaster obj);

        Task<DO_ReturnParameter> UpdatePackageMaster(DO_PackageMaster obj);

        Task<DO_ReturnParameter> ActiveOrDeActivePackageMaster(bool status, int packageId);

        Task<List<Do_WeekDays>> GetCheckInWeekDaysByPackageId(int packageId);
        #endregion Package Master

        #region Blocked Package
        Task<List<DO_BlockedPackage>> GetBlockedPackagesbyBusinessKey(int businesskey);

        Task<DO_ReturnParameter> InserBlockedPackage(DO_BlockedPackage obj);

        Task<DO_ReturnParameter> UpdateBlockedPackage(DO_BlockedPackage obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveBlockedPackage(DO_BlockedPackage obj);
        #endregion
    }
}
