namespace WR.Consumers.Desktop.Presentation.Configurations;

public static class ViewModelsConfiguration
{
    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddTransient<LoginViewModel>();
    }
}