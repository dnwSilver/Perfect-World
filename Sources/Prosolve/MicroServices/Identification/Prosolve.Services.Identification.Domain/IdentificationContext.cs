using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification.Users.DataSources;

using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Identification
{
    internal class IdentificationContext: DbContext, IBoundedContext
    {
        public IdentificationContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<UserDataModel>? Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // todo Как-то тут всё подозрительно работает, такое ощущение что оно НЕ РАБОТАЕТ
            // https://entityframeworkcore.com/knowledge-base/49526370/is-there-a-data-annotation-for-unique-constraint-in-ef-core--code-first--
            
            builder.Entity<UserDataModel>().HasIndex(u => u.EmailAddress).IsUnique();
            builder.Entity<UserDataModel>().HasIndex(u => u.PhoneNumber).IsUnique();
        }
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
