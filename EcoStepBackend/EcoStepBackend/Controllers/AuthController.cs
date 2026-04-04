using EcoStepBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoStepBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] string username, [FromForm] string password)
    {
        var userId = await authService.RegisterAsync(username, password);
        if (userId is null)
            return BadRequest("User already exists.");

        return Ok(new { UserId = userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
    {
        var result = await authService.LoginAsync(username, password);
        if (result is null)
            return Unauthorized("Invalid credentials");

        return Ok(new { result.Value.Token, result.Value.UserId });
    }

    [Authorize]
    [HttpGet("profile/{id:long}")]
    public async Task<IActionResult> Profile(long id)
    {
        var user = await authService.GetProfileAsync(id);

        logger.LogInformation("Method: Profile | UserId: {UserId} | Time: {Time}", id, DateTime.UtcNow);
        return user == null ? NotFound() : Ok(user);
    }
}
