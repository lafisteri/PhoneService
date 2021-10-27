using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ContextMsSql: DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<AccountInfo> Users { get; set; }

        public ContextMsSql(DbContextOptions<ContextMsSql> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<AccountInfo>()
                .OwnsOne(accountInfo => accountInfo.LoginInfo,
                navigationBuilder =>
                {
                    navigationBuilder.Property(loginInfo => loginInfo.Login)
                        .HasColumnName("Login");
                    navigationBuilder.Property(loginInfo => loginInfo.Password)
                        .HasColumnName("Password");
                });
        }
    }
}
