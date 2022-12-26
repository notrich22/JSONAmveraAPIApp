using JSONAmveraAPIApp.Controllers;
using JSONAmveraAPIApp.Messages;
using JSONAmveraAPIApp.Services;
using static JSONAmveraAPIApp.Messages.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MainController>();
builder.Services.AddTransient<MainLogicService>();
builder.Services.AddTransient<SolvationController>();
builder.Services.AddTransient<SolvationLogicService>();
builder.Services.AddLogging();
builder.Services.AddTransient<IBaseConverter, SimpleBaseConverter>();

var app = builder.Build();

app.MapGet("/ping", async (context) => await context.Response.WriteAsJsonAsync($"Ping!"));
app.MapGet("/status", app.Services.GetRequiredService<MainController>().GetServerStatus);
app.Map("/info", app.Services.GetRequiredService<MainController>().GetServerInfo);
app.Map("/convert", app.Services.GetRequiredService<SolvationController>().Convert);
app.Run();
