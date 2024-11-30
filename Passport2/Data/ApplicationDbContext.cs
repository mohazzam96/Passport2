using Microsoft.EntityFrameworkCore;
using Passport2.Models;

namespace Passport2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<PassportApplication> PassportApplications { get; set; }
        public DbSet<Residency> Residencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
 
    // Configure UserDetails - Residency relationship (one-to-many)
    modelBuilder.Entity<UserDetails>()
        .HasMany(u => u.Residencies)
        .WithOne(r => r.UserDetails)
        .HasForeignKey(r => r.ResidencyID)
        .OnDelete(DeleteBehavior.SetNull);

            // Configure UserDetails - PassportApplication relationship (one-to-many)
            modelBuilder.Entity<UserDetails>()
                .HasMany(u => u.PassportApplications)
                .WithOne(p => p.UserDetails)
                .HasForeignKey(p => p.UserDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add unique constraint on Email in UserDetails
            modelBuilder.Entity<UserDetails>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configure PassportApplication properties
            modelBuilder.Entity<PassportApplication>()
                .Property(p => p.Status)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<PassportApplication>()
                .Property(p => p.DateOfApplication)
                .HasDefaultValueSql("GETDATE()");

            // Configure Residency properties
            modelBuilder.Entity<Residency>()
                .Property(r => r.Address)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
