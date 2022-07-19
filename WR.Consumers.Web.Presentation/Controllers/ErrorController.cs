namespace WR.Consumers.Web.Presentation.Controllers;

[Route(template: "Error")]
public class ErrorController : Controller
{
    [Route(template: "404")]
    public IActionResult PageNotFound() => View(viewName: "Error404");

    [Route(template: "500")]
    public IActionResult InternalServerError() => View(viewName: "Error500");

    [Route(template: "Redirect")]
    [HttpGet]
    public IActionResult RedirectToLocalPage(string redirectUrl) =>
        LocalRedirect(localUrl: redirectUrl);
}