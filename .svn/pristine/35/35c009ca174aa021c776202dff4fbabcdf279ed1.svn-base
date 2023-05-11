using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IDaywiseActivitiesRepository
    {
        Task<List<DO_DaywiseActivities>> GetAllDaywiseActivitiesbyPackageId(int packageId);

        Task<DO_ReturnParameter> InsertDaywiseActivities(DO_DaywiseActivities obj);

        Task<DO_ReturnParameter> UpdateDaywiseActivities(DO_DaywiseActivities obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveDayWiseActivities(DO_DaywiseActivities obj);
    }
}
