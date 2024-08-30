using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class SqlProductAPIRepo : IProductAPIRepo
    {
        private readonly ShopContext _context;
        public SqlProductAPIRepo(ShopContext context) 
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));

            await _context.Products.AddAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(product =>  product.Id == Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task UpdateProduct(Product product)
        {
           ////
        }

    }
}
