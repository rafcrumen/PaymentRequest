using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<PaymentRequestModel> PaymentRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentRequestModel>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2); // 18 dígitos, 2 decimales

        }
    }
}
