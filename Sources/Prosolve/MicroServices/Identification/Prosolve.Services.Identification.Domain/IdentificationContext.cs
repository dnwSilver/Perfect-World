using Microsoft.EntityFrameworkCore;
using Prosolve.Services.Identification.Users.DataSources;
using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Identification
{
    // todo Где коменты еба?
    public class IdentificationContext : DbContext, IBoundedContext
    {
        public IdentificationContext(DbContextOptions<IdentificationContext> options)
            : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContactModel>().HasIndex(u => u.EmailAddress).IsUnique();
            builder.Entity<ContactModel>().HasIndex(u => u.PhoneNumber).IsUnique();

            builder.Entity<ContactModel>().HasOne(contact => contact.UserDataModel)
                .WithMany(user => user.ContactModels)
                .HasForeignKey(contact => contact.UserDataModelId);
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