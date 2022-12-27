using JSONAmveraAPIApp.Services;
using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Controllers
{
    public class ConverterController
    {
        private ConverterLogicService logicService;
        private ILogger logger;
        public ConverterController(ConverterLogicService logicService, ILogger<ConverterController> logger)
        {
            this.logicService = logicService;
            this.logger = logger;
        }
        public async Task Convert(HttpContext context)
        {
            logger.LogInformation($"Path: /solve  Time: {DateTime.Now.ToLongTimeString()}");
            ConvertInputMessage? convertation = null;
            try
            {
                convertation = await context.Request.ReadFromJsonAsync<ConvertInputMessage>();
                if (convertation is null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    ConvertOutputMessage solvation = logicService.Convert(convertation,
                        context.RequestServices.GetRequiredService<IBaseConverter>());
                    logger.LogInformation(solvation.ToString());
                    await context.Response.WriteAsJsonAsync(solvation);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
