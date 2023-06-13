namespace Marketplace.Services.Products.Models;

public class ProductModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}
