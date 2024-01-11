using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.Party;
using Travel.Dto;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyBl _partyMasterBl;
        private readonly IConfiguration _configuration;
        public PartyController(IConfiguration configuration, IPartyBl partyMasterBl)
        {
            _partyMasterBl = partyMasterBl;
            _configuration = configuration;
        }
        [HttpPost("AddParty")]
        public IActionResult AddParty(PartyDto partyObj)
        {
            var responseMessage = _partyMasterBl.AddParty(partyObj);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeleteParty")]
        public IActionResult DeleteParty(int PartyId)
        {
            var responseMessage = _partyMasterBl.DeleteParty(PartyId);
            return Ok(responseMessage);
        }

        [HttpPut(Name = "UpdateParty")]
        public IActionResult UpdateParty(PartyDto deviceDto, int PartyId)
        {
            var responseMessage = _partyMasterBl.UpdateParty(deviceDto, PartyId);
            return Ok(responseMessage);
        }
    }
}
