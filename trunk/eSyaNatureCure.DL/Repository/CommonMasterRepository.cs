﻿using eSyaNatureCure.DL.Entities;
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
    public class CommonMasterRepository:ICommonMasterRepository
    {
        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcd
                        .Where(w => w.CodeType == codeType && w.ActiveStatus)
                        .Select(r => new DO_ApplicationCodes
                        {
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc,
                            ShortCode = r.ShortCode
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_CountryPlaces>> GetCountryPlaceList(int isdCode, int placeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEccnpl
                        .Where(w => w.Isdcode == isdCode && w.PlaceType == placeType && w.ActiveStatus)
                        .Select(r => new DO_CountryPlaces
                        {
                            PlaceId = r.PlaceId,
                            PlaceName = r.PlaceName,
                        }).OrderBy(o => o.PlaceName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_CountryArea>> GetCountryAreaList(int isdCode, int? stateCode, int? cityCode)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtAddrin
                        .Where(w => w.Isdcode == isdCode 
                                && (w.StateCode == stateCode)
                                && (w.CityCode == cityCode)
                                && w.ActiveStatus)
                        .Select(r => new DO_CountryArea
                        {
                            AreaCode = r.AreaCode,
                            AreaName = r.AreaName,
                            StateCode = r.StateCode,
                            CityCode = r.CityCode,
                            Pincode = r.Pincode,
                        }).OrderBy(o => o.AreaName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_CountryArea>> GetCountryAreaDetailsByPincode(int isdCode, string pincode)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtAddrin
                        .Where(w => w.Isdcode == isdCode
                                && w.Pincode == pincode
                                && w.ActiveStatus)
                        .Select(r => new DO_CountryArea
                        {
                            AreaCode = r.AreaCode,
                            AreaName = r.AreaName,
                            StateCode = r.StateCode,
                            CityCode = r.CityCode,
                            Pincode = r.Pincode,
                        }).OrderBy(o => o.AreaName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeTypeList(List<int> l_codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcd
                        .Where(w => w.ActiveStatus
                        && l_codeType.Contains(w.CodeType))
                        .Select(r => new DO_ApplicationCodes
                        {
                            CodeType = r.CodeType,
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
