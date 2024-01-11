using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Bl.VehicleExpense;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleExpenseController : ControllerBase
    {
        private readonly IVehicleExpenseBl _VehicleExpenseBl;
        private readonly IConfiguration _configuration;
        public VehicleExpenseController(IConfiguration configuration, IVehicleExpenseBl VehicleExpenseBl)
        {
            _VehicleExpenseBl = VehicleExpenseBl;
            _configuration = configuration;
        }
        [HttpPost("AddVehicleExpense")]
        public IActionResult AddVehicleExpense(VehicleExpenceDto VehicleExpenceObj)
        {
            var responseMessage = _VehicleExpenseBl.AddVehicleExpense(VehicleExpenceObj);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteVehicleExpense")]
        public IActionResult DeleteVehicleExpense(int VehicleExpenseId)
        {
            var responseMessage = _VehicleExpenseBl.DeleteVehicleExpense(VehicleExpenseId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UdateVehicleExpense")]
        public IActionResult UdateVehicleExpense(VehicleExpenceDto VehicleExpenceDtoDto, int PartyId)
        {
            var responseMessage = _VehicleExpenseBl.UpdateVehicleExpense(VehicleExpenceDtoDto, PartyId);
            return Ok(responseMessage);
        }
    }
}
