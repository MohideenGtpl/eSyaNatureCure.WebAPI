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
    public class PolicyTypeController : ControllerBase
    {
        private readonly IPolicyTypeRepository _policyTypeRepository;

        public PolicyTypeController(IPolicyTypeRepository policyTypeRepository)
        {
            _policyTypeRepository = policyTypeRepository;

        }
        #region Policy Type
        /// <summary>
        /// Getting  All Policy Types from Application Codes for drop down.
        /// UI Reffered - Policy Type
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPolicyTyesbyCodeType(int codetype)
        {
            var p_types = await _policyTypeRepository.GetPolicyTyesbyCodeType(codetype);
            return Ok(p_types);
        }

        /// <summary>
        /// Getting Policy Type by Policy TypeId for Grid.
        /// UI Reffered - Policy Type
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPolicyTypebyId(int policytypeId)
        {
            var polices = await _policyTypeRepository.GetAllPolicyTypebyId(policytypeId);
            return Ok(polices);
        }

        /// <summary>
        /// Insert  Policy Type.
        /// UI Reffered -Policy Type
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertPolicyType(DO_PolicyType obj)
        {
            var msg = await _policyTypeRepository.InsertPolicyType(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  Policy Type.
        /// UI Reffered -Policy Type
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdatePolicyType(DO_PolicyType obj)
        {
            var msg = await _policyTypeRepository.UpdatePolicyType(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Policy Type.
        /// UI Reffered -Policy Type
        /// Params status-policy TypeId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActivePolicyType(bool status, int policytypeId, int serialNo)
        {
            var msg = await _policyTypeRepository.ActiveOrDeActivePolicyType(status, policytypeId,serialNo);
            return Ok(msg);

        }
        #endregion Policy Type
    }
}