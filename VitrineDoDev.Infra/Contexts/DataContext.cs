using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using VitrineDoDev.Domain.Account.Entities;
using VitrineDoDev.Domain.Developer.Entities;
using VitrineDoDev.Domain.Social.Entities;
using VitrineDoDev.Domain.Technologies.Entities;

namespace VitrineDoDev.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Programmer> Programmer { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.CellPhone).HasMaxLength(20).HasColumnType("varchar(20)");
            modelBuilder.Entity<User>().Property(x => x.PasswordHash);
            modelBuilder.Entity<User>().Property(x => x.PasswordSalt);

            modelBuilder.Entity<Programmer>().ToTable("Programmer");
            modelBuilder.Entity<Programmer>().HasKey(x => x.Id);
            modelBuilder.Entity<Programmer>().Property(x => x.Photo);
            modelBuilder.Entity<Programmer>().Property(x => x.Description).HasMaxLength(30).HasColumnType("varchar(30)");
            modelBuilder.Entity<Programmer>().Property(x => x.ActualPosition).HasMaxLength(30).HasColumnType("varchar(30)");
            modelBuilder.Entity<Programmer>().Property(x => x.HasJob);
            modelBuilder.Entity<Programmer>().Property(x => x.CompanyName).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<Programmer>().HasOne(x => x.User).WithOne(x => x.Programmer).HasForeignKey<User>(x => x.Id);

            modelBuilder.Entity<Technology>().ToTable("Technology");
            modelBuilder.Entity<Technology>().HasKey(x => x.Id);
            modelBuilder.Entity<Technology>().Property(x => x.Name).HasMaxLength(30).HasColumnType("varchar(30)");
            modelBuilder.Entity<Technology>().HasOne(p => p.Programmer).WithMany(x => x.Technologies);

            modelBuilder.Entity<SocialMedia>().ToTable("SocialMedia");
            modelBuilder.Entity<SocialMedia>().HasKey(x => x.Id);
            modelBuilder.Entity<SocialMedia>().Property(x => x.GitHub).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<SocialMedia>().Property(x => x.Linkedln).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<SocialMedia>().Property(x => x.Portfolio).HasMaxLength(50).HasColumnType("varchar(50)");
            modelBuilder.Entity<SocialMedia>().HasOne(x => x.Programmer).WithOne(x => x.SocialMedia).HasForeignKey<Programmer>(x => x.Id);



        }
    }
}
