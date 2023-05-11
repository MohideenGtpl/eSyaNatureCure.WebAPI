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
    public class DaywiseActivitiesController : ControllerBase
    {
        private readonly IDaywiseActivitiesRepository _daywiseActivitiesRepository;

        public DaywiseActivitiesController(IDaywiseActivitiesRepository daywiseActivitiesRepository)
        {
            _daywiseActivitiesRepository = daywiseActivitiesRepository;

        }

        #region Day wise Activities
        /// <summary>
        /// Getting  Day wise Activities by Package Id.
        /// UI Reffered - Day wise Activities
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllDaywiseActivitiesbyPackageId(int packageId)
        {
            var dayactivities = await _daywiseActivitiesRepository.GetAllDaywiseActivitiesbyPackageId(packageId);
            return Ok(dayactivities);
        }


        /// <summary>
        /// Insert  Day wise Activities.
        /// UI Reffered -Day wise Activities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertDaywiseActivities(DO_DaywiseActivities obj)
        {
            var msg = await _daywiseActivitiesRepository.InsertDaywiseActivities(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  Day wise Activities.
        /// UI Reffered -Day wise Activities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDaywiseActivities(DO_DaywiseActivities obj)
        {
            var msg = await _daywiseActivitiesRepository.UpdateDaywiseActivities(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Day wise Activities.
        /// UI Reffered -Day wise Activities
        /// Params status-
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActiveDayWiseActivities(DO_DaywiseActivities obj)
        {
            var msg = await _daywiseActivitiesRepository.ActiveOrDeActiveDayWiseActivities(obj);
            return Ok(msg);

        }
        #endregion Day wise Activities
    }
}