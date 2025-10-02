using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAcces
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Register>? Registers { get; set; }
        public DbSet<Login>? Logins { get; set; }
        public DbSet<RefreshTokenEntities>? RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Login tablosu
            modelBuilder.Entity<Login>()
                .HasKey(l => l.Id);

            // RefreshTokenEntities tablosu
            modelBuilder.Entity<RefreshTokenEntities>()
                .HasKey(r => r.Id);

            // Register ile ilişkilendirme
            modelBuilder.Entity<RefreshTokenEntities>()
                .HasOne(r => r.User)                 // RefreshTokenEntities.User -> Register
                .WithMany(u => u.RefreshTokens)      // Register.RefreshTokens
                .HasForeignKey(r => r.UserId)        // FK
                .OnDelete(DeleteBehavior.Cascade);   // Kullanıcı silinirse tokenlar da silinsin

            // Login ile ilişkilendirme
            modelBuilder.Entity<RefreshTokenEntities>()
                .HasOne(r => r.Login)                // RefreshTokenEntities.Login -> Login
                .WithMany(l => l.RefreshTokens)      // Login.RefreshTokens
                .HasForeignKey(r => r.LoginId)       // FK
                .OnDelete(DeleteBehavior.SetNull);   // Login silinirse tokenlar null olur

            base.OnModelCreating(modelBuilder);
        }
    }
}
