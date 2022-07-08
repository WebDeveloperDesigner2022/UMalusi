using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.enums;
using UMelusiTrackApi.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivestockController : ControllerBase
    {
        private readonly IuMalusiDbRepository _uMalusiDbRepository;

        public LivestockController(IuMalusiDbRepository uMalusiDbRepository)
        {
            _uMalusiDbRepository = uMalusiDbRepository;
        }

        [HttpPost]
        public IActionResult CreateLivestock([FromBody] Livestock livestock)
        {
            try
            {
                if (livestock == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.LivestockNotValid.ToString());
                }
                _uMalusiDbRepository.CreateNewLivestock(livestock);
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.LivestockCreationFailed.ToString());
            }
            return Ok(livestock);
        }


        [HttpGet("byfarmerid")]
        public IList<Livestock> Get([FromQuery] int farmerId)
        {
            return _uMalusiDbRepository.GetLivestocksByFarmerId(farmerId);
        }
    }
}
