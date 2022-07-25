using WR.Consumers.Desktop.Infra.IoC;

namespace WR.Consumers.Desktop.Presentation;

public partial class App : System.Windows.Application
{
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
        // .NET Native DI Abstraction
        services.RegisterServices();

        // Add ViewModels
        services.AddViewModelsConfiguration();

        // MediatR
        services.AddMediatRConfiguration();
    }
}