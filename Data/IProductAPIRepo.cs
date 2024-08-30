using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface IProductAPIRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(int Id);

        Task CreateProduct(Product product);

        Task UpdateProduct(Product product);

        void DeleteProduct(Product product);

        public Task<bool> SaveChangesAsync();
    }
}
