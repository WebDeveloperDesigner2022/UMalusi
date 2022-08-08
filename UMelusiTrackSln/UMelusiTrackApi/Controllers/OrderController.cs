﻿using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.enums;
using UMelusiTrackApi.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IuMalusiDbRepository _uMalusiDbRepository;

        public OrderController(IuMalusiDbRepository uMalusiDbRepository)
        {
            _uMalusiDbRepository = uMalusiDbRepository;
        }
       /* public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                if (order == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.LivestockNotValid.ToString());
                }

                var farmer = _uMalusiDbRepository.GetFarmerById(order.FarmerId);
                order.Farmer = farmer;


                _uMalusiDbRepository.CreateNewOrder(order);
            }
            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.LivestockCreationFailed.ToString());
            }
            return Ok(order);
        }*/

    }
}
