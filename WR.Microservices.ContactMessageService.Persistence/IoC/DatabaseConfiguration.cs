namespace WR.Microservices.ContactMessageService.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ContactMessageServiceDbContext>();

        services.AddDbContextPool<ContactMessageServiceDbContext>(options =>
        {
            // Set Connection String

            options.UseSqlite(configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}