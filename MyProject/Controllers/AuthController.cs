using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using MyProject.ApiModels;

namespace MyProject.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("/auth")]
        public IActionResult Auth([FromBody] JWTRequestDTO request)
        {
            JWTTokenDTO token = null;
            var userName = configuration.GetValue<string>("JWT:DemoUsername");
            var password = configuration.GetValue<string>("JWT:DemoPassword");

            if (request.Username == userName && request.Password == password)
            {
                token = GetToken();
            }

            return new OkObjectResult(token);
        }

        JWTTokenDTO GetToken()
        {
            var expiresInSec = 300;
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JWT:Secret"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { }),
                Expires = DateTime.UtcNow.AddSeconds(expiresInSec),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JWTTokenDTO
            {
                AccessToken = tokenHandler.WriteToken(token),
                ExpiresIn = expiresInSec,
                TokenType = "Bearer"
            };
        }
    }
}
