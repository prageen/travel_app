using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Bl.Trip;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{

    //[Authorize(Roles = UserRoles.User)]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripTypeBl _tripTypeBl;
        private readonly IConfiguration _configuration;
        public TripController(IConfiguration configuration, ITripTypeBl tripTypeBl)
        {
            _tripTypeBl = tripTypeBl;
            _configuration = configuration;
        }
        [HttpPost("AddTripType")]
        public IActionResult AddTripType(TripCategoryDto tripCategoryDto)
        {
            var responseMessage = _tripTypeBl.AddTripType(tripCategoryDto);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleTripType")]
        public IActionResult DeleTripType(int driverId)
        {
            var responseMessage = _tripTypeBl.DeleteTripType(driverId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UdateTripType")]
        public IActionResult UdateTripType(TripCategoryDto tripCategoryDto, int PartyId)
        {
            var responseMessage = _tripTypeBl.UpdateTripType(tripCategoryDto, PartyId);
            return Ok(responseMessage);
        }
    }
}
