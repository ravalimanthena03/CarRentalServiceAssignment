using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarRentalServiceAssignment.Models;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
namespace CarRentalServiceAssignment.Helper
{
    public class JwtHelper
    {
        public static IConfiguration _configuration;
        public JwtHelper(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public  string GenerateToken(User user)
        {
            // Get the key, issuer, and audience from the configuration (appsettings.json)
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
