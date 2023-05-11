﻿using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IPackagePriceRepository
    {
        Task<List<DO_PackagePrice>> GetAllPackagePricesbyPackageId(int packageId);

        Task<DO_ReturnParameter> InsertPackagePrice(DO_PackagePrice obj);

        Task<DO_ReturnParameter> UpdatePackagePrice(DO_PackagePrice obj);

        Task<DO_ReturnParameter> ActiveOrDeActivePackagePrice(DO_PackagePrice obj);

        Task<List<DO_PackagePrice>> GetActiveOccupancyTpe();
    }
}
