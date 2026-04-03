using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EcoStepBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext db, IConfiguration config, ILogger<SurveyController> logger) : ControllerBase
{
    private readonly PasswordHasher<User> _passwordHasher = new();

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] string username, [FromForm] string password)
    {
        var exists = await db.Users.AnyAsync(u => u.Name == username);
        if (exists)
            return BadRequest("User already exists.");

        var user = new User
        {
            Name = username,
            PasswordHash = _passwordHasher.HashPassword(null!, password)
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        return Ok(new { UserId = user.Id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Name == username);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed)
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token, UserId = user.Id });
    }

    [Authorize]
    [HttpGet("profile/{id:long}")]
    public async Task<IActionResult> Profile(long id)
    {
        var user = await db.Users
            .Include(u => u.Household)
            .Include(u => u.Surveys)
            .FirstOrDefaultAsync(u => u.Id == id);

        logger.LogInformation("Method: Profile | UserId: {UserId} | Time: {Time}", id, DateTime.UtcNow);
        return user == null ? NotFound() : Ok(user);
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
