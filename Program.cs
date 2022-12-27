using JSONAmveraAPIApp;
using JSONAmveraAPIApp.Controllers;
using JSONAmveraAPIApp.Model;
using JSONAmveraAPIApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MainController>();
builder.Services.AddSingleton<MainLogicService>();
builder.Services.AddSingleton<ConverterController>();
builder.Services.AddSingleton<ConverterLogicService>();
builder.Services.AddSingleton<DBController>();
builder.Services.AddLogging();
builder.Services.AddSingleton<IBaseConverter, SimpleBaseConverter>();

var app = builder.Build();
app.UseMiddleware<Middleware>();
app.MapGet("/ping", async (context) => await context.Response.WriteAsJsonAsync($"Ping!"));
app.MapGet("/status", app.Services.GetRequiredService<MainController>().GetServerStatus);
app.Map("/info", app.Services.GetRequiredService<MainController>().GetServerInfo);
app.Map("/convert", app.Services.GetRequiredService<ConverterController>().Convert);
app.Run();
