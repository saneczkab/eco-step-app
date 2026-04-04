using Microsoft.EntityFrameworkCore;

namespace EcoStepBackend.Crud;

public interface ISurveyCrud
{
    Task<User?> GetUserWithSurveysAndDataAsync(long userId);
    Task<User?> GetUserWithSurveysAsync(long userId);
    Task AddSurveyToUserAsync(User user, Survey survey);
}

public class SurveyCrud(AppDbContext db) : ISurveyCrud
{
    public Task<User?> GetUserWithSurveysAndDataAsync(long userId)
        => db.Users
            .Include(u => u.Surveys)
            .ThenInclude(s => s.FoodData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.ResourceData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.TransportData)
            .Include(u => u.Surveys)
            .ThenInclude(s => s.WasteData)
            .FirstOrDefaultAsync(u => u.Id == userId);

    public Task<User?> GetUserWithSurveysAsync(long userId)
        => db.Users
            .Include(u => u.Surveys)
            .FirstOrDefaultAsync(u => u.Id == userId);

    public async Task AddSurveyToUserAsync(User user, Survey survey)
    {
        user.Surveys.Add(survey);
        await db.SaveChangesAsync();
    }
}

