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
            catch (Exception ex)
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
        #region snippetDelete

      /*  [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var item = _uMalusiDbRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _uMalusiDbRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }*/
        #endregion
      
    }
}
