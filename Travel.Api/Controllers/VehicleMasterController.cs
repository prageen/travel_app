using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMasterController : ControllerBase
    {
        private readonly IVehicleMasterBl _vehicleMasterBl;
        private readonly IConfiguration _configuration;
        public VehicleMasterController(IConfiguration configuration, IVehicleMasterBl vehicleMasterBl)
        {
            _vehicleMasterBl = vehicleMasterBl;
            _configuration = configuration;
        }
        [HttpPost("AddVehicleMaster")]
        public IActionResult AddVehicleMaster(VehicleMasterDto deviceDto)
        {
            var responseMessage = _vehicleMasterBl.AddVehicleCategory(deviceDto);
            return Ok(responseMessage);
        }

        [HttpDelete( Name = "DeleteVehicleMaster")]
        public IActionResult DeleteVehicle(int vehicleId)
        {
            var responseMessage = _vehicleMasterBl.DeleteVehicleCategory(vehicleId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateVehicleMaster")]
        public IActionResult UpdateVehicle(VehicleMasterDto vehicleDto, int VehicleId)
        {
            var responseMessage = _vehicleMasterBl.UpdateVehicleCategory(vehicleDto, VehicleId);
            return Ok(responseMessage);
        }
    }
}
