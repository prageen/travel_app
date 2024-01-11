using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Bl.Vehicle;
using Travel.Dto;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleMasterBl _vehicleMasterBl;
        private readonly IConfiguration _configuration;
        public VehicleController(IConfiguration configuration, IVehicleMasterBl vehicleMasterBl)
        {
            _vehicleMasterBl = vehicleMasterBl;
            _configuration = configuration;
        }
        [HttpPost("AddVehicle")]
        public IActionResult AddVehicle(VehicleDto deviceDto)
        {
            var responseMessage = _vehicleMasterBl.AddVehicle(deviceDto);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteVehicle")]
        public IActionResult DeleteVehicle(int vehicleId)
        {
            var responseMessage = _vehicleMasterBl.DeleteVehicle(vehicleId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateVehicle")]
        public IActionResult UpdateVehicle(VehicleDto vehicleDto, int VehicleId)
        {
            var responseMessage = _vehicleMasterBl.UpdateVehicle(vehicleDto, VehicleId);
            return Ok(responseMessage);
        }
    }
}
