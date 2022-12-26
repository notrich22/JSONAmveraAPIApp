using JSONAmveraAPIApp.Services;

namespace JSONAmveraAPIApp.Controllers
{
    public class MainController
    {
        private MainLogicService logicService;
        public MainController(MainLogicService logicService)
        {
            this.logicService = logicService;
        }

        public async Task GetServerInfo(HttpContext context)
        {
            ILogger logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"Path: /info  Time: {DateTime.Now.ToLongTimeString()}");
            await context.Response.WriteAsJsonAsync(await logicService.GetServerInfo());
        }
        public async Task GetServerStatus(HttpContext context)
        {
            ILogger logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"Path: /status  Time: {DateTime.Now.ToLongTimeString()}");
            await context.Response.WriteAsJsonAsync(await logicService.GetServerStatus());
        }
    }
}
