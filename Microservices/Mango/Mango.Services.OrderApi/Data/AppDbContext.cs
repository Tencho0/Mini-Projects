namespace Mango.Services.OrderApi.Data
{
    using Mango.Services.OrderApi.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<OrderHeader> CartHeaders { get; set; }
        public DbSet<OrderDetails> CartDetails { get; set; }
    }
}
