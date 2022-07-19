namespace WR.Microservices.ContactMessageService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class ContactMessagesController : ControllerBase
{
    private readonly IContactMessageAppService _contactMessageAppService;

    public ContactMessagesController(IContactMessageAppService contactMessageAppService) =>
        _contactMessageAppService = contactMessageAppService;

    /// <summary>
    /// Get contact messages.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /ContactMessages
    ///
    /// </remarks>
    /// <returns>Return all contact messages.</returns>
    /// <response code="200">Contact messages list.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactMessageEntity>>> GetList()
    {
        var result = (await _contactMessageAppService.GetAllAsync()).ToList();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get contact messages by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /ContactMessages/Id=Value
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Contact message.</returns>
    /// <response code="200">Contact message.</response>
    /// <response code="404">If the contact message was not found.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<ContactMessageEntity>> Get(Guid id)
    {
        var result = await _contactMessageAppService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create contact message.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /ContactMessages
    ///     {
    ///         "id": Guid, (auto)
    ///         "senderName": "John",
    ///         "senderEmail": "Example@bk.com",
    ///         "message": "Hello service"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Post")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<ContactMessageEntity>> Create([FromBody] ContactMessageEntity contactMessage)
    {
        if (contactMessage is not null)
            await _contactMessageAppService.CreateAsync(entity: contactMessage);

        return Ok();
    }

    /// <summary>
    /// Update contact message.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /ContactMessages
    ///     {
    ///         "id": Guid,
    ///         "senderName": "John",
    ///         "senderEmail": "Example@bk.com",
    ///         "message": "Hello service"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Put")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] ContactMessageEntity contactMessage)
    {
        if (contactMessage is not null)
            await _contactMessageAppService.UpdateAsync(entity: contactMessage);

        return NoContent();
    }

    /// <summary>
    /// Delete contact message.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /ContactMessages/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Delete")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _contactMessageAppService.DeleteAsync(id);

        return NoContent();
    }
}