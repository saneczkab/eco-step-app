using EcoStepBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoStepBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveyController(
    ISurveyService surveyService,
    ILogger<SurveyController> logger
) : ControllerBase
{
    [HttpGet("{userId:long}")]
    public async Task<IActionResult> GetAllSurveys(long userId)
    {
        var surveys = await surveyService.GetAllSurveysAsync(userId);
        if (surveys is null)
            return NotFound();

        logger.LogInformation("Method: GetAllSurveys | UserId: {UserId} | Time: {Time}", userId, DateTime.UtcNow);
        return Ok(surveys);
    }

    [HttpGet("{userId:long}/last-week-surveys")]
    public async Task<IActionResult> GetLastWeekSurveys(long userId)
    {
        var surveys = await surveyService.GetLastWeekSurveysAsync(userId);
        if (surveys is null)
            return NotFound();

        logger.LogInformation("Method: GetLastWeekSurveys | UserId: {UserId} | Time: {Time}", userId, DateTime.UtcNow);
        return Ok(surveys);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSurvey([FromBody] Survey survey)
    {
        var createdSurvey = await surveyService.CreateSurveyAsync(survey);
        if (createdSurvey is null)
            return NotFound();

        logger.LogInformation("Method: CreateSurvey | UserId: {UserId} | Time: {Time}", survey.UserId, DateTime.UtcNow);
        return CreatedAtAction(nameof(GetAllSurveys), new { userId = createdSurvey.UserId }, createdSurvey);
    }
}
