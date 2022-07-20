namespace WR.Microservices.PetProjectService.Presentation.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        if (builder is null) throw new ArgumentNullException(paramName: nameof(builder));

        services.AddScoped<DbContext, PetProjectServiceDbContext>();

        services.AddDbContextPool<PetProjectServiceDbContext>(options =>
        {
            // Set Connection String

            options.UseSqlite(builder.Configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}