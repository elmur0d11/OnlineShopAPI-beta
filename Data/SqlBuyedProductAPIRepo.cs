using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class SqlBuyedProductAPIRepo : IBuyedProductAPIRepo
    {
        private readonly ShopContext _context;
        public SqlBuyedProductAPIRepo(ShopContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(BuyedProduct buyedProduct)
        {
            if (buyedProduct == null)
                throw new ArgumentNullException(nameof(buyedProduct));
            
            var date = DateTime.UtcNow;
            buyedProduct.BuyedDate = date;
            await _context.BuyedProducts.AddAsync(buyedProduct);
        }

        public async Task<IEnumerable<BuyedProduct>> GetAllProducts()
        {
            return await _context.BuyedProducts.ToListAsync();
        }

        public async Task<BuyedProduct> GetProductById(int Id)
        {
            return await _context.BuyedProducts.FirstOrDefaultAsync(bproduct => bproduct.Id == Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
