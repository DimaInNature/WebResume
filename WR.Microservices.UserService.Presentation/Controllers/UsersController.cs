namespace WR.Microservices.UserService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserAppService _userService;

    public UsersController(IUserAppService userService) =>
        _userService = userService;

    /// <summary>
    /// Get users.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users
    ///
    /// </remarks>
    /// <returns>Return all users.</returns>
    /// <response code="200">Users list.</response>
    //[Authorize]
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetList()
    {
        var result = await _userService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get user by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>User.</returns>
    /// <response code="200">User.</response>
    /// <response code="404">If the user was not found.</response>
    //[Authorize]
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<UserEntity>> Get(Guid id)
    {
        var result = await _userService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Get user by login and password.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users/Admin/Root
    ///
    /// </remarks>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>User.</returns>
    /// <response code="200">User.</response>
    /// <response code="404">If the user was not found.</response>
    //[AllowAnonymous]
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{username}/{password}")]
    public async Task<ActionResult<UserEntity>> Get(string username, string password)
    {
        var result = await _userService.GetAsync(
            predicate: user => user.Username == username &&
            user.Password == password);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Users
    ///     {
    ///         "id": Guid,
    ///         "username": "Admin",
    ///         "password": "123456",
    ///         "userRoleId": Guid
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    //[AllowAnonymous]
    [Tags(tags: "Post")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserEntity>> Create([FromBody] UserEntity user)
    {
        if (user is not null)
            await _userService.CreateAsync(entity: user);

        return Ok();
    }

    /// <summary>
    /// Update user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Users
    ///     {
    ///         "id": Guid,
    ///         "username": "Admin",
    ///         "password": "123456",
    ///         "userRoleId": Guid
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    //[Authorize]
    [Tags(tags: "Put")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UserEntity user)
    {
        if (user is not null)
            await _userService.UpdateAsync(entity: user);

        return NoContent();
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Users/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    //[Authorize]
    [Tags(tags: "Delete")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _userService.DeleteAsync(id);

        return NoContent();
    }
}