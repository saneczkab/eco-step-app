using Microsoft.EntityFrameworkCore;

namespace EcoStepBackend.Crud;

public interface IAuthCrud
{
    Task<bool> UserExistsByNameAsync(string username);
    Task<User?> GetUserByNameAsync(string username);
    Task AddUserAsync(User user);
}

public class AuthCrud(AppDbContext db) : IAuthCrud
{
    public Task<bool> UserExistsByNameAsync(string username)
        => db.Users.AnyAsync(u => u.Name == username);

    public Task<User?> GetUserByNameAsync(string username)
        => db.Users.FirstOrDefaultAsync(u => u.Name == username);

    public async Task AddUserAsync(User user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
    }
}

