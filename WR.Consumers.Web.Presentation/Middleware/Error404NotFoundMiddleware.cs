namespace WR.Consumers.Web.Presentation.Middleware
{
    public class Error404NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public Error404NotFoundMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if ((context.Response.StatusCode, context.Response.HasStarted) is (404, false))
            {
                (context.Items[key: "originalPath"], context.Request.Path) = (context.Request.Path.Value, "/error/404");

                await _next(context);
            }
        }
    }
}
