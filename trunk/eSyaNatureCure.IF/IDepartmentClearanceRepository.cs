using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IDepartmentClearanceRepository
    {
        Task<List<DO_BookinDetails>> GetDepartmentNotClearedGuests(int businessKey);

        Task<DO_ReturnParameter> InsertIntoDepartmentClearance(DO_DepartmentClearance obj);

        Task<DO_DepartmentUserLink> GetDepartmentbyUserId(int UserId);

        Task<List<DO_BookinDetails>> GetAllDepartmentClearedGuestbyBusinessKey(int businessKey);

        Task<List<DO_DepartmentClearenceDetails>> GetDepartmentClearencePreviousCheckoutdetails(int businesskey);

        Task<List<DO_DepartmentClearenceDetails>> GetDepartmentClearenceCurrentCheckoutdetails(int businesskey);
    }
}
