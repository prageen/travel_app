using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.District;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictBl _districtBl;
        private readonly IConfiguration _configuration;
        public DistrictController(IConfiguration configuration, IDistrictBl districtBl)
        {
            _districtBl = districtBl;
            _configuration = configuration;
        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(DistrictDto districtDto)
        {
            var responseMessage = _districtBl.AddDistrict(districtDto);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateDistrict")]
        public IActionResult UpdateDistrict(DistrictDto districtDto, int districtId)
        {
            var responseMessage = _districtBl.UpdateDistrict(districtDto, districtId);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteDistrict")]
        public IActionResult DeleteDistrict(int districtId)
        {
            var responseMessage = _districtBl.DeleteDistrict(districtId);
            return Ok(responseMessage);
        }
    }
}
