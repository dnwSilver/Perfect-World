using Microsoft.EntityFrameworkCore;

namespace Prosolve.MicroService.Watcher.DataAccess
{
  public class WatcherContext :DbContext
  { 
    public DbSet<ProcessDataModel> Processes { get; set; }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // todo Вынести в файлы настроек строку подключения к БД.
      optionsBuilder.UseNpgsql(@"port=5432 dbname=watcher user=watcher password=watcher_password");
    }
  }
}
