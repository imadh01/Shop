using Microsoft.EntityFrameworkCore;
using Shop.DataHub.Models.Domain;

namespace Shop.DataHub
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext>dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
