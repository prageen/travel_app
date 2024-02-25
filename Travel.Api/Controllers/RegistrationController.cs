using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.Registration;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistration _registrationBl;
        private readonly IConfiguration _configuration;
        public RegistrationController(IRegistration registrationBl, IConfiguration configuration)
        {
            _registrationBl = registrationBl;
            _configuration = configuration;
        }
        [HttpPost("AddRegistration")]
        public IActionResult AddPlans(RegistrationDto registrationDto)
        {
            var responseMessage = _registrationBl.AddRegistration(registrationDto);
            return Ok(responseMessage);
        }
        [HttpPost("updateRegistration")]
        public IActionResult UpdatePlans(RegistrationDto registrationDto, int registrationId)
        {
            var responseMessage = _registrationBl.UpdateRegistration(registrationDto, registrationId);
            return Ok(responseMessage);
        }
        [HttpPost("ActivateRegistration")]
        public IActionResult ActivateRegistration(int registrationId)
        {
            var responseMessage = _registrationBl.ActivateRegistration(registrationId);
            return Ok(responseMessage);
        }
        [HttpPost("DeActivateRegistration")]
        public IActionResult DeActivateRegistration(int registrationId)
        {
            var responseMessage = _registrationBl.DeactivateRegistration(registrationId);
            return Ok(responseMessage);
        }
        [HttpGet("GetRegistration")]
        public IActionResult GetRegistration(int registrationId)
        {
            var responseMessage = _registrationBl.GetRegistration(registrationId);
            return Ok(responseMessage);
        }

        [HttpGet("ListRegistration")]
        public IActionResult ListRegistration()
        {
            var responseMessage = _registrationBl.ListRegistration();
            return Ok(responseMessage);
        }
    }
}
