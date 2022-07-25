using Microsoft.AspNetCore.Mvc;
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
 