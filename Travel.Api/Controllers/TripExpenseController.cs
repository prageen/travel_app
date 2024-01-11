using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Bl.TripExpense;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripExpenseController : ControllerBase
    {
        private readonly ITripExpenseBl _tripExpenseBl;
        private readonly IConfiguration _configuration;
        public TripExpenseController(IConfiguration configuration, ITripExpenseBl tripExpenseBl)
        {
            _tripExpenseBl = tripExpenseBl;
            _configuration = configuration;
        }
        [HttpPost("AddTripExpense")]
        public IActionResult AddTripExpense(TripExpenceDto tripExpenceDto)
        {
            var responseMessage = _tripExpenseBl.AddTripExpense(tripExpenceDto);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteTripExpense")]
        public IActionResult DeleteTripExpense(int tripId)
        {
            var responseMessage = _tripExpenseBl.DeleteTripExpense(tripId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateTripExpense")]
        public IActionResult UpdateTripExpense(TripExpenceDto tripExpenceDto, int VehicleId)
        {
            var responseMessage = _tripExpenseBl.UpdateTripExpense(tripExpenceDto, VehicleId);
            return Ok(responseMessage);
        }

        [HttpPost("AddBanner")]
        public IActionResult AddBanner(BannerDto bannerDto)
        {
            var responseMessage = _tripExpenseBl.AddBanner(bannerDto);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteBanner")]
        public IActionResult DeleteBanner(int bannerId)
        {
            var responseMessage = _tripExpenseBl.DeleteBanner(bannerId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateBanner")]
        public IActionResult UpdateBanner(BannerDto bannerDto, int bannerId)
        {
            var responseMessage = _tripExpenseBl.UpdateBanner(bannerDto, bannerId);
            return Ok(responseMessage);
        }
    }
}
