using StreamSample.Endpoints;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

var app = builder.Build();

app.UseFileServer();
app.MapControllers();
app.MapStreamEndpoints();

app.Run();
