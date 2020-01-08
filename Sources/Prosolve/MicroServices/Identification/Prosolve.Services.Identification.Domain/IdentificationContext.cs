using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification.Users.DataSources;

using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Identification
{
    public class IdentificationContext: DbContext, IBoundedContext
    {
        public IdentificationContext(DbContextOptions<IdentificationContext> options)
            : base(options)
        {
            
        }

        public DbSet<UserDataModel>? Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // todo Как-то тут всё подозрительно работает, такое ощущение что оно НЕ РАБОТАЕТ
            builder.Entity<UserDataModel>().HasIndex(u => u.EmailAddress).IsUnique();
            builder.Entity<UserDataModel>().HasIndex(u => u.PhoneNumber).IsUnique();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // todo Вынести в файлы настроек строку подключения к БД.
                optionsBuilder.UseNpgsql(@"port=5432 dbname=watcher user=watcher password=watcher_password");
            }
        }
    }
}
