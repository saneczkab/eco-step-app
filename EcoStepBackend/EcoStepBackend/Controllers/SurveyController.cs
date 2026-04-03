using EcoStepBackend.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoStepBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveyController(
    AppDbContext db,
    ISurveyDataValidator<FoodData> foodValidator,
    ISurveyDataValidator<ResourceData> resourceValidator,
    ISurveyDataValidator<TransportData> transportValidator,
    ISurveyDataValidator<WasteData> wasteValidator,
    ILogger<SurveyController> logger
) : ControllerBase
{
    [HttpGet("{userId:long}")]
    public IActionResult GetAllSurveys(long userId)
    {
        var user = db.Users
            .Include(u => u.Surveys)
            .ThenInclude(s => s.FoodData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.ResourceData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.TransportData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.WasteData)
            .FirstOrDefault(u => u.Id == userId);

        if (user is null)
            return NotFound();

        logger.LogInformation("Method: GetAllSurveys | UserId: {UserId} | Time: {Time}", userId, DateTime.UtcNow);
        return Ok(user.Surveys);
    }

    [HttpGet("{userId:long}/last-week-surveys")]
    public IActionResult GetLastWeekSurveys(long userId)
    {
        var user = db.Users
            .Include(u => u.Surveys)
            .ThenInclude(s => s.FoodData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.ResourceData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.TransportData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.WasteData)
            .FirstOrDefault(u => u.Id == userId);

        if (user is null)
            return NotFound();

        var lastSurvey = user.Surveys
            .OrderByDescending(s => s.CompletedAt)
            .Where(s => s.CompletedAt >= DateTime.UtcNow.AddDays(-7));

        logger.LogInformation("Method: GetLastWeekSurveys | UserId: {UserId} | Time: {Time}", userId, DateTime.UtcNow);
        return Ok(lastSurvey);
    }

    [HttpPost]
    public IActionResult CreateSurvey([FromBody] Survey survey)
    {
        survey.CompletedAt = DateTime.UtcNow;
        var userId = survey.UserId;

        var user = db.Users
            .Include(u => u.Surveys)
            .FirstOrDefault(u => u.Id == userId);

        if (user is null)
            return NotFound();

        ValidateSurvey(user, survey);
        user.Surveys.Add(survey);
        db.SaveChanges();

        logger.LogInformation("Method: CreateSurvey | UserId: {UserId} | Time: {Time}", survey.UserId, DateTime.UtcNow);
        return CreatedAtAction(nameof(GetAllSurveys), new { userId = survey.UserId }, survey);
    }

    private void ValidateSurvey(User user, Survey survey)
    {
        var days = survey.ReportedDays;

        foodValidator.Validate(user, survey.FoodData, days);
        resourceValidator.Validate(user, survey.ResourceData, days);
        transportValidator.Validate(user, survey.TransportData, days);
        wasteValidator.Validate(user, survey.WasteData, days);
    }
}
