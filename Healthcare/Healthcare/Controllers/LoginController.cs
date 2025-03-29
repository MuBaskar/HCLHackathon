using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Healthcare.Models;
using System.Security.Claims;
using System.Text;

namespace Healthcare.Controllers
{
    public class LoginController : Controller
    {
        IConfiguration configuration;
        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
public IActionResult Login([FromBody] LoginModel model)
{
    // Check user credentials (in a real application, you'd authenticate against a database)
    if (model is { Username: "demo", Password: "password" })
    {
        // generate token for user
        var token = GenerateAccessToken(model.Username);
        // return access token for user's use
        return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token)});

    }
    // unauthorized user
    return Unauthorized("Invalid credentials");
}

// Generating token based on user information
private JwtSecurityToken GenerateAccessToken(string userName)
    {
        // Create user claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            // Add additional claims as needed (e.g., roles, etc.)
        };

        // Create a JWT
        var token = new JwtSecurityToken(
            issuer: configuration["JwtSettings:Issuer"],
            audience: configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1), // Token expiration time
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
                SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
    }
}
