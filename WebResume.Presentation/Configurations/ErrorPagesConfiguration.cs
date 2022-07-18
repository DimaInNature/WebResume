namespace WebResume.Presentation.Configurations;

public static class ErrorPagesConfiguration
{
    public static void UseErrorPages(this IApplicationBuilder app)
    {
        app.UseNotFoundErrorPage();

        app.UseInternalServerErrorPage();
    }

    public static void UseNotFoundErrorPage(this IApplicationBuilder app) =>
        app.Use(async (ctx, next) =>
        {
            await next();

            if ((ctx.Response.StatusCode, ctx.Response.HasStarted) is (404, false))
            {
                string? originalPath = ctx.Request.Path.Value;

                ctx.Items["originalPath"] = originalPath;

                ctx.Request.Path = "/error/404";

                await next();
            }
        });

    public static void UseInternalServerErrorPage(this IApplicationBuilder app) =>
       app.Use(async (ctx, next) =>
       {
           await next();

           if ((ctx.Response.StatusCode, ctx.Response.HasStarted) is (500, false))
           {
               string? originalPath = ctx.Request.Path.Value;

               ctx.Items["originalPath"] = originalPath;

               ctx.Request.Path = "/error/500";

               await next();
           }
       });
}