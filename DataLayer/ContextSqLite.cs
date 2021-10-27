using System.IO;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DataLayer
{
    public class ContextSqLite : DbContext
    {
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Entities.Color> Color { get; set; }
        public DbSet<AccountInfo> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //https://docs.microsoft.com/en-gb/ef/core/cli/dotnet
            //dotnet tool install --global dotnet-ef --version 3.0.0
            //dotnet ef migrations add "comment"
            //dotnet ef database update

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={Directory.GetParent(Directory.GetCurrentDirectory()).FullName}/DataLayer/bin/Debug/netcoreapp3.1/PhoneServiceDB.sqlite");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<AccountInfo>()
                .OwnsOne(accountInfo => accountInfo.LoginInfo,
                nawigationBuilder =>
                {
                    nawigationBuilder.Property(loginInfo => loginInfo.Login)
                        .HasColumnName("Login");
                    nawigationBuilder.Property(loginInfo => loginInfo.Password)
                        .HasColumnName("Password");
                });
        }
    }
}
