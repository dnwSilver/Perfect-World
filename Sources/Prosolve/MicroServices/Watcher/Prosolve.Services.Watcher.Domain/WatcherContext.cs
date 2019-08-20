using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Watcher.Domain.Processes.DataSources;

using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Watcher.Domain
{
    public class WatcherContext : DbContext, IBoundedContext
    {
        public WatcherContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<ProcessDataModel> Processes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // todo Вынести в файлы настроек строку подключения к БД.
                optionsBuilder.UseNpgsql(
                    @"port=5432 dbname=watcher user=watcher password=watcher_password");
            }
        }
    }
}
