using StressApi.Controller;
using StressApi.Logging;
using StressApi.Security;
using StressApi.Services;
using StressApi.Util;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

builder.Services.AddSingleton<StressService>();
builder.Services.AddJwtAuth(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

var api = app.MapApi();

api.MapHealthController();
api.MapHelloController();
api.MapStressController();

app.Run();
