using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Prosolve.Services.Identification
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentificationContextFactory: IDesignTimeDbContextFactory<IdentificationContext>
    {
        public IdentificationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentificationContext>();

            if (!optionsBuilder.IsConfigured)
            {
                // todo Вынести в файлы настроек строку подключения к БД.
                optionsBuilder.UseNpgsql(@"port=5432 dbname=watcher user=watcher password=watcher_password");
            }

            return new IdentificationContext(optionsBuilder.Options);
        }
    }
}
