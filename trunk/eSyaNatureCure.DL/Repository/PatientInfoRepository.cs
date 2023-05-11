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
    public class PatientInfoRepository : IPatientInfoRepository
    {
        public async Task<List<DO_PatientProfile>> GetSearchPatient(string searchText)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtEfoppr
               .Where(w => ((w.FirstName + ' ' + w.LastName).ToUpper().Contains(searchText.ToUpper())
                    || w.MobileNumber.Equals(searchText))
                    && w.ActiveStatus)
               .Select(s => new DO_PatientProfile
               {
                   UHID = s.RUhid,
                   ISDCode = s.Isdcode,
                   MobileNumber = s.MobileNumber,
                   FirstName = s.FirstName,
                   MiddleName = s.MiddleName,
                   LastName = s.LastName,
                   IsDOBApplicable = s.IsDobapplicable,
                   DateOfBirth = s.DateOfBirth,
                   Gender = s.Gender,
                   eMailID = s.EMailId
               })
               .ToListAsync();
                return await pf;
            }
        }

        public async Task<List<DO_PatientProfile>> GetPatientInfoRegistrationByMobileNo(string mobileNumber)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtEfoppr
               .Where(w => w.MobileNumber == mobileNumber
                    && w.ActiveStatus)
               .Select(s => new DO_PatientProfile
               {
                   UHID = s.RUhid,
                   ISDCode = s.Isdcode,
                   MobileNumber = s.MobileNumber,
                   FirstName = s.FirstName,
                   MiddleName = s.MiddleName,
                   LastName = s.LastName,
                   IsDOBApplicable = s.IsDobapplicable,
                   DateOfBirth = s.DateOfBirth,
                   Gender = s.Gender,
                   eMailID = s.EMailId
               })
               .ToListAsync();

                return await pf;
            }
        }

        public async Task<DO_PatientProfile> GetPatientProfileByUHID(long uhid)
        {
            using (var db = new eSyaEnterprise())
            {
                var pf = db.GtEfoppr
               .Where(w => w.RUhid == uhid
                    && w.ActiveStatus)
               .Select(s => new DO_PatientProfile
               {
                   UHID = s.RUhid,
                   ISDCode = s.Isdcode,
                   MobileNumber = s.MobileNumber,
                   FirstName = s.FirstName,
                   MiddleName = s.MiddleName,
                   LastName = s.LastName,
                   Gender = s.Gender,
                   IsDOBApplicable = s.IsDobapplicable,
                   DateOfBirth = s.DateOfBirth,
                   AgeYY = s.AgeYy,
                   AgeMM = s.AgeMm,
                   AgeDD = s.AgeDd,
                   eMailID = s.EMailId,
                   Nationality = s.Nationality,
                   BloodGroup = s.BloodGroup,
                   CurrentPatientAddress = s.GtEfopa1.Where(w => w.RUhid == uhid).Select(a => new DO_PatientAddress
                   {
                       AddressId = a.AddressId,
                       Address = a.Address,
                       AreaCode = a.AreaCode,
                       CityCode = a.CityCode,
                       StateCode = a.StateCode,
                       Pincode = a.Pincode
                   }).OrderByDescending(o => o.AddressId).FirstOrDefault()
               })
               .FirstOrDefaultAsync();

                return await pf;
            }
        }
    }
}
