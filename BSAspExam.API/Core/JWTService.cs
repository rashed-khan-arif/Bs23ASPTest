using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BSAspExam.API.Core
{
    public class JWTService
    {
        private const int EXPIRATION_MINUTES = 1;

        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthenticationResponse CreateToken(ApplicationUser user, IList<string>? roles)
        {
            var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

            var token = CreateJwtToken(
                CreateClaims(user, roles),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthenticationResponse
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new(
                _configuration["Jwt:ValidIssuer"],
                _configuration["Jwt:ValidAudience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private Claim[] CreateClaims(ApplicationUser user, IList<string>? roles)
        {
            var userRoles = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var userRole in roles)
            {
                if (userRole != null)
                    userRoles.ToList().Add(new Claim(ClaimTypes.Role, userRole));
            }

            return userRoles;
        }

        private SigningCredentials CreateSigningCredentials() =>
            new(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"])
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
