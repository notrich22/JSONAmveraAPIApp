using JSONAmveraAPIApp.Controllers;
using JSONAmveraAPIApp.Messages;
using JSONAmveraAPIApp.Services;
using static JSONAmveraAPIApp.Messages.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MainController>();
builder.Services.AddSingleton<MainLogicService>();
builder.Services.AddSingleton<ConverterController>();
builder.Services.AddSingleton<ConverterLogicService>();
builder.Services.AddLogging();
builder.Services.AddSingleton<IBaseConverter, SimpleBaseConverter>();

var app = builder.Build();

app.MapGet("/ping", async (context) => await context.Response.WriteAsJsonAsync($"Ping!"));
app.MapGet("/status", app.Services.GetRequiredService<MainController>().GetServerStatus);
app.Map("/info", app.Services.GetRequiredService<MainController>().GetServerInfo);
app.Map("/convert", app.Services.GetRequiredService<ConverterController>().Convert);
app.Run();
