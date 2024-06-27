using Asp.Versioning;
using AutoMapper;
using Fiap.Monitoramento.Ambiental.Models;
using Fiap.Monitoramento.Ambiental.Services;
using Fiap.Monitoramento.Ambiental.VIewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.Monitoramento.Ambiental.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            var authenticateUser = _authService.Authenticate(user.UserName, user.PasswordHash);
            if (authenticateUser == null)
                return Unauthorized();

            var token = GenerateJwtToken(authenticateUser);

            return Ok(new { Token = token });
        }


        private string GenerateJwtToken(UserModel user)
        {
            byte[] secret = Encoding.ASCII.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi");
            var security = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);

            JwtSecurityTokenHandler jwtSecurityToken = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor securityTokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = "fiap",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = jwtSecurityToken.CreateToken(securityTokenDecriptor);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
