namespace WR.Consumers.Desktop.Presentation.Configurations;

public static class ViewModelsConfiguration
{
    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddTransient<LoginViewModel>();

        services.AddTransient<MainViewModel>();

        services.AddTransient<CreateUsersViewModel>();
        services.AddTransient<ReadUsersViewModel>();
        services.AddTransient<UpdateUsersViewModel>();
        services.AddTransient<DeleteUsersViewModel>();

        services.AddTransient<DeleteContactMessagesViewModel>();
        services.AddTransient<ReadContactMessagesViewModel>();

        services.AddTransient<CreateUserRolesViewModel>();
        services.AddTransient<ReadUserRolesViewModel>();
        services.AddTransient<UpdateUserRolesViewModel>();
        services.AddTransient<DeleteUserRolesViewModel>();

        services.AddTransient<ReadPetProjectsViewModel>();
    }
}