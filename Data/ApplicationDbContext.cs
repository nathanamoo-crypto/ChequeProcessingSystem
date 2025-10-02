using Microsoft.AspNetCore.Identity;
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

        // Configure relationships and rules
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ensure AccountNumber is unique
            builder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            // Configure Account → Cheque (1-to-many)
            builder.Entity<Cheque>()
                .HasOne(c => c.Account)           // A cheque belongs to an account
                .WithMany(a => a.Cheques)         // An account can have many cheques
                .HasForeignKey(c => c.AccountId)  // FK column
                .OnDelete(DeleteBehavior.Cascade);

            // Configure precision for money values
            builder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Cheque>()
                .Property(c => c.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
