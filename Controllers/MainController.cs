using JSONAmveraAPIApp.Model;
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
            await context.Response.WriteAsJsonAsync(await logicService.GetServerInfo());
            logger.LogInformation($"Path: /info  Time: {DateTime.Now.ToLongTimeString()}");
        }
        public async Task GetServerStatus(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await logicService.GetServerStatus());
            logger.LogInformation($"Path: /status  Time: {DateTime.Now.ToLongTimeString()}");
        }
    }
}
