﻿using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IFrontOfficeRepository
    {
        Task<DO_FrontOffice> GetTodayDashboard(int businessKey);
        Task<List<DO_BookinDetails>> GetDashboardByDate(int businessKey, DateTime fromDate, DateTime toDate);

        Task<List<DO_BedMaster>> GetActiveRoomBedMaster(DateTime fromDate, DateTime toDate);
    }
}
