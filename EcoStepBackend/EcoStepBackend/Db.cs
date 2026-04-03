using Microsoft.EntityFrameworkCore;

namespace EcoStepBackend;

public class AppDbContext : DbContext
{
    public string DbPath { get; }

    public AppDbContext()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        var index = currentDirectory.LastIndexOf("bin");
        if (index != -1)
            currentDirectory = currentDirectory[..index];

        DbPath = Path.Join(currentDirectory, "main.db");
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
    }

}
