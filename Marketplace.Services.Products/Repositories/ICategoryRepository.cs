using Marketplace.Services.Products.Entities;

namespace Marketplace.Services.Products.Repositories;

public interface ICategoryRepository
{
    Task Create(Category category);
    Task Update(Category category);
    Task Delete(Category category);
    Task<Category> GetById(Guid id);
    Task<Category> GetCategories();
}
