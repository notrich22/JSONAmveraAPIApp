using JSONAmveraAPIApp.Services;

namespace JSONAmveraAPIApp.Controllers
{
    public class MainController
    {
        private MainLogicService logicService;
        private ILogger<MainController> logger;
        public MainController(MainLogicService logicService, ILogger<MainController> logger)
        {
            this.logicService = logicService;
            this.logger = logger;
        }

        public async Task GetServerInfo(HttpContext context)
        {
            logger.LogInformation($"Path: /info  Time: {DateTime.Now.ToLongTimeString()}");
            await context.Response.WriteAsJsonAsync(await logicService.GetServerInfo());
        }
        public async Task GetServerStatus(HttpContext context)
        {
            logger.LogInformation($"Path: /status  Time: {DateTime.Now.ToLongTimeString()}");
            await context.Response.WriteAsJsonAsync(await logicService.GetServerStatus());
        }
    }
}
