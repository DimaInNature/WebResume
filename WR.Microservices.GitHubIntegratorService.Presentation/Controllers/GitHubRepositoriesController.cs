namespace WR.Microservices.GitHubIntegratorService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class GitHubRepositoriesController : ControllerBase
{
    private readonly IGitHubIntegratorAppService _gitHubIntegratorAppService;

    public GitHubRepositoriesController(IGitHubIntegratorAppService gitHubIntegratorAppService) =>
        _gitHubIntegratorAppService = gitHubIntegratorAppService;

    /// <summary>
    /// Get repositories from GitHub API.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /GitHubRepositories/Users/SampleUser/Repositories
    ///
    /// </remarks>
    /// <param name="gitHubUsername">Name of the GitHub user from whom we will take the resource.</param>
    /// <returns>Return all GitHub repositories.</returns>
    /// <response code="200">GitHub repositories list.</response>
    [Tags(tags: "Repositories")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Users/{gitHubUsername}/Repositories")]
    public async Task<ActionResult<IEnumerable<GitHubRepositoryResponse>>> GetList(string gitHubUsername)
    {
        var result = (await _gitHubIntegratorAppService.GetAllRepositoriesAsync(gitHubUsername)).ToList();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get GitHub repository by name from GitHub API.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /GitHubRepositories/SampleUser/SampleRepository
    ///
    /// </remarks>
    /// <param name="gitHubUsername">Name of the GitHub user from whom we will take the resource.</param>
    /// <param name="gitHubRepositoryName">Name of the repository whose information we want to get.</param>
    /// <returns>GitHub repository.</returns>
    /// <response code="200">GitHub repository.</response>
    /// <response code="404">If the GitHub repository was not found.</response>
    [Tags(tags: "Repositories")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{gitHubUsername}/{gitHubRepositoryName}")]
    public async Task<ActionResult<GitHubRepositoryResponse>> Get(string gitHubUsername, string gitHubRepositoryName)
    {
        var result = await _gitHubIntegratorAppService.GetRepositoryAsync(gitHubUsername, gitHubRepositoryName);

        return result is not null ? Ok(value: result) : NotFound();
    }
}