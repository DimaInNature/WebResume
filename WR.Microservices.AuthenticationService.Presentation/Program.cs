var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.Configure<ApplicationSettingsModel>(configuration);

    // Jwt Auth
    services.AddAuthentication(builder);

    services.AddCors();

    // Swagger
    services.AddSwaggerConfiguration();

    // .NET Native DI Abstraction
    services.RegisterServices();

    // MediatR
    services.AddMediatRConfiguration();

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();

    app.UseCors(cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
    });

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.UseSwaggerSetup();
}