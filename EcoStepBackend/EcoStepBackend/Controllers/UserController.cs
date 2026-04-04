using EcoStepBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoStepBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetUser(long id)
    {
        var user = await userService.GetUserAsync(id);

        if (user is null)
            return NotFound();

        logger.LogInformation("Method: GetUser | UserId: {UserId} | Time: {Time}", id, DateTime.UtcNow);
        return Ok(user);
    }

    [HttpPut("{id:long}/household")]
    public async Task<IActionResult> UpdateHousehold(long id, [FromBody] Household updated)
    {
        var household = await userService.UpdateHouseholdAsync(id, updated);
        if (household is null)
            return NotFound();

        return Ok(household);
    }
}
