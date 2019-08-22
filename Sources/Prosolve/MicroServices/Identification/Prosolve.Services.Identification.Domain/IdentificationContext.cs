using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification.Entities.Users.DataSources;

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
            builder.Entity<UserDataModel>()
                   .HasIndex(u => u.EmailAddress)
                   .IsUnique();
            
            builder.Entity<UserDataModel>()
                   .HasIndex(u => u.PhoneNumber)
                   .IsUnique();
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
