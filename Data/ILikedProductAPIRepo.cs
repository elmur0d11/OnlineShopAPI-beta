using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface ILikedProductAPIRepo
    {
        Task<IEnumerable<LikedProduct>> GetAllProducts();

        Task<LikedProduct> GetProductById(int Id);

        Task CreateProduct(LikedProduct likedProduct);

        void DeleteProduct(LikedProduct likedProduct);

        public Task<bool> SaveChangesAsync();
    }
}
