﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNatureCure.DO;
using eSyaNatureCure.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNatureCure.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly IRoomAmenitiesRepository _roomAmenitiesRepository;

        public RoomAmenitiesController(IRoomAmenitiesRepository roomAmenitiesRepository)
        {
            _roomAmenitiesRepository = roomAmenitiesRepository;

        }

        #region Room Amenities
        /// <summary>
        /// Getting  All Room Amenities.
        /// UI Reffered - Room Amenities
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllRoomAmenitiesbyRoomType(int roomType)
        {
            var roomAmenities = await _roomAmenitiesRepository.GetAllRoomAmenitiesbyRoomType(roomType);
            return Ok(roomAmenities);
        }



        /// <summary>
        /// Insert  Room Amenities.
        /// UI Reffered -Room Amenities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertRoomAmenities(DO_RoomAmenities obj)
        {
            var msg = await _roomAmenitiesRepository.InsertRoomAmenities(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  Room Amenities.
        /// UI Reffered -Room Amenities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateRoomAmenitie(DO_RoomAmenities obj)
        {
            var msg = await _roomAmenitiesRepository.UpdateRoomAmenities(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Room Amenities.
        /// UI Reffered -Room Amenities
        /// Params status-
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActiveRoomAmenities(DO_RoomAmenities objamenities)
        {
            var msg = await _roomAmenitiesRepository.ActiveOrDeActiveRoomAmenities(objamenities);
            return Ok(msg);

        }

        [HttpGet]
        public async Task<IActionResult> GetRoomAmenitiesbyroomtype(int roomTypeId, string optionType, int serilalNo)
        {
            var roomAmenities = await _roomAmenitiesRepository.GetRoomAmenitiesbyroomtype(roomTypeId, optionType, serilalNo);
            return Ok(roomAmenities);
        }
        #endregion Room Amenities
    }
}