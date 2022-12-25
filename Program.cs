using JSONAmveraAPIApp.Controllers;
using JSONAmveraAPIApp.Messages;
using JSONAmveraAPIApp.Services;
using static JSONAmveraAPIApp.Messages.Messages;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MainController>();
builder.Services.AddTransient<MainLogicService>();
builder.Services.AddLogging();
builder.Services.AddTransient<ISolvator, NSSolvator>();
var app = builder.Build();

app.MapGet("/ping", async (context) => await context.Response.WriteAsJsonAsync($"Ping!"));
app.MapGet("/status", app.Services.GetRequiredService<MainController>().GetServerStatus);
app.Map("/info", app.Services.GetRequiredService<MainController>().GetServerInfo);
app.Map("/solve", async (context) =>
{
    app.Logger.LogInformation($"Path: /calculate  Time: {DateTime.Now.ToLongTimeString()}");
    CalcInputMessage? convertation = null;
    try
    {
        convertation = await context.Request.ReadFromJsonAsync<CalcInputMessage>();
    }
    catch (Exception e)
    {
        app.Logger.LogError($"Exception occured: {e.Message}: DateTime:{DateTime.Now.ToLongTimeString()}");
        ErrorMessage error = new ErrorMessage($"Error during request processing: {e.Message}");
    }
    if (convertation is null)
    {
        ErrorMessage error = new ErrorMessage("Invalid request parameters");
        app.Logger.LogError($"Exception occured: {error}: DateTime:{DateTime.Now.ToLongTimeString()}");
        await context.Response.WriteAsJsonAsync(error);
    }
    else
    {
        try
        {
            var Solvator = app.Services.GetRequiredService<ISolvator>();
            CalcOutputMessage solvation = Solvator.Solve(convertation);
            app.Logger.LogInformation(solvation.ToString());
            await context.Response.WriteAsJsonAsync(solvation);
        }
        catch (Exception e)
        {
            ErrorMessage error = new ErrorMessage($"Error during request processing: {e.Message}");
            app.Logger.LogError($"Exception occured: {error}: DateTime:{DateTime.Now.ToLongTimeString()}");
            await context.Response.WriteAsJsonAsync(error);
        }
    }
});
app.Run();
