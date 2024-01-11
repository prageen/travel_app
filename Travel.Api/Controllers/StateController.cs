using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.State;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateBl _stateBl;
        private readonly IConfiguration _configuration;
        public StateController(IConfiguration configuration, IStateBl stateBl)
        {
            _stateBl = stateBl;
            _configuration = configuration;
        }

        [HttpPost("AddState")]
        public IActionResult AddState(StateDto stateObj)
        {
            var responseMessage = _stateBl.AddState(stateObj);
            return Ok(responseMessage);
        }

        [HttpDelete(Name = "DeletState")]
        public IActionResult DeletState(int StateId)
        {
            var responseMessage = _stateBl.DeleteState(StateId);
            return Ok(responseMessage);
        }


        [HttpPut(Name = "UpdateState")]
        public IActionResult UpdateState(StateDto stateDto, int StateId)
        {
            var responseMessage = _stateBl.UpdateState(stateDto, StateId);
            return Ok(responseMessage);
        }
    }
}
