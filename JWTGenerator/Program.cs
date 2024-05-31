using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var utcNow = DateTime.UtcNow;
var jwtHandler = new JwtSecurityTokenHandler();

var claims = new Claim[]
{
    new("sub", Guid.Empty.ToString()),
    new("name", "username"),
};
var key = "rfx4gIaRcW5iKMl3/LzOFdRqzilmGSfovYcJ5U/PJSSr3oebqyhz0fC1HSrIXYtVUr0ZtJ2";

var jwtDescriptor = new JwtSecurityToken(
    claims: claims,
    notBefore: utcNow,
    expires: utcNow.AddHours(1),
    issuer: "https://localhost",
    audience: "https://localhost",
    signingCredentials: new SigningCredentials(
    key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
    algorithm: SecurityAlgorithms.HmacSha512Signature
)
);
var jwt = jwtHandler.WriteToken(jwtDescriptor);

Console.WriteLine(jwt);