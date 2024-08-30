using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface IBuyedProductAPIRepo
    {
        Task<IEnumerable<BuyedProduct>> GetAllProducts();

        Task<BuyedProduct> GetProductById(int Id);

        Task CreateProduct(BuyedProduct buyedProduct);

        public Task<bool> SaveChangesAsync();
    }
}
