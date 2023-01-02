using JSONAmveraAPIApp.Model;
using JSONAmveraAPIApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace JSONAmveraAPIApp.Services
{
    public class DBLogicService
    {
        public async Task<bool> isUserNew(string IP)
        {
            using (var db = new PostgreSQLDBContext())
            {
                foreach (var host in await db.KnownHosts.ToListAsync())
                {
                    if (host.IP == IP)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        //Host CRUD
        public async Task<KnownHost> AddHost(KnownHost knownHost)
        {
            using (var db = new PostgreSQLDBContext())
            {
                await db.KnownHosts.AddAsync(knownHost);
                await db.SaveChangesAsync();
                return knownHost;
            }
        }
        public async Task<List<KnownHost>> GetHosts()
        {
            using (var db = new PostgreSQLDBContext())
            {
                return await db.KnownHosts.ToListAsync();
            }
        }
        public async Task<KnownHost> GetHost(int id)
        {
            using (var db = new PostgreSQLDBContext())
            {
                return await db.KnownHosts.FirstOrDefaultAsync(n=>n.Id==id);
            }
        }
        public async Task<KnownHost> UpdateHost(int id, KnownHost host)
        {
            using (var db = new PostgreSQLDBContext())
            {
                KnownHost oldHost = await db.KnownHosts.FirstOrDefaultAsync(n=>n.Id ==id);
                oldHost.IP = host.IP;
                oldHost.UserAgent = host.UserAgent;
                await db.SaveChangesAsync();
                return oldHost;
            }
        }
        public async Task DeleteHost(int id)
        {
            using (var db = new PostgreSQLDBContext())
            {
                db.KnownHosts.Remove(await db.KnownHosts.FirstOrDefaultAsync(n=>n.Id == id));
                await db.SaveChangesAsync();
            }
        }
        //Request CRUD
        public async Task<Request> AddRequest(string IP, bool isHttps, string Path)
        {
            using (var db = new PostgreSQLDBContext())
            {
                Request request = new Request()
                {
                    KnownHost = await db.KnownHosts.FirstOrDefaultAsync(n => n.IP == IP),
                    isHttps = isHttps,
                    Path = Path
                };

                await db.Requests.AddAsync(request);
                await db.SaveChangesAsync();
                return request;
            }
        }
        
        public async Task<List<Request>> GetRequests()
        {
            using(var db = new PostgreSQLDBContext())
            {
                return await db.Requests.Include(n => n.KnownHost).ToListAsync();
            }
        }
        public async Task<Request> GetRequest(int id)
        {
            using (var db = new PostgreSQLDBContext())
            {
                return await db.Requests.FirstOrDefaultAsync(n => n.Id == id);
            }
        }
        public async Task<Request> UpdateRequest(int id, Request request)
        {
            using (var db = new PostgreSQLDBContext())
            {
                Request oldRequest = await db.Requests.FirstOrDefaultAsync(n => n.Id == id);
                oldRequest.KnownHost = request.KnownHost;
                oldRequest.isHttps = request.isHttps;
                oldRequest.Path = request.Path;
                await db.SaveChangesAsync();
                return oldRequest;
            }
        }
        public async Task DeleteRequest(int id)
        {
            using (var db = new PostgreSQLDBContext())
            {
                db.Requests.Remove(await db.Requests.FirstOrDefaultAsync(n => n.Id == id));
                await db.SaveChangesAsync();
            }
        }
        public async Task<List<Request>> GetRequestsByHost(string IP)
        {
            using (var db = new PostgreSQLDBContext())
            {
                List<Request> requests = await db.Requests.Where(n => n.KnownHost == db.KnownHosts.FirstOrDefault(n => n.IP == IP)).Include(n=>n.KnownHost).ToListAsync();
                return requests;
            }
        }
    }
}
