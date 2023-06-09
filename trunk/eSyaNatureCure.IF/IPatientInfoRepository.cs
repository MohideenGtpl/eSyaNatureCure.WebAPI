﻿using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IPatientInfoRepository
    {
        Task<List<DO_PatientProfile>> GetSearchPatient(string searchText);

        Task<List<DO_PatientProfile>> GetPatientInfoRegistrationByMobileNo(string mobileNumber);

        Task<DO_PatientProfile> GetPatientProfileByUHID(long uhid);
    }
}
