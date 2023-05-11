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
    public class PackageAmenitiesController : ControllerBase
    {
        private readonly IPackageAmenitiesRepository _packageAmenitiesRepository;

        public PackageAmenitiesController(IPackageAmenitiesRepository packageAmenitiesRepository)
        {
            _packageAmenitiesRepository = packageAmenitiesRepository;

        }
        #region Package Amenities
        /// <summary>
        /// Getting  All Package Amenities.
        /// UI Reffered - Package Amenities
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPackageAmenitiesbyPackageId(int packageId)
        {
            var pkgAmenities = await _packageAmenitiesRepository.GetAllPackageAmenitiesbyPackageId(packageId);
            return Ok(pkgAmenities);
        }



        /// <summary>
        /// Insert  Package Amenities.
        /// UI Reffered -Package Amenities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertPackageAmenities(DO_PackageAmenities obj)
        {
            var msg = await _packageAmenitiesRepository.InsertPackageAmenities(obj);
            return Ok(msg);

        }

        /// <summary>
        /// Update  Package Amenities.
        /// UI Reffered -Package Amenities
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdatePackageAmenities(DO_PackageAmenities obj)
        {
            var msg = await _packageAmenitiesRepository.UpdatePackageAmenities(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Package Amenities.
        /// UI Reffered -Package Amenities
        /// Params status-
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActivePackageAmenities(DO_PackageAmenities objamenities)
        {
            var msg = await _packageAmenitiesRepository.ActiveOrDeActivePackageAmenities(objamenities);
            return Ok(msg);

        }

        /// <summary>
        /// Getting Package Amenity for Edit.
        /// UI Reffered - Package Amenities
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPackageAmenitiesbyOptiontype(int packageId, string optionType, int serilalNo)
        {
            var pkgAmenities = await _packageAmenitiesRepository.GetPackageAmenitiesbyOptiontype(packageId, optionType,serilalNo);
            return Ok(pkgAmenities);
        }
        #endregion Package Amenities
    }
}