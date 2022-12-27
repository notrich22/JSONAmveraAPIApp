
using JSONAmveraAPIApp.Controllers;
using JSONAmveraAPIApp.Services;

namespace JSONAmveraAPIApp
{
    public class Middleware
    {
        private readonly RequestDelegate next;
        public Middleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var dbController = context.RequestServices.GetRequiredService<DBController>();
            if (await dbController.isUserNew(context))
            {
                await dbController.AddHost(context);
            }
            await dbController.AddRequest(context);
            await next.Invoke(context);
        }
    }
}

