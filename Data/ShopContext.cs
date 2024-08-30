using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        //DBSets
        public DbSet<Product> Products { get; set; }
        public DbSet<BuyedProduct> BuyedProducts { get; set;}
        public DbSet<LikedProduct> LikedProducts { get; set;}
    }
}
