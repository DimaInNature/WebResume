namespace WR.Shared.Persistence.IoC
{
    public static class PersistenceDependencyInjectionConfiguration
    {
        public static void AddSharedPersistence(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(paramName: nameof(services));

            services.AddTransient(serviceType: typeof(IGenericRepository<>), implementationType: typeof(GenericRepository<>));
        }
    }
}