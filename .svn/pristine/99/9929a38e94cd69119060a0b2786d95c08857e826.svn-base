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
    public class GuestCheckInController : ControllerBase
    {
        private readonly IGuestCheckInRepository _guestCheckInRepository;

        public GuestCheckInController(IGuestCheckInRepository guestCheckInRepository)
        {
            _guestCheckInRepository = guestCheckInRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuestDetailById(int businessKey, long bookingKey, int guestId)
        {
            var gd = await _guestCheckInRepository.GetGuestDetailById(businessKey, bookingKey, guestId);
            return Ok(gd);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuestDetailsByBookingKey(int businessKey, long bookingKey)
        {
            var gd = await _guestCheckInRepository.GetGuestDetailsByBookingKey(businessKey, bookingKey);
            return Ok(gd);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuestCheckin(DO_GuestCheckInDetails obj)
        {
            var gd = await _guestCheckInRepository.CreateGuestCheckin(obj);
            return Ok(gd);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuestCheckin(DO_GuestCheckInDetails obj)
        {
            var gd = await _guestCheckInRepository.UpdateGuestCheckin(obj);
            return Ok(gd);
        }

        #region Document Upload
        [HttpGet]
        public async Task<IActionResult> GetGuestDocumentUploadDetailsByBookingKey(int businessKey, long bookingKey, int guestId)
        {
            var documents = await _guestCheckInRepository.GetGuestDocumentUploadDetailsByBookingKey(businessKey, bookingKey, guestId);
            return Ok(documents);
        }
        [HttpPost]
        public async Task<IActionResult> InsertGuestDocumentUpload(DO_GuestDocumentUpload obj)
        {
            var gd = await _guestCheckInRepository.InsertGuestDocumentUpload(obj);
            return Ok(gd);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuestDocumentUpload(DO_GuestDocumentUpload obj)
        {
            var gd = await _guestCheckInRepository.UpdateGuestDocumentUpload(obj);
            return Ok(gd);
        }
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActiveGuestDocumentUpload(DO_GuestDocumentUpload obj)
        {
            var gd = await _guestCheckInRepository.ActiveOrDeActiveGuestDocumentUpload(obj);
            return Ok(gd);
        }
        public async Task<IActionResult> GetDocumentUploadbySerialNumber(int businessKey, long bookingKey, int guestId, int serialno)
        {
            var gd = await _guestCheckInRepository.GetDocumentUploadbySerialNumber(businessKey, bookingKey, guestId, serialno);
            return Ok(gd);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDocument(int businessKey, long bookingKey, int guestId, int serialno)
        {
            var gd = await _guestCheckInRepository.DeleteDocument(businessKey, bookingKey, guestId, serialno);
            return Ok(gd);
        }
        #endregion Document Upload

        #region Address
        [HttpGet]
        public async Task<IActionResult> GetStateList(int isdCode)
        {
            var states = await _guestCheckInRepository.GetStateList(isdCode);
            return Ok(states);
        }
        [HttpGet]
        public async Task<IActionResult> GetCityList(int isdCode, int? stateCode)
        {
            var cities = await _guestCheckInRepository.GetCityList(isdCode, stateCode);
            return Ok(cities);
        }
        [HttpGet]
        public async Task<IActionResult> GetAreaList(int isdCode, int? stateCode, int? cityCode)
        {
            var areas = await _guestCheckInRepository.GetAreaList(isdCode, stateCode, cityCode);
            return Ok(areas);
        }
        [HttpGet]
        public async Task<IActionResult> GetAreaDetailsbyPincode(int isdCode, string pincode)
        {
            var area = await _guestCheckInRepository.GetAreaDetailsbyPincode(isdCode, pincode);
            return Ok(area);
        }
        #endregion

        #region Rescheduling
        [HttpGet]
        public async Task<IActionResult> GetGuestReschedulingByBookingKey(int businessKey, long bookingKey)
        {
            var rs = await _guestCheckInRepository.GetGuestReschedulingByBookingKey(businessKey, bookingKey);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> InsertGuestRescheduling(DO_Rescheduling obj)
        {
            var msg = await _guestCheckInRepository.InsertGuestRescheduling(obj);
            return Ok(msg);
        }
        
        #endregion

        #region Room change
        [HttpGet]
        public async Task<IActionResult> GetGuestRoomchangeByBookingKey(int businessKey, long bookingKey, int guestId)
        {
            var rc = await _guestCheckInRepository.GetGuestRoomchangeByBookingKey(businessKey, bookingKey, guestId);
            return Ok(rc);
        }
        [HttpPost]
        public async Task<IActionResult> InsertGuestRoomchange(DO_RoomChange obj)
        {
            var msg = await _guestCheckInRepository.InsertGuestRoomchange(obj);
            return Ok(msg);
        }
       
        #endregion

        #region Service
        [HttpGet]
        public async Task<IActionResult> GetGuestServiceByBookingKey(int businessKey, long bookingKey)
        {
            var svc = await _guestCheckInRepository.GetGuestServiceByBookingKey(businessKey, bookingKey);
            return Ok(svc);
        }
        [HttpPost]
        public async Task<IActionResult> InsertGuestService(DO_Service obj)
        {
            var msg = await _guestCheckInRepository.InsertGuestService(obj);
            return Ok(msg);
        }

        #endregion

        #region Update Guest Personal Details
        [HttpPost]
        public async Task<IActionResult> UpdateGuestPersonalDetails(DO_GuestCheckInDetails obj)
        {
            var msg = await _guestCheckInRepository.UpdateGuestPersonalDetails(obj);
            return Ok(msg);
        }
        #endregion
    }
}