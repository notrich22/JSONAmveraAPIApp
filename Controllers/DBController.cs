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
        private ILogger<DBController> logger;
        public DBController(ILogger<DBController> logger)
        {
            this.logger = logger;
        }

        public async Task<bool> isUserNew(HttpContext context)
        {
            try
            {
                using (var db =new PostgreSQLDBContext())
                {
                    foreach(var host in await db.KnownHosts.ToListAsync())
                    {
                        if(host.IP == context.Request.Headers.Host)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
                return false;
            }
        }
        public async Task<KnownHost> AddHost(HttpContext context)
        {
            try { 
                KnownHost host = new KnownHost
                {
                    HostName = "host",
                    IP = context.Request.Headers.Host.ToString()
                };
                using (var db = new PostgreSQLDBContext())
                {
                    await db.KnownHosts.AddAsync(host);
                    await db.SaveChangesAsync();
                }
                return host;
            }
            catch(Exception ex) {
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
                return null;
            }
        }
        public async Task<Request> AddRequest(HttpContext context)
        {
            try { 
                using (var db = new PostgreSQLDBContext())
                {
                    Request request = new Request()
                    {
                        KnownHost = await db.KnownHosts.FirstOrDefaultAsync(n => n.IP == context.Request.Headers.Host.ToString()),
                        isHttps = context.Request.IsHttps,
                        Path = context.Request.Path


                    };
            
                    await db.Requests.AddAsync(request);
                    await db.SaveChangesAsync();
                    return request;
                }
            }catch(Exception ex) { 
                ErrorMessage error = new ErrorMessage(ex);
                logger.LogError(error.ToString());
                return null;
            }
        }
    }
}
