using JSONAmveraAPIApp.Model;
using JSONAmveraAPIApp.Model.Entities;
using JSONAmveraAPIApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Controllers
{
    public class DBController
    {
        private DBLogicService logicService;
        private ILogger<DBController> logger;
        public DBController(ILogger<DBController> logger, DBLogicService logicService)
        {
            this.logger = logger;
            this.logicService = logicService;
        }

        public async Task<bool> isUserNew(HttpContext context)
        {
            try
            {
                bool isNew = await logicService.isUserNew(context.Connection.RemoteIpAddress.ToString());
                return isNew;
            }
            catch (Exception ex)
            {
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
                return false;
            }
        }
        public async Task AddHost(HttpContext context)
        {
            try {
                KnownHost knownHost = new KnownHost() {
                    IP= context.Connection.RemoteIpAddress.ToString(),
                    UserAgent= context.Request.Headers.UserAgent.ToString()
                };
                await logicService.AddHost(knownHost);
            }
            catch(Exception ex) {
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
            }
        }
        public async Task AddRequest(HttpContext context)
        {
            try {
                Request request = new Request();
                request.KnownHost = await logicService.GetHostByÌP(context.Connection.RemoteIpAddress.ToString());
                request.isHttps = context.Request.IsHttps;
                request.Path = context.Request.Path;
                logicService.AddRequest(request.KnownHost.IP, request);
            }catch(Exception ex) { 
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
            }
        }
        public async Task GetHosts(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await logicService.GetHosts());
        }
        public async Task GetRequests(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await logicService.GetRequests());
        }

        public async Task GetRequestsByHost(HttpContext context)
        {
            IPMessage IP = await context.Request.ReadFromJsonAsync<IPMessage>();
            await context.Response.WriteAsJsonAsync(await logicService.GetRequestsByHost(IP.IP));
        }
    }
}
