using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Utitmate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenValidator : ControllerBase
    {
        private const string SecretKey = "supersecretunguesstextjejieijjrorjff";
        private readonly SymmetricSecurityKey _symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public JwtTokenValidator() { }
        [HttpGet("Validate-Token")]
        [AllowAnonymous]
        public IActionResult CheckToken(string token) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = _symmetricKey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            SecurityToken validateToken;
            tokenHandler.ValidateToken(token, validationParameters, out validateToken);
            return Ok();
        }


        [HttpGet("user-profile")]
        [Authorize]
        public IActionResult GetUserProfile()
        {
            var username = User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
                //var username = userIdClaim;
            return Ok($"Hello, {username}!");
        }

    }
}
