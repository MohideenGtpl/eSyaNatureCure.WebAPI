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
    public class PackageDiscountController : ControllerBase
    {
        private readonly IPackageDiscountRepository _packagediscountRepository;

        public PackageDiscountController(IPackageDiscountRepository packagediscountRepository)
        {
            _packagediscountRepository = packagediscountRepository;
        }
        #region Package discount
        /// <summary>
        /// Getting   Package discount by PackageId.
        /// UI Reffered - Package Discount
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPackageDiscountbyPackageId(int packageId, int roomtypeId, string occupancyType)
        {
            var _pdis = await _packagediscountRepository.GetAllPackageDiscountbyPackageId(packageId, roomtypeId, occupancyType);
            return Ok(_pdis);
        }

        /// <summary>
        /// Insert  Package Discount.
        /// UI Reffered -Package Discount
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertPackageDiscount(DO_PackageDiscount obj)
        {
            var msg = await _packagediscountRepository.InsertPackageDiscount(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Update Package Discount.
        /// UI Reffered -Package Discount
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdatePackageDiscount(DO_PackageDiscount obj)
        {
            var msg = await _packagediscountRepository.UpdatePackageDiscount(obj);
            return Ok(msg);

        }
        /// <summary>
        /// Active/De Active Package Discount.
        /// UI Reffered -Package Discount
        /// Params status-Package Discount
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ActiveOrDeActivePackageDiscount(DO_PackageDiscount objdis)
        {
            var msg = await _packagediscountRepository.ActiveOrDeActivePackageDiscount(objdis);
            return Ok(msg);

        }
        #endregion Package 
    }
}