using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eSyaNatureCure.DO;
namespace eSyaNatureCure.IF
{
   public interface IDepartmentRepository
    {
        #region Department

        Task<List<DO_Department>> GetAllDepartments();

        Task<DO_ReturnParameter> InsertIntoDepartment(DO_Department obj);

        Task<DO_ReturnParameter> UpdateDepartment(DO_Department obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveDepartment(bool status, int deptId);

        #endregion Department

        #region User Department Link

        Task<List<DO_Department>> GetActiveDepartments();

        Task<List<DO_User>> GetActiveUsers();

        Task<List<DO_DepartmentUserLink>> GetAllUsersbyDepartmentLink(int deptId);

        Task<DO_ReturnParameter> InsertOrUpdateUserDepartmentLink(DO_DepartmentUserLink obj);

        #endregion
    }
}
