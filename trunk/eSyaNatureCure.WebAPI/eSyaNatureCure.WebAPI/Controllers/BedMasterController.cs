﻿using System.Collections.Generic;
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
    public class BedMasterController : ControllerBase
    {
        private readonly IBedMasterRepository _bedMasterRepository;

        public BedMasterController(IBedMasterRepository bedMasterRepository)
        {
            _bedMasterRepository = bedMasterRepository;
        }
        #region Bed Master
        /// <summary>
        /// Getting   Bed Master by Room Type.
        /// UI Reffered - Bed Master
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllBedMastersbyRoomType(int roomtype)
        {
            var bed_masters = await _bedMasterRepository.GetAllBedMastersbyRoomType( roomtype);
            return Ok(bed_masters);
        }

        /// <summary>
        /// Insert  Bed Master.
        /// UI Reffered -Bed Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertBedmaster(DO_BedMaster obj)
        {
            var msg = await _bedMasterRepository.InsertBedmaster(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Update  Bed Master.
        /// UI Reffered -Bed Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateBedmaster(DO_BedMaster obj)
        {
            var msg = await _bedMasterRepository.UpdateBedmaster(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Bed Master.
        /// UI Reffered -Bed Master
        /// Params status-BedMaster
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActiveBedMaster(DO_BedMaster obj)
        {
            var msg = await _bedMasterRepository.ActiveOrDeActiveBedMaster(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Getting   Room Number for Dropdown.
        /// UI Reffered - GuestBooking
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveRoomNumber()
        {
            var rooms = await _bedMasterRepository.GetActiveRoomNumber();
            return Ok(rooms);
        }

        /// <summary>
        /// Getting   Bed Number for Dropdown.
        /// UI Reffered - GuestBooking
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveBedNumber()
        {
            var beds = await _bedMasterRepository.GetActiveBedNumber();
            return Ok(beds);
        }
        #endregion BedMaster
    }
}
