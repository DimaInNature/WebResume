namespace WR.Consumers.Desktop.Presentation;

public partial class App : ThisApplication
{
    public IConfiguration Configuration { get; private set; } =
        new ConfigurationBuilder()
        .SetBasePath(basePath: Directory.GetCurrentDirectory())
        .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    public IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(services: serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        new LoginView().Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);

        // .NET Native DI Abstraction
        services.RegisterServices();

        // Add ViewModels
        services.AddViewModelsConfiguration();

        // MediatR
        services.AddMediatRConfiguration();
    }
}