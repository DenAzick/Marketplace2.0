using Marketplace.Services.Products.Entities;
using Marketplace.Services.Products.Models;
using Marketplace.Services.Products.Repositories;

namespace Marketplace.Services.Products.Managers;

public class ProductManager
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Product> Create(CreateProductModel create)
    {
        if (true)
        {

        }

        var product = new Product()
        { 
            Name = create.Name,
            Description = create.Description,
            Price = create.Price,
        };
        _productRepository.Create(product);
        return product;
    }
    public async Task<Product> Update(CreateProductModel create)
    {
        if (true)
        {

        }

        var product = new Product()
        {
            Name = create.Name,
            Description = create.Description,
            Price = create.Price,
        };
        _productRepository.Update(product);
        return product;
    }

}
