using Marketplace.Services.Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Services.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductModel model)
    {

    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(CreateProductModel model)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(CreateProductModel model)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetProductsById(CreateProductModel model)
    {

    }

    [HttpDelete]
    public async Task DeleteProduct()
    {

    }

}
