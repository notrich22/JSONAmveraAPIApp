using JsonAmveraConvertationApiApp;
using JsonAmveraConvertationApiApp.Controllers;
using JsonAmveraConvertationApiApp.Model;
using JsonAmveraConvertationApiApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MainController>();
builder.Services.AddSingleton<MainLogicService>();
builder.Services.AddSingleton<ConverterController>();
builder.Services.AddSingleton<ConverterLogicService>();
builder.Services.AddSingleton<DBController>();
builder.Services.AddSingleton<DBLogicService>();
builder.Services.AddLogging();
builder.Services.AddSingleton<IBaseConverter, SimpleBaseConverter>();

var app = builder.Build();

app.UseMiddleware<Middleware>();

app.MapGet("/", async (context) => await context.Response.WriteAsJsonAsync($"Welcome!"));
app.MapGet("/ping", async (context) => await context.Response.WriteAsJsonAsync($"Ping!"));
app.MapGet("/status", app.Services.GetRequiredService<MainController>().GetServerStatus);
app.Map("/info", app.Services.GetRequiredService<MainController>().GetServerInfo);
app.Map("/convert", app.Services.GetRequiredService<ConverterController>().Convert);
app.Map("/get-hosts", app.Services.GetRequiredService<DBController>().GetHosts);
app.Map("/get-requests", app.Services.GetRequiredService<DBController>().GetRequests);
app.Map("/get-requests-by-host", app.Services.GetRequiredService<DBController>().GetRequestsByHost);

app.Run();
