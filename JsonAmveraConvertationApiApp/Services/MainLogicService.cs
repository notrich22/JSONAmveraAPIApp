using static JsonAmveraConvertationApiApp.Messages.Messages;

namespace JsonAmveraConvertationApiApp.Services
{
    public class MainLogicService
    {
        public async Task<InfoMessage> GetServerInfo()
        {
            return new InfoMessage();
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
