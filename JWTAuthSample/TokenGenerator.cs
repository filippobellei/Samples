using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthSample;

public class TokenGenerator
{
    public string GenerateToken(string email)
    {
        var tokenHandler = new JsonWebTokenHandler();
        var key = "rfx4gIaRcW5iKMl3/LzOFdRqzilmGSfovYcJ5U/PJSSr3oebqyhz0fC1HSrIXYtVUr0ZtJ2";

        var jwtDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Email, email),
                new ("role", "admin")
            ]),
            Expires = DateTime.UtcNow.AddMinutes(60),
            Issuer = "https://localhost",
            Audience = "https://localhost",
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha512Signature
            )
        };

        return tokenHandler.CreateToken(jwtDescriptor);
    }
}
