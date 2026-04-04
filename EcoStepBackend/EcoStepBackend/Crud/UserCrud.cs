using Microsoft.EntityFrameworkCore;

namespace EcoStepBackend.Crud;

public interface IUserCrud
{
    Task<User?> GetUserWithHouseholdByIdAsync(long id);
    Task<User?> GetUserWithHouseholdAndSurveysByIdAsync(long id);
    Task<Household> UpsertHouseholdAsync(User user, Household updated);
}

public class UserCrud(AppDbContext db) : IUserCrud
{
    public Task<User?> GetUserWithHouseholdByIdAsync(long id)
        => db.Users
            .Include(u => u.Household)
            .FirstOrDefaultAsync(u => u.Id == id);

    public Task<User?> GetUserWithHouseholdAndSurveysByIdAsync(long id)
        => db.Users
            .Include(u => u.Household)
            .Include(u => u.Surveys)
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<Household> UpsertHouseholdAsync(User user, Household updated)
    {
        if (user.Household is null)
        {
            user.Household = updated;
        }
        else
        {
            updated.Id = user.Household.Id;
            db.Entry(user.Household).CurrentValues.SetValues(updated);
        }

        await db.SaveChangesAsync();
        return user.Household ?? updated;
    }
}

