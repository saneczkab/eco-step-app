using EcoStepBackend.Crud;

namespace EcoStepBackend.Services;

public interface IUserService
{
    Task<User?> GetUserAsync(long id);
    Task<Household?> UpdateHouseholdAsync(long id, Household updated);
}

public class UserService(IUserCrud userCrud) : IUserService
{
    public Task<User?> GetUserAsync(long id)
        => userCrud.GetUserWithHouseholdByIdAsync(id);

    public async Task<Household?> UpdateHouseholdAsync(long id, Household updated)
    {
        var user = await userCrud.GetUserWithHouseholdByIdAsync(id);
        if (user is null)
            return null;

        return await userCrud.UpsertHouseholdAsync(user, updated);
    }
}

