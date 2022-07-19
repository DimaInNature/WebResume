namespace WR.Microservices.ContactMessageService.Presentation.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        if (builder is null) throw new ArgumentNullException(nameof(builder));

        services.AddScoped<DbContext, ContactMessageServiceDbContext>();

        services.AddDbContextPool<ContactMessageServiceDbContext>(options =>
        {
            // Set Connection String

            options.UseSqlite(builder.Configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}