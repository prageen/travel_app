using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.District;
using Travel.Bl.Location;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationBl _locationBl;
        private readonly IConfiguration _configuration;
        public LocationController(IConfiguration configuration, ILocationBl locationBl)
        {
            _locationBl = locationBl;
            _configuration = configuration;
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation(LocationDto locationDto)
        {
            var responseMessage = _locationBl.AddLocation(locationDto);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateLocation")]
        public IActionResult UpdateLocation(LocationDto locationDto, int locationId)
        {
            var responseMessage = _locationBl.UpdateLocation(locationDto, locationId);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteLocation")]
        public IActionResult DeleteLocation(int locationId)
        {
            var responseMessage = _locationBl.DeleteLocation(locationId);
            return Ok(responseMessage);
        }
    }
}
