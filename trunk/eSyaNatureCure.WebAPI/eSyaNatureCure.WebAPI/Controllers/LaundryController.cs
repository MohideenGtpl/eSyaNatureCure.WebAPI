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
    public class LaundryController : ControllerBase
    {
        private readonly ILaundryRepository _laundryRepository;

        public LaundryController(ILaundryRepository laundryRepository)
        {
            _laundryRepository = laundryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCheckInGuestDetailsByBookingKey(int businessKey)
        {
            var gd = await _laundryRepository.GetCheckInGuestDetailsByBookingKey(businessKey);
            return Ok(gd);
        }

        [HttpGet]
        public async Task<IActionResult> GetLaundryServiceList(int businessKey, string gender)
        {
            var gd = await _laundryRepository.GetLaundryServiceList(businessKey, gender, "U");
            return Ok(gd);
        }

        [HttpGet]
        public async Task<IActionResult> GetLaundryServiceRates(int businessKey, int serviceId)
        {
            var gd = await _laundryRepository.GetLaundryServiceRates(businessKey, serviceId, 620004, "INR");
            ////var gd = await _laundryRepository.GetLaundryServiceRates(businessKey, serviceId, 1, "INR");
            return Ok(gd);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuestLaundryServiceByBookingKey(int businessKey, long bookingKey)
        {
            var gd = await _laundryRepository.GetGuestLaundryServiceByBookingKey(businessKey, bookingKey);
            return Ok(gd);
        }
        [HttpPost]
        public async Task<IActionResult> InsertGuestLaundryService(DO_Service obj)
        {
            var msg = await _laundryRepository.InsertGuestLaundryService(obj);
            return Ok(msg);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuestLaundryService(DO_Service obj)
        {
            var msg = await _laundryRepository.UpdateGuestLaundryService(obj);
            return Ok(msg);

        }
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveGuestLaundryService(bool status, int businessKey, long bookingKey, int SerialNumber)
        {
            var msg = await _laundryRepository.ActiveOrDeActiveGuestLaundryService(status, businessKey, bookingKey, SerialNumber);
            return Ok(msg);

        }
    }
}