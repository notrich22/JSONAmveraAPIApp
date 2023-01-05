using JsonAmveraConvertationApiApp.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace JsonAmveraConvertationApiApp.Model
{
    public class PostgreSQLDBContext : DbContext
    {
        public DbSet<KnownHost> KnownHosts { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            string connectionStringKey = configuration.GetSection("UseConnection").Value;
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(connectionStringKey));
        }
    }
}
