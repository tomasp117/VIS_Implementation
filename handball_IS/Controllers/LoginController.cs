using handball_IS.Modules.Actors.super;
using handball_IS.Objects.Actors.super;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace handball_IS.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController : ControllerBase
    {
        private readonly PersonModule personModule;
        private readonly IConfiguration configuration;

        public LoginController(PersonModule personModule, IConfiguration configuration)
        {
            this.personModule = personModule;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> loginData)
        {
            Console.WriteLine("Login request received: " + JsonSerializer.Serialize(loginData));
            if (!loginData.TryGetValue("username", out var username) || !loginData.TryGetValue("password", out var password))
            {
                return BadRequest("Username and password are required.");
            }

            var (success, role, coachId) = await personModule.Login(username, password);

            if (!success)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
            };

            if (role == "Coach" && coachId.HasValue)
            {
                claims.Add(new Claim("coachId", coachId.Value.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_SECRET"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                role = role,
                coachId = coachId,
                message = "Login successful!"
            });
        }

    }
}
