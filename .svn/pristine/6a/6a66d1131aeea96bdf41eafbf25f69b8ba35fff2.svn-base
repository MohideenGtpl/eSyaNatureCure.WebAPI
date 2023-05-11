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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

        #region Department
        /// <summary>
        /// Getting  All Department.
        /// UI Reffered - Department
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var depts = await _departmentRepository.GetAllDepartments();
            return Ok(depts);
        }

        
        /// <summary>
        /// Insert  Department.
        /// UI Reffered -Department
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoDepartment(DO_Department obj)
        {
            var msg = await _departmentRepository.InsertIntoDepartment(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  Department.
        /// UI Reffered -Department
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(DO_Department obj)
        {
            var msg = await _departmentRepository.UpdateDepartment(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Department.
        /// UI Reffered -Department
        /// Params status-deptId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveDepartment(bool status, int deptId)
        {
            var msg = await _departmentRepository.ActiveOrDeActiveDepartment(status, deptId);
            return Ok(msg);

        }
        #endregion Department

        #region User Department Link
        /// <summary>
        /// Getting Active Department for dropdown.
        /// UI Reffered - Department
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveDepartments()
        {
            var depts = await _departmentRepository.GetActiveDepartments();
            return Ok(depts);
        }

        /// <summary>
        /// Getting  All Active Users.
        /// UI Reffered - Department
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveUsers()
        {
            var users = await _departmentRepository.GetActiveUsers();
            return Ok(users);
        }
        /// <summary>
        /// Getting  Users Linked Departments by Dept Id.
        /// UI Reffered - Department
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersbyDepartmentLink(int deptId)
        {
            var users = await _departmentRepository.GetAllUsersbyDepartmentLink(deptId);
            return Ok(users);
        }
        /// <summary>
        /// Insert  User Department Link.
        /// UI Reffered -Department
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateUserDepartmentLink(DO_DepartmentUserLink obj)
        {
            var msg = await _departmentRepository.InsertOrUpdateUserDepartmentLink(obj);
            return Ok(msg);

        }
        #endregion
    }
}