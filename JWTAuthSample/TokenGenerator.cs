using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthSample;

public class TokenGenerator
{
    public string GenerateToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = "rfx4gIaRcW5iKMl3/LzOFdRqzilmGSfovYcJ5U/PJSSr3oebqyhz0fC1HSrIXYtVUr0ZtJ2";

        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, email)
        };

        var jwtDescriptor = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            issuer: "https://localhost",
            audience: "https://localhost",
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha512Signature
            )
        );

        return tokenHandler.WriteToken(jwtDescriptor);
    }
}
