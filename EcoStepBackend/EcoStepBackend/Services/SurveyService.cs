using EcoStepBackend.Crud;
using EcoStepBackend.Validators;

namespace EcoStepBackend.Services;

public interface ISurveyService
{
    Task<ICollection<Survey>?> GetAllSurveysAsync(long userId);
    Task<IEnumerable<Survey>?> GetLastWeekSurveysAsync(long userId);
    Task<Survey?> CreateSurveyAsync(Survey survey);
}

public class SurveyService(
    ISurveyCrud surveyCrud,
    ISurveyDataValidator<FoodData> foodValidator,
    ISurveyDataValidator<ResourceData> resourceValidator,
    ISurveyDataValidator<TransportData> transportValidator,
    ISurveyDataValidator<WasteData> wasteValidator
) : ISurveyService
{
    public async Task<ICollection<Survey>?> GetAllSurveysAsync(long userId)
    {
        var user = await surveyCrud.GetUserWithSurveysAndDataAsync(userId);
        return user?.Surveys;
    }

    public async Task<IEnumerable<Survey>?> GetLastWeekSurveysAsync(long userId)
    {
        var user = await surveyCrud.GetUserWithSurveysAndDataAsync(userId);
        return user?.Surveys
            .OrderByDescending(s => s.CompletedAt)
            .Where(s => s.CompletedAt >= DateTime.UtcNow.AddDays(-7));
    }

    public async Task<Survey?> CreateSurveyAsync(Survey survey)
    {
        survey.CompletedAt = DateTime.UtcNow;

        var user = await surveyCrud.GetUserWithSurveysAsync(survey.UserId);
        if (user is null)
            return null;

        ValidateSurvey(user, survey);
        await surveyCrud.AddSurveyToUserAsync(user, survey);
        return survey;
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

