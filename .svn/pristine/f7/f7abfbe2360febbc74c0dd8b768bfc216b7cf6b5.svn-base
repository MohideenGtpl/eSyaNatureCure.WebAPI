using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
    public interface IRoomTypeRepository
    {
        Task<List<DO_RoomType>> GetAllRoomTypes();

        Task<List<DO_RoomType>> GetActiveRoomTypes();

        Task<DO_ReturnParameter> InsertRoomType(DO_RoomType obj);

        Task<DO_ReturnParameter> UpdateRoomType(DO_RoomType obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveRoomType(bool status, int roomTypeId);
    }
}
