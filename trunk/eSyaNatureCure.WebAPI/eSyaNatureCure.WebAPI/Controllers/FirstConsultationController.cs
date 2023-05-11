using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNatureCure.DO;
using eSyaNatureCure.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNatureCure.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FirstConsultationController : ControllerBase
    {
        private readonly IFirstConsultationRepository _firstConsultationRepository;

        public FirstConsultationController(IFirstConsultationRepository firstConsultationRepository)
        {
            _firstConsultationRepository = firstConsultationRepository;

        }


        /// <summary>
        /// Getting Today First Consultaion List.
        /// UI Reffered - First Consultaion 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetConsultaionList(int businessKey)
        {
            var ds = await _firstConsultationRepository.GetConsultaionList(businessKey);
            return Ok(ds);
        }



        /// <summary>
        /// Confirm First Consultaion and generate activity list.
        /// UI Reffered - First Consultaion 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ConsultaionConfirmation(DO_GuestCheckInDetails obj)
        {
            var gd = await _firstConsultationRepository.ConsultaionConfirmation(obj);
            return Ok(gd);
        }

        /// <summary>
        /// Get Guest Information.
        /// UI Reffered - First Consultaion 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetGuestDetails(int businessKey, long bookingKey, int guestId)
        {
            var gd = await _firstConsultationRepository.GetGuestDetails(businessKey, bookingKey, guestId);
            return Ok(gd);
        }
       
        /// <summary>
        /// Get Guest Activities.
        /// UI Reffered - First Consultaion 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetGuestActivities(int businessKey, long ipNumber)
        {
            var gd = await _firstConsultationRepository.GetGuestActivities(businessKey,ipNumber);
            return Ok(gd);
        }

        /// <summary>
        /// Add or Update guest activity.
        /// UI Reffered - First Consultaion 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateGuestActivity(DO_GuestActivity obj)
        {
            var gd = await _firstConsultationRepository.AddOrUpdateGuestActivity(obj);
            return Ok(gd);
        }

        /// <summary>
        /// Get Activities.
        /// UI Reffered - First Consultaion 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var gd = await _firstConsultationRepository.GetActivities();
            return Ok(gd);
        }
    }
}