using Microsoft.AspNetCore.Mvc;
using UMelusiTrackApi.enums;
using UMelusiTrackApi.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly IuMalusiDbRepository _uMalusiDbRepository;

        public FarmerController(IuMalusiDbRepository uMalusiDbRepository)
        {
            _uMalusiDbRepository = uMalusiDbRepository;
        }

        [HttpPost]
        public IActionResult CreateFarmer([FromBody] Farmer farmer)
        {
            try
            {
                if (farmer == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.FarmerNotValid.ToString());
                }
                bool farmerExists = _uMalusiDbRepository.DoesFarmerExistByUsername(farmer.Username);
                if (farmerExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, SystemErrorCodes.FarmerDuplicate.ToString());
                }
                _uMalusiDbRepository.CreateNewFarmer(farmer);
            }
            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.FarmerCreationFailed.ToString());
            }
            return Ok(farmer);
        }
/*        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest auth)
        {
            var authResponse = new AuthResponse();

            try
            {
                var result = _uMalusiDbRepository.PerformAuthenticationCheck(auth.Username, auth.Password);
                if (result)
                {
                    var authentication = _uMalusiDbRepository.GetAuthentication(auth.Username, auth.Password);

                    if (authentication != null)
                    {
                        var farmer = _uMalusiDbRepository.GetFarmerByAuthenticationId(authentication.AuthenticationId);

                        if (farmer != null)
                        {
                            authResponse.Authenticated = true;
                            authResponse.AuthenticatedFarmer = farmer;
                        }
                    }
                }
                return Ok(authResponse);
            }

            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.AuthenticationFailed.ToString());
            }


        }
*/
        [HttpGet]
        public IEnumerable<Farmer> Get()
        {
            return _uMalusiDbRepository.GetAllFarmers();
        }

        // GET api/<FarmerController>/5
        [HttpGet("byid")]
        public Farmer Get([FromQuery] int id)
        {
            return _uMalusiDbRepository.GetFarmerById(id);
        }

        /*[HttpGet("search")]
        public Farmer Get([FromQuery] string lastName)
        {
            return _uMalusiDbRepository.GetFarmerByLastName(lastName);
        }*/

    }
}
