using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travel.Bl.Register;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Repository.Interface;

namespace Travel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterBl _accountServiceBl;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        // GET: api/<AccountController>
        public AccountController(IRegisterBl accountServiceBl,
            IConfiguration configuration, IMapper mapper,
            IUnitOfWork unitOfWork, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager
            )
        {
            _accountServiceBl = accountServiceBl;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _accountServiceBl.Signup(registerDto);
            return Ok(result);

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _accountServiceBl.SignIn(loginDto.PhoneNumber, loginDto.Password);
            if(result.Status == "Success")
            {
                var userRoles = await _userManager.GetRolesAsync(result?.Message);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.MobilePhone, result?.Message?.PhoneNumber),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();

        }
    }
}
