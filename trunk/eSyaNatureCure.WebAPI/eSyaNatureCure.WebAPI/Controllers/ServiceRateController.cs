﻿using System;
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
    public class ServiceRateController : ControllerBase
    {
        private readonly IServiceRateRepository _serviceRateRepository;

        public ServiceRateController(IServiceRateRepository serviceRateRepository)
        {
            _serviceRateRepository = serviceRateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList(int businessKey)
        {
            var gd = await _serviceRateRepository.GetServiceList(businessKey);
            return Ok(gd);
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceRates(int businessKey, int serviceId)
        {
            var gd = await _serviceRateRepository.GetServiceRates(businessKey, serviceId, 620004, "INR");
            //var gd = await _serviceRateRepository.GetServiceRates(businessKey, serviceId, 1, "INR");
            return Ok(gd);
        }
    }
}