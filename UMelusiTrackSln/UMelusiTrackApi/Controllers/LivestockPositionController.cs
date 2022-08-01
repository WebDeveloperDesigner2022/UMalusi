using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.enums;
using UMelusiTrackApi.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivestockPositionController : ControllerBase
    {
        private readonly IuMalusiDbRepository _uMalusiDbRepository;

        public LivestockPositionController(IuMalusiDbRepository uMalusiDbRepository)
        {
            _uMalusiDbRepository = uMalusiDbRepository;
        }

        [HttpPost]

        public IActionResult UpdateLiveStockPosition(LivestockMovement livestockMovement)
        {
            LivestockPosition livestockPosition = null;

            try
            {

                if (livestockMovement == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.LivestockNotValid.ToString());
                }

                var livestock = _uMalusiDbRepository.GetLivestockById(livestockMovement.LivestockId);

                if (livestock != null)
                {

                    livestockPosition = new LivestockPosition();
                    livestockPosition.Latitude = livestockMovement.Latitude;
                    livestockPosition.Longitude = livestockMovement.Longitude;
                    livestockPosition.DateTime = DateTime.Now;
                    livestockPosition.LivestockName = livestockMovement.LivestockName;
                    livestockPosition.LivestockId = livestockMovement.LivestockId;
                    livestockPosition.Livestock = livestock;

                    _uMalusiDbRepository.InsertLiveStockPosition(livestockPosition);

                    // TODO   Check GeoFence

                    // TODO  if outside GeoFence then send Push Notification


                }
                else
                {
                    return BadRequest(SystemErrorCodes.LivestockNotValid.ToString());
                }
       
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.LivestockPositionCreationFailed.ToString());
            }
            return Ok(livestockPosition);
        }



        [HttpGet("byLivestockid")]
        public IList<LivestockPosition> GetLivestockPositionsByLivestockId([FromQuery] int livestockId)
        {
            return _uMalusiDbRepository.GetLivestockPositionsByLivestockId(livestockId);
        }

        [HttpGet("byLivestockDates")]
        public IList<LivestockPosition> GetLivestocksByLivestockId([FromQuery] int livestockId, DateTime dateTime)
        {
            return _uMalusiDbRepository.GetLivestockPositionsByLivestockIdAndDateTime(livestockId, dateTime);
        }

    }
}
 