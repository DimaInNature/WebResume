namespace WR.Consumers.Desktop.Presentation;

public partial class App : ThisApplication
{
    public IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceCollection services = new();

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        new LoginView().Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Configure IConfiguration (^_^)
        services.AddConfigurationFrom(path: "appsettings.json");

        // .NET Native DI Abstraction
        services.RegisterServices();

        // Add ViewModels
        services.AddViewModelsConfiguration();

        // MediatR
        services.AddMediatRConfiguration();
    }
}