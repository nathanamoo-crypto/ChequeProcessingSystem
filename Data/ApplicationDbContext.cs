using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChequeProcessingSystem.Models;

namespace ChequeProcessingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables in the database
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        // Optional: configure relationships and rules
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Example: ensure AccountNumber is unique
            builder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            // Example: relationship (Cheque belongs to an Account)
            builder.Entity<Cheque>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(c => c.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
