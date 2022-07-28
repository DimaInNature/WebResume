namespace WR.Microservices.UserService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleAppService _userService;

    public UserRolesController(IUserRoleAppService userService) =>
        _userService = userService;

    /// <summary>
    /// Get user roles.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /UserRoles
    ///
    /// </remarks>
    /// <returns>Return all user roles.</returns>
    /// <response code="200">User roles list.</response>
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
    /// Get user role by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /UserRoles/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>User.</returns>
    /// <response code="200">User role.</response>
    /// <response code="404">If the user role was not found.</response>
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
    /// Create user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /UserRoles
    ///     {
    ///         "id": Guid,
    ///         "name": "Admin"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Post")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserRoleEntity>> Create([FromBody] UserRoleEntity user)
    {
        if (user is not null)
            await _userService.CreateAsync(entity: user);

        return Ok();
    }

    /// <summary>
    /// Update user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /UserRoles
    ///     {
    ///         "id": Guid,
    ///         "name": "Admin"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Put")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UserRoleEntity user)
    {
        if (user is not null)
            await _userService.UpdateAsync(entity: user);

        return NoContent();
    }

    /// <summary>
    /// Delete user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /UserRoles/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
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