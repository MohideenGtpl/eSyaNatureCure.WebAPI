using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNatureCure.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNatureCure.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SmsReminderController : ControllerBase
    {
        private readonly ISmsReminderRepository _smsReminderRepository;

        public SmsReminderController(ISmsReminderRepository smsReminderRepository)
        {
            _smsReminderRepository = smsReminderRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetGuestBookingForSendingReminder(string smsId, DateTime remainderDate)
        {
            var rs = await _smsReminderRepository.GetGuestBookingForSendingReminder(smsId, remainderDate);
            return Ok(rs);
        }
    }
}