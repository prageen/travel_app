using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.Plans;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    public class PlansController : ControllerBase
    {
        private readonly IPlans _plansBl;
        private readonly IConfiguration _configuration;
        public PlansController(IConfiguration configuration, IPlans plansBl)
        {
            _plansBl = plansBl;
            _configuration = configuration;
        }

        [HttpPost("AddPlan")]
        public IActionResult AddPlans(PlansDto plansObj)
        {
            var responseMessage = _plansBl.AddPlan(plansObj);
            return Ok(responseMessage);
        }

        [HttpPost("UpdatePlan")]
        public IActionResult UpdatePlans(PlansDto plansObj, int plansId)
        {
            var responseMessage = _plansBl.UpdatePlan(plansObj, plansId);
            return Ok(responseMessage);
        }

        [HttpPost("ActivatePlan")]
        public IActionResult ActivatePlans(int plansId)
        {
            var responseMessage = _plansBl.ActivatePlan(plansId);
            return Ok(responseMessage);
        }

        [HttpPost("DeActivatePlan")]
        public IActionResult DeActivatePlans(int plansId)
        {
            var responseMessage = _plansBl.DeactivatePlan(plansId);
            return Ok(responseMessage);
        }

        [HttpGet("GetPlan")]
        public IActionResult GetPlans(int plansId)
        {
            var responseMessage = _plansBl.GetPlan(plansId);
            return Ok(responseMessage);
        }

        [HttpGet("ListPlan")]
        public IActionResult ListPlans()
        {
            var responseMessage = _plansBl.ListPlans();
            return Ok(responseMessage);
        }

    }
}
