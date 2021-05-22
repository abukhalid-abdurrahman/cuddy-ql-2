using Transactions.Model;
using Microsoft.EntityFrameworkCore;

namespace Transactions.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Transaction>()
                .HasMany(t => t.TransactionHistories)
                .WithOne(t => t.Transaction!)
                .HasForeignKey(t => t.TransactionId);
            
            modelBuilder
                .Entity<TransactionHistory>()
                .HasOne(t => t.Transaction)
                .WithMany(p => p.TransactionHistories)
                .HasForeignKey(t => t.TransactionId);
            base.OnModelCreating(modelBuilder);
        }
    }
}