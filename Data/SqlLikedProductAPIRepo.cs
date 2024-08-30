using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class SqlLikedProductAPIRepo : ILikedProductAPIRepo
    {
        private readonly ShopContext _context;
        public SqlLikedProductAPIRepo(ShopContext context)
        {
            _context = context;
        }
        ////
        ////
        public async Task CreateProduct(LikedProduct likedProduct)
        {
            if (likedProduct == null)
                throw new ArgumentNullException(nameof(likedProduct));

            await _context.LikedProducts.AddAsync(likedProduct);
        }

        public void DeleteProduct(LikedProduct likedProduct)
        {
            if (likedProduct == null)
                throw new ArgumentNullException(nameof(likedProduct));

            _context.LikedProducts.Remove(likedProduct);
        }

        public async Task<IEnumerable<LikedProduct>> GetAllProducts()
        {
            return await _context.LikedProducts.ToListAsync();
        }

        public async Task<LikedProduct> GetProductById(int Id)
        {
            return await _context.LikedProducts.FirstOrDefaultAsync(Lproduct => Lproduct.Id == Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}
