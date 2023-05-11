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
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesRepository _activitiesRepository;

        public ActivitiesController(IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;

        }

        #region Activities
        /// <summary>
        /// Getting  All Activities.
        /// UI Reffered - Activities
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _activitiesRepository.GetAllActivities();
            return Ok(activities);
        }

        /// <summary>
        /// Getting Active Activities for dropdown.
        /// UI Reffered - Activities
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveActivities()
        {
            var activities = await _activitiesRepository.GetActiveActivities();
            return Ok(activities);
        }

        /// <summary>
        /// Insert  Activities.
        /// UI Reffered -Activities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertActivities(DO_Activities obj)
        {
            var msg = await _activitiesRepository.InsertActivities(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  Activities.
        /// UI Reffered -Activities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateActivities(DO_Activities obj)
        {
            var msg = await _activitiesRepository.UpdateActivities(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Activities.
        /// UI Reffered -Activities
        /// Params status-activityId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveActivities(bool status, int activityId)
        {
            var msg = await _activitiesRepository.ActiveOrDeActiveActivities(status, activityId);
            return Ok(msg);

        }
        #endregion Activities
    }
}