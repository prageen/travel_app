using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Bl.Driver_details;
using Travel.Dto;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverBl _driverBl;
        private readonly IConfiguration _configuration;
        public DriverController(IConfiguration configuration, IDriverBl driverBl)
        {
            _driverBl = driverBl;
            _configuration = configuration;
        }
        [HttpPost("AddDriver")]
        public IActionResult AddDriver(DriverDto driverObj)
        {
            var responseMessage = _driverBl.AddDriver(driverObj);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeletDriver")]
        public IActionResult DeleteDriver(int PartyId)
        {
            var responseMessage = _driverBl.DeleteDriver(PartyId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UdateDriver")]
        public IActionResult UdateDriver(DriverDto deviceDto, int PartyId)
        {
            var responseMessage = _driverBl.UpdateDriver(deviceDto, PartyId);
            return Ok(responseMessage);
        }
    }
}
