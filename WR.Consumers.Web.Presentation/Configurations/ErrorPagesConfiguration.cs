namespace WR.Consumers.Web.Presentation.Configurations;

public static class ErrorPagesConfiguration
{
    public static void UseErrorPages(this IApplicationBuilder app)
    {
        app.UseNotFoundErrorPage();

        app.UseInternalServerErrorPage();
    }

    public static void UseNotFoundErrorPage(this IApplicationBuilder app)
    {
        _ = app ?? throw new ArgumentNullException(paramName: nameof(app));

        app.UseMiddleware<Error404NotFoundMiddleware>();
    }

    public static void UseInternalServerErrorPage(this IApplicationBuilder app)
    {
        _ = app ?? throw new ArgumentNullException(paramName: nameof(app));

        app.UseMiddleware<Error500NotFoundMiddleware>();
    }
}