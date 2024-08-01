using BankWebAPIVS.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankWebAPIVS
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .ToTable(amount => amount.HasCheckConstraint("CKTransactionAmount", "Amount > 0.0"));

            modelBuilder.Entity<Transaction>()
                .Property(t => t.DateAndTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
