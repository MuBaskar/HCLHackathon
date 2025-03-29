using DBRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LoginService : ILoginService
    {
        public  ILogin _login;
        public IConfiguration configuration;
        public LoginService(ILogin login,IConfiguration configuration)
        {
            _login = login;
            this.configuration = configuration;

        }
        public async Task<string> LoginAsync(string email, string password)
        {
            var result = await _login.LoginAsync(email, password);
            string token = "";
            if (result!=null)
            {
                token = new JwtSecurityTokenHandler().WriteToken(GenerateAccessToken(result));
            }
            return token;
        }
        private JwtSecurityToken GenerateAccessToken(User user)
        {
            // Create user claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
             new Claim(ClaimTypes.Name, user.FullName),
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
