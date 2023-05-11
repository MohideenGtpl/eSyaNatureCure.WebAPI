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
    public class GuestPaymentController : ControllerBase
    {
        private readonly IGuestPaymentRepository _guestPaymentRepository;

        public GuestPaymentController(IGuestPaymentRepository guestPaymentRepository)
        {
            _guestPaymentRepository = guestPaymentRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetGuestPaymentReceiptDetails(int businessKey, long bookingKey)
        {
            var gd = await _guestPaymentRepository.GetGuestPaymentReceiptDetails(businessKey, bookingKey);
            return Ok(gd);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPatientReceipt(DO_GuestPaymentReceiptDetails obj)
        {
            var gd = await _guestPaymentRepository.InsertPatientReceipt(obj);
            return Ok(gd);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRefundRequestApproval(DO_GuestPaymentReceiptDetails obj)
        {
            var gd = await _guestPaymentRepository.UpdateRefundRequestApproval(obj);
            return Ok(gd);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentOrderResponseByBookingKey(int businessKey, long bookingKey)
        {
            var gd = await _guestPaymentRepository.GetPaymentOrderResponseByBookingKey(businessKey, bookingKey);
            return Ok(gd);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOnlinePaymentAndMakePaymentReceipt(DO_GuestOnlinePaymentResponse obj)
        {
            var gd = await _guestPaymentRepository.CheckOnlinePaymentAndMakePaymentReceipt(obj);
            return Ok(gd);
        }
        #region Refund Request Approvals
        [HttpGet]
        public async Task<IActionResult> GetRefundRequestApprovals(int businesskey)
        {
            var gpayments = await _guestPaymentRepository.GetRefundRequestApprovals(businesskey);
            return Ok(gpayments);
        }
        #endregion
    }
}