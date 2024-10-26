using JWTAuthSample;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;

var key = "rfx4gIaRcW5iKMl3/LzOFdRqzilmGSfovYcJ5U/PJSSr3oebqyhz0fC1HSrIXYtVUr0ZtJ2";
var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<TokenGenerator>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidIssuer = "https://localhost",
            ValidAudience = "https://localhost",
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!")
    .RequireAuthorization();

app.MapPost("/login", (LoginRequest request, TokenGenerator tokenGenerator) =>
{
    return new
    {
        token = tokenGenerator.GenerateToken(request.Email)
    };
});

app.Run("http://0.0.0.0:5000");
