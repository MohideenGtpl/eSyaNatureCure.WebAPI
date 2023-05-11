using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IActivitiesRepository
    {
        Task<List<DO_Activities>> GetAllActivities();

        Task<List<DO_Activities>> GetActiveActivities();

        Task<DO_ReturnParameter> InsertActivities(DO_Activities obj);

        Task<DO_ReturnParameter> UpdateActivities(DO_Activities obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveActivities(bool status, int activityId);
    }
}
