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
    public class DepartmentClearanceController : ControllerBase
    {
        private readonly IDepartmentClearanceRepository _departmentClearanceRepository;

        public DepartmentClearanceController(IDepartmentClearanceRepository departmentClearanceRepository)
        {
            _departmentClearanceRepository = departmentClearanceRepository;

        } 
          /// <summary>
          /// Getting  All Department Clearance Dashboard.
          /// UI Reffered - Department Clearance Dashboard
          /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDepartmentNotClearedGuests(int businessKey)
        {
            var depts = await _departmentClearanceRepository.GetDepartmentNotClearedGuests(businessKey);
            return Ok(depts);
        }


        /// <summary>
        /// Insert  Department Clearance.
        /// UI Reffered -Department Clearance
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDepartmentClearance(DO_DepartmentClearance obj)
        {
            var msg = await _departmentClearanceRepository.InsertIntoDepartmentClearance(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Getting  Department by UserId.
        /// UI Reffered - Department Clearance Dashboard
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDepartmentbyUserId(int UserId)
        {
            var depts = await _departmentClearanceRepository.GetDepartmentbyUserId(UserId);
            return Ok(depts);
        }

        /// <summary>
        /// Getting  All Department Clearance Dashboard.
        /// UI Reffered - Department Clearance Dashboard
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentClearedGuestbyBusinessKey(int businessKey)
        {
            var depts = await _departmentClearanceRepository.GetAllDepartmentClearedGuestbyBusinessKey(businessKey);
            return Ok(depts);
        }

        /// <summary>
        /// Getting  All Department Clearance previous Dashboard.
        /// UI Reffered - Department Clearance Dashboard
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDepartmentClearencePreviousCheckoutdetails(int businesskey)
        {
            var depts = await _departmentClearanceRepository.GetDepartmentClearencePreviousCheckoutdetails(businesskey);
            return Ok(depts);
        }

        /// <summary>
        /// Getting  All Department Clearance current Dashboard.
        /// UI Reffered - Department Clearance Dashboard
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDepartmentClearenceCurrentCheckoutdetails(int businesskey)
        {
            var depts = await _departmentClearanceRepository.GetDepartmentClearenceCurrentCheckoutdetails(businesskey);
            return Ok(depts);
        }
    }
}