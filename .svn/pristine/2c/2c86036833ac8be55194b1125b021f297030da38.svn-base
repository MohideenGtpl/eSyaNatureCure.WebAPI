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
    public class MemberShipCardController : ControllerBase
    {
        private readonly IMemberShipCardRepository _memberShipCardRepository;

        public MemberShipCardController(IMemberShipCardRepository memberShipCardRepository)
        {
            _memberShipCardRepository = memberShipCardRepository;

        }

        #region Member Ship Card

        /// <summary>
        /// Getting Get Membership Card.
        /// UI Reffered - Membership Card
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetMembershipCard()
        {
            var _mshipcard = await _memberShipCardRepository.GetMembershipCard();
            return Ok(_mshipcard);
        }

        /// <summary>
        /// Insert Or Update into Member Ship Card.
        /// UI Reffered - Member Ship Card
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateMembershipCard(DO_MemberShipCard obj)
        {
            var msg = await _memberShipCardRepository.InsertOrUpdateMembershipCard(obj);
            return Ok(msg);

        }


        /// <summary>
        /// Active/De Active  Member Ship Card.
        /// UI Reffered - Member Ship Card
        /// Params status-businesskey-memberId-couponId
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ActiveOrDeActiveMembershipCard(bool status, int membershiptype)
        {
            var msg = await _memberShipCardRepository.ActiveOrDeActiveMembershipCard(status, membershiptype);
            return Ok(msg);

        }
        #endregion
    }
}