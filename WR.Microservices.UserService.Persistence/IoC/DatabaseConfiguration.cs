namespace WR.Microservices.UserService.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, UserServiceDbContext>();

        services.AddDbContextPool<UserServiceDbContext>(options =>
        {
            options.UseSqlite(connectionString: configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}