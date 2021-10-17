using System.IO;
using Microsoft.EntityFrameworkCore;
using PhonesCore.Models;

namespace PhonesDataLayer
{
    public class Context : DbContext
    {
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Entities.Color> Color { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //https://docs.microsoft.com/en-gb/ef/core/cli/dotnet
            //dotnet ef migrations add "comment"
            //dotnet ef database update

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={Directory.GetParent(Directory.GetCurrentDirectory()).FullName}/PhonesDataLayer/bin/Debug/netcoreapp3.1/PhoneServiceDB.sqlite");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(p => p.Id);
            });
        }
    }
}
