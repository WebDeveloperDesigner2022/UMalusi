using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.enums;
using UMelusiTrackApi.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController :ControllerBase
    {
        private readonly IuMalusiDbRepository _uMalusiDbRepository;

        public AuthenticationController(IuMalusiDbRepository uMalusiDbRepository)
        {
            _uMalusiDbRepository = uMalusiDbRepository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest auth)
        {

            try
            {
                var result = _uMalusiDbRepository.PerformAuthenticationCheck(auth.Username, auth.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.AuthenticationFailed.ToString());
            }


        }

    }
}
