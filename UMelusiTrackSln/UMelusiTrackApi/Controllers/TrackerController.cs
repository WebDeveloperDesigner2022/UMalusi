using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.Interfaces;

namespace UMelusiTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly IuMalusiDbRepository _uMalusiDbRepository;

        public TrackerController(IuMalusiDbRepository uMalusiDbRepository)
        {
            _uMalusiDbRepository = uMalusiDbRepository;
        }

    }
}
