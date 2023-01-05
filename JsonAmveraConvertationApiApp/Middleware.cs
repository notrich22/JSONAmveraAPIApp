using JsonAmveraConvertationApiApp.Controllers;
using JsonAmveraConvertationApiApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonAmveraConvertationApiApp
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

