var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddCors();

    // Setting DBContext
    services.AddDatabaseConfiguration(builder);

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

    app.UseStaticFiles();

    app.MapControllers();

    app.UseSwaggerSetup();
}