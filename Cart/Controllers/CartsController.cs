﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Cart.Models;
using Cart.Providers;
using Cart.Services;
using Cart.Entities;

namespace Marketplace.Services.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ICartServices _cartService;
        private readonly UserProvider _userProvider;

        public CartsController(ICartServices cartService, UserProvider userProvider)
        {
            _cartService = cartService;
            _userProvider = userProvider;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductModel createProductModel)
        {
            await _cartService.AddProductAsync(_userProvider.UserId.ToString(), createProductModel);

            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<IActionResult> GetUserCart() =>
            Ok(await _cartService.GetUserCartAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value));

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductModel updateProductModel)
        {
            await _cartService.UpdateProductAsync(_userProvider.UserId.ToString(), updateProductModel);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            await _cartService.DeleteProductAsync(_userProvider.UserId.ToString(), productId);

            return Ok();
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUserCart()
        {
            await _cartService.DeleteUserCartAsync(_userProvider.UserId.ToString());

            return Ok();
        }


    }
}