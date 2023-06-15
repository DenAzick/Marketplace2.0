using Marketplace.Services.Products.Entities;
using MongoDB.Driver;

namespace Marketplace.Services.Products.Repositories;

public interface IProductRepository
{
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
    Task<Product> GetProductById(Guid productId);
    Task<List<Product>> GetProducts();

}

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository()
    {
        var client = new MongoClient("mongodb://root:password@mongodb:27017");
        var database = client.GetDatabase("products");
        _products = database.GetCollection<Product>("products");
    }


    public async Task AddProduct(Product product)
    {
        await _products.InsertOneAsync(product);
    }

    public async Task DeleteProduct(Product product)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
        await _products.DeleteOneAsync(filter);
    }

    public async Task<Product> GetProductById(Guid productId)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);
        return await (await _products.FindAsync(filter)).FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetProducts()
    {
        return await (await _products.FindAsync(_ => true)).ToListAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
        await _products.ReplaceOneAsync(filter, product);
    }
}