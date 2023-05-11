﻿using eSyaNatureCure.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNatureCure.IF
{
   public interface IRoomAmenitiesRepository
    {
        Task<List<DO_RoomAmenities>> GetAllRoomAmenitiesbyRoomType(int roomtype);

        Task<DO_ReturnParameter> InsertRoomAmenities(DO_RoomAmenities obj);

        Task<DO_ReturnParameter> UpdateRoomAmenities(DO_RoomAmenities obj);

        Task<DO_ReturnParameter> ActiveOrDeActiveRoomAmenities(DO_RoomAmenities obj);

        Task<DO_RoomAmenities> GetRoomAmenitiesbyroomtype(int roomTypeId, string optionType, int serilalNo);
    }
}
