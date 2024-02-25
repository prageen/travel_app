using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Travel.Bl.Users;
using Travel.Dto;
using Travel.Dto.Trip;

namespace Travel.Api.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUsersBl _usersBl;
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration, IUsersBl usersBl)
        {
            _usersBl = usersBl;
            _configuration = configuration;
        }

        [HttpPost("AddUsers")]
        public IActionResult AddUsers(UsersDto usersObj)
        {
            var responseMessage = _usersBl.AddUsers(usersObj);
            return Ok(responseMessage);
        }

        [HttpPost("UpdateUsers")]
        public IActionResult UpdateUsers(UsersDto usersObj, int usersId)
        {
            var responseMessage = _usersBl.UpdateUsers(usersObj, usersId);
            return Ok(responseMessage);
        }

        [HttpPost("DeleteUsers")]
        public IActionResult DeleteUsers(int userId)
        {
            var responseMessage = _usersBl.DeleteUsers(userId);
            return Ok(responseMessage);
        }
        [HttpPost("ActivateUsers")]
        public IActionResult ActivateUsers(int userId)
        {
            var responseMessage = _usersBl.ActivateUsers(userId);
            return Ok(responseMessage);
        }
    }

}
