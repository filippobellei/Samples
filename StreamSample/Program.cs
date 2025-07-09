using StreamSample.Endpoints;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.UseFileServer();
app.MapStreamEndpoints();

app.Run();
