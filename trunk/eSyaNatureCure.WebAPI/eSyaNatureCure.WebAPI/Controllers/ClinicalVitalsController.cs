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
    public class ClinicalVitalsController : ControllerBase
    {
        private readonly IClinicalVitalsRepository _clinicalVitalsRepository;

        public ClinicalVitalsController(IClinicalVitalsRepository clinicalVitalsRepository)
        {
            _clinicalVitalsRepository = clinicalVitalsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClinicalInformation(int businessKey, long UHID, long ipNumber, string clType)
        {
            var rs = await _clinicalVitalsRepository.GetClinicalInformation(businessKey,UHID,ipNumber,clType);
            return Ok(rs);
        }

        
        [HttpPost]
        public async Task<IActionResult> InsertIntoClinicalInformation(DO_ClinicalInformation obj)
        {
            var rs = await _clinicalVitalsRepository.InsertIntoClinicalInformation(obj);
            return Ok(rs);
        }

        [HttpGet]
        public async Task<IActionResult> GetInformationValueView(int businessKey, long UHID, long ipNumber, string clType)
        {
            var rs = await _clinicalVitalsRepository.GetInformationValueView(businessKey, UHID, ipNumber, clType);
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPatientClinicalInformation(DO_ClinicalInformation obj)
        {
            var rs = await _clinicalVitalsRepository.InsertPatientClinicalInformation(obj);
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientClinicalInformation(DO_ClinicalInformation obj)
        {
            var rs = await _clinicalVitalsRepository.UpdatePatientClinicalInformation(obj);
            return Ok(rs);
        }

        [HttpGet]
        public async Task<IActionResult> GetClinicalInformationValueByTransaction(int businessKey, long UHID, long ipNumber, int transactionID)
        {
            var rs = await _clinicalVitalsRepository.GetClinicalInformationValueByTransaction(businessKey, UHID, ipNumber, transactionID);
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePatientClinicalInformation(DO_ClinicalInformation obj)
        {
            var rs = await _clinicalVitalsRepository.DeletePatientClinicalInformation(obj);
            return Ok(rs);
        }
    }
}