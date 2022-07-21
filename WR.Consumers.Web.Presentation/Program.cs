var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    services.AddMediatRConfiguration();

    services.RegisterServices();
}

//Pipeline
void Configure(IApplicationBuilder app)
{
    // Allow errors pages
    app.UseErrorPages();

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();
}