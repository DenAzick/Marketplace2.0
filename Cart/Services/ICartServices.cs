using Cart.Entities;
using Cart.Models;

namespace Cart.Services
{
    public interface ICartServices
    {

        Task AddProductAsync(string key, CreateProductModel createProductModel);
        Task<List<Product>> GetUserCartAsync(string key);
        Task UpdateProductAsync(string key, UpdateProductModel updateProductModel);
        Task DeleteProductAsync(string key, string productId);
        Task DeleteUserCartAsync(string key);
    }
}
