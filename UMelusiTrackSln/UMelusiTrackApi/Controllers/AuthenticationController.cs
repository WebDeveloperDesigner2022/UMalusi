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
            var authResponse = new AuthResponse();

            try
            {
                var result = _uMalusiDbRepository.PerformAuthenticationCheck(auth.Username, auth.Password);
                if (result)
                {
                    var farmer = _uMalusiDbRepository.GetAuthentication(auth.Username, auth.Password);

                    if (farmer != null)
                    {
                        authResponse.Authenticated = true;
                        authResponse.AuthenticatedFarmer = farmer;
                    }
                }
                return Ok(authResponse);
            }

            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.AuthenticationFailed.ToString());
            }


            }
      
    }
}
