using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.Interfaces;

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
    }
}
