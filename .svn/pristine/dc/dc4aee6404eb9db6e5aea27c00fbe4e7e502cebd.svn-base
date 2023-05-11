using System;
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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;

        }
        #region Room Type
        /// <summary>
        /// Getting  All Room Types.
        /// UI Reffered - Room Type
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var room_types =await _roomTypeRepository.GetAllRoomTypes();
            return Ok(room_types);
        }

       
        /// <summary>
        /// Getting Active Room Types for dropdown.
        /// UI Reffered - Bed Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveRoomTypes()
        {
            var room_types = await _roomTypeRepository.GetActiveRoomTypes();
            return Ok(room_types);
        }

        /// <summary>
        /// Insert  RoomType.
        /// UI Reffered -RoomType
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertRoomType(DO_RoomType obj)
        {
            var msg = await _roomTypeRepository.InsertRoomType(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  RoomType.
        /// UI Reffered -RoomType
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateRoomType(DO_RoomType obj)
        {
            var msg = await _roomTypeRepository.UpdateRoomType(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active RoomType.
        /// UI Reffered -RoomType
        /// Params status-roomTypeId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveRoomType(bool status, int roomTypeId)
        {
            var msg = await _roomTypeRepository.ActiveOrDeActiveRoomType(status, roomTypeId);
            return Ok(msg);

        }
        #endregion Room Type
    }
}