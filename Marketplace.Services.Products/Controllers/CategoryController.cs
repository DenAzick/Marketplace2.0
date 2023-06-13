using Marketplace.Services.Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Services.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateProductModel model)
    {

    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(CreateProductModel model)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetCategories(CreateProductModel model)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesById(CreateProductModel model)
    {

    }

    [HttpDelete]
    public async Task DeleteCategory()
    {

    }
}
