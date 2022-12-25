using static JSONAmveraAPIApp.Messages.Messages;

namespace JSONAmveraAPIApp.Services
{
    public class MainLogicService
    {
        public async Task<InfoMessage> GetServerInfo()
        {
            InfoMessage info = new InfoMessage();
            return info;
        }
        public async Task<StatusMessage> GetServerStatus()
        {
            StatusMessage status = new StatusMessage();
            status.ServerName = Environment.MachineName;
            status.CPUCores = Environment.ProcessorCount;
            status.OCVersion = Environment.OSVersion;
            status.HostName = System.Net.Dns.GetHostName();
            return status;
        }
    }
}
