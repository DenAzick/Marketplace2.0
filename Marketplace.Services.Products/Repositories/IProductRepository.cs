using Marketplace.Services.Products.Entities;

namespace Marketplace.Services.Products.Repositories;

public interface IProductRepository
{
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Product product);
    Task<Product> GetById(Guid id);
    Task<Product> GetProducts();

}
