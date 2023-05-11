using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace eSyaNatureCure.IF
{
   public interface IRoomReservationRepository
    {
        Task<List<DO_RoomReservation>> GetRoomReservationsbyBusinesskey(int businesskey, int roomtypeId, string roomNumber);

        Task<DO_ReturnParameter> InsertIntoRoomReservation(DO_RoomReservation obj);

        Task<DO_ReturnParameter> UpdateRoomReservation(DO_RoomReservation obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveRoomReservation(DO_RoomReservation obj);

        Task<List<DO_BedMaster>> GetActiveRoomNumbersbyRoomType(int roomtype);

        Task<List<DO_BedMaster>> GetActiveBedNumbersbyRoomNumber(int roomtype, string roomnumber);

        Task<List<DO_BedMaster>> GetActiveRoomNumbers();
    }
}
