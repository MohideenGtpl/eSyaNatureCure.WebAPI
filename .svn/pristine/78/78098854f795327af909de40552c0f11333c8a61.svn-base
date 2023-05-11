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
    public class CommonMasterController : ControllerBase
    {
        private readonly ICommonMasterRepository _commonMasterRepository;

        public CommonMasterController(ICommonMasterRepository commonMasterRepository)
        {
            _commonMasterRepository = commonMasterRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codeType)
        {
            var activities = await _commonMasterRepository.GetApplicationCodesByCodeType(codeType);
            return Ok(activities);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryPlaceList(int isdCode, int placeType)
        {
            var activities = await _commonMasterRepository.GetCountryPlaceList(isdCode, placeType);
            return Ok(activities);
        }


        [HttpGet]
        public async Task<IActionResult> GetCountryAreaList(int isdCode, int? stateCode, int? cityCode)
        {
            var activities = await _commonMasterRepository.GetCountryAreaList(isdCode, stateCode, cityCode);
            return Ok(activities);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryAreaDetailsByPincode(int isdCode, string pincode)
        {
            var activities = await _commonMasterRepository.GetCountryAreaDetailsByPincode(isdCode, pincode);
            return Ok(activities);
        }
        [HttpPost]
        public async Task<IActionResult> GetApplicationCodesByCodeTypeList(List<int> l_codeType)
        {
            var appcodes = await _commonMasterRepository.GetApplicationCodesByCodeTypeList(l_codeType);
            return Ok(appcodes);
        }
    }
}