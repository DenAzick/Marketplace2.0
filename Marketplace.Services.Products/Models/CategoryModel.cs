namespace Marketplace.Services.Products.Models;

public class CategoryModel
{
    public required string Name { get; set; }

    public int? ParentId { get; set; }
}
