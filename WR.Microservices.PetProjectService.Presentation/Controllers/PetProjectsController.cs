namespace WR.Microservices.PetProjectService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class PetProjectsController : ControllerBase
{
    private readonly IPetProjectAppService _petProjectAppService;

    public PetProjectsController(IPetProjectAppService petProjectAppService) =>
        _petProjectAppService = petProjectAppService;

    /// <summary>
    /// Get pet projects.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /PetProjects
    ///
    /// </remarks>
    /// <returns>Return all pet projects.</returns>
    /// <response code="200">Pet projects list.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PetProjectEntity>>> GetList()
    {
        var result = (await _petProjectAppService.GetAllAsync()).ToList();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get pet project by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /PetProjects/Value
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Pet project.</returns>
    /// <response code="200">Pet project.</response>
    /// <response code="404">If the pet project was not found.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<PetProjectEntity>> Get(Guid id)
    {
        var result = await _petProjectAppService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }
}