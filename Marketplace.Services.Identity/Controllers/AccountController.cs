﻿using Marketplace.Services.Identity.Managers;
using Marketplace.Services.Identity.Models;
using Marketplace.Services.Identity.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Services.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager _userManager;
    private ILogger<AccountController> _logger;
    private readonly UserProvider _userProvider;

    public AccountController(
	    UserManager userManager,
	    ILogger<AccountController> logger,
	    UserProvider userProvider)
    {
        _userManager = userManager;
        _logger = logger;
        _userProvider = userProvider;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserModel createUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.Register(createUserModel);

        return Ok(new UserModel(user));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var token = await _userManager.Login(loginUserModel);

        return Ok(new { Token = token });
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = _userProvider.UserId;
                
        var user = await _userManager.GetUser(userId);
        if (user == null)
        {
            return Unauthorized();
        }

        return Ok(new UserModel(user));
    }

    //[HttpPut("update")]
    //[Authorize]
    //public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserModel updateUserModel)
    //{
    //    var userId = _userProvider.UserId;
    //    var user = await _userManager.GetUser(userId);

    //    if (user == null)
    //    {
    //        return NotFound();
    //    }
            

    //    var updatedUser = await _userManager.UpdateUser(updateUserModel, user);

       

    //    return Ok(new UserModel(updatedUser));
    //}

    [HttpGet("{userName}")]
    public async Task<IActionResult> GetUser(string userName)
    {
	    var user = await _userManager.GetUser(userName);
	    if (user == null)
	    {
		    return NotFound();
	    }

	    return Ok(new UserModel(user));
    }
}

public class UserSession
{
    public bool IsSignedIn { get; set; }
    // Add other user-related properties as needed
}