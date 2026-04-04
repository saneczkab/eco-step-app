using EcoStepBackend.Crud;
using Microsoft.AspNetCore.Identity;

namespace EcoStepBackend.Services;

public interface IAuthService
{
    Task<int?> RegisterAsync(string username, string password);
    Task<(string Token, int UserId)?> LoginAsync(string username, string password);
    Task<User?> GetProfileAsync(long id);
}

public class AuthService(
    IAuthCrud authCrud,
    IUserCrud userCrud,
    IJwtTokenService jwtTokenService
) : IAuthService
{
    private readonly PasswordHasher<User> _passwordHasher = new();

    public async Task<int?> RegisterAsync(string username, string password)
    {
        var exists = await authCrud.UserExistsByNameAsync(username);
        if (exists)
            return null;

        var user = new User
        {
            Name = username,
            PasswordHash = _passwordHasher.HashPassword(null!, password)
        };

        await authCrud.AddUserAsync(user);
        return user.Id;
    }

    public async Task<(string Token, int UserId)?> LoginAsync(string username, string password)
    {
        var user = await authCrud.GetUserByNameAsync(username);
        if (user is null)
            return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed)
            return null;

        var token = jwtTokenService.Generate(user);
        return (token, user.Id);
    }

    public Task<User?> GetProfileAsync(long id)
        => userCrud.GetUserWithHouseholdAndSurveysByIdAsync(id);
}

