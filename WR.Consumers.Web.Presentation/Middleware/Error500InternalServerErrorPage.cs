namespace WR.Consumers.Web.Presentation.Middleware
{
    public class Error500NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public Error500NotFoundMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if ((context.Response.StatusCode, context.Response.HasStarted) is (500, false))
            {
                (context.Items[key: "originalPath"], context.Request.Path) = (context.Request.Path.Value, "/error/500");

                await _next(context);
            }
        }
    }
}