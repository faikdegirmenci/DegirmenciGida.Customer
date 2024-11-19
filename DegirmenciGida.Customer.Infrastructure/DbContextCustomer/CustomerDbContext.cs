using DegirmenciGida.Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace DegirmenciGida.Customer.Infrastructure
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
