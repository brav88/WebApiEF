using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiEntityFramework.Model;

namespace WebApiEntityFramework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorizeController : ControllerBase
	{
		[HttpPost("login")]
		public IActionResult Login([FromBody] UserLogin login)
		{
			if (login.Username == "admin" && login.Password == "1234")
			{
				var claims = new[]
				{
					new Claim(ClaimTypes.Name, login.Username)
				};

				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("XXX"));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

				var token = new JwtSecurityToken(
					issuer: "tripadvisor.com",
					audience: "tripadvisor.com",
					claims: claims,
					expires: DateTime.Now.AddMinutes(30),
					signingCredentials: creds);

				return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
			}

			return Unauthorized();
		}
	}
}

