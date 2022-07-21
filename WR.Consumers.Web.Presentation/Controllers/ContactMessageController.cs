namespace WR.Consumers.Web.Presentation.Controllers;

public class ContactMessageController : Controller
{
    [HttpPost("api/ContactMessages")]
    public async Task<IActionResult> CreateContactMessage(
        [FromServices] IContactMessageAppService contactMessageService,
        [FromForm] ContactMessage contactMessage)
    {
        await contactMessageService.CreateAsync(contactMessage);

        return LocalRedirect(localUrl: "/");
    }
}