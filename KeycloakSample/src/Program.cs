using KeycloakSample.Config;

var builder = WebApplication.CreateBuilder();

builder.AddScalar();
builder.AddKeycloakAuth();

var app = builder.Build();

app.MapScalar();
app.UseAuthorization();

app.MapGet("protected", () => "Protected data")
    .RequireAuthorization();

app.Run();
