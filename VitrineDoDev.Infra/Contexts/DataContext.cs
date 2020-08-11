using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using VitrineDoDev.Domain.Account.Entities;

namespace VitrineDoDev.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.PasswordHash);
            modelBuilder.Entity<User>().Property(x => x.PasswordSalt);
        }
    }
}
