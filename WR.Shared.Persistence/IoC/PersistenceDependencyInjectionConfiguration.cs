namespace WR.Shared.Persistence.IoC
{
    public static class PersistenceDependencyInjectionConfiguration
    {
        public static void AddSharedPersistence(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

            services.AddTransient(serviceType: typeof(IGenericRepository<>), implementationType: typeof(GenericRepository<>));

            services.Decorate(serviceType: typeof(IGenericRepository<>), decoratorType: typeof(GenericRepositoryLoggerDecorator<>));
        }

        public static void AddRepositoriesFromSharedPersistence(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

            services.AddTransient(serviceType: typeof(IGenericRepository<>), implementationType: typeof(GenericRepository<>));
        }

        public static void AddLoggingFromSharedPersistence(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

            services.AddTransient(serviceType: typeof(IGenericRepository<>), implementationType: typeof(GenericRepositoryLoggerDecorator<>));
        }
    }
}
