using HangfireSample.Api.Jobs;
using HangfireSample.Config;

var builder = WebApplication.CreateBuilder();

builder.AddHangfire();

var app = builder.Build();

app.UseHangfire();
app.MapGroup("/jobs").MapJobsApi();

app.Run();