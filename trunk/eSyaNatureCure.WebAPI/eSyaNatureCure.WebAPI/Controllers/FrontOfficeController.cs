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
    public class FrontOfficeController : ControllerBase
    {
        private readonly IFrontOfficeRepository _frontOfficeRepository;

        public FrontOfficeController(IFrontOfficeRepository frontOfficeRepository)
        {
            _frontOfficeRepository = frontOfficeRepository;

        }

        /// <summary>
        /// Getting Today Dashboard.
        /// UI Reffered - Front Office Today View
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetTodayDashboard(int businessKey)
        {
            var ds = await _frontOfficeRepository.GetTodayDashboard(businessKey);
            return Ok(ds);
        }

        /// <summary>
        /// Getting Dashboard By Date.
        /// UI Reffered - Front Office Schedule View
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDashboardByDate(int businessKey, DateTime fromDate, DateTime toDate)
        {
            var ds = await _frontOfficeRepository.GetDashboardByDate(businessKey,fromDate,toDate);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveRoomBedMaster(DateTime fromDate, DateTime toDate)
        {
            var ds = await _frontOfficeRepository.GetActiveRoomBedMaster(fromDate, toDate);
            return Ok(ds);
        }

    }
}