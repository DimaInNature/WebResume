namespace WR.Microservices.AuthenticationService.Presentation.Controllers;

[ApiController]
[Route(template: "[controller]")]
public class AuthController : ControllerBase
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    private readonly IUserAppService _userService;

    public AuthController(
        IOptions<ApplicationSettingsModel> configuration,
        IUserAppService userService) =>
        (_configuration, _userService) = (configuration, userService);

    [Route(template: "Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] AuthorizationRequest authRequest)
    {
        var user = await Authenticate(authRequest);

        if (user is not null)
        {
            string token = GenerateToken(user);

            return Ok(value: token);
        }

        return NotFound(value: "User is not found");
    }

    private string GenerateToken(User user)
    {
        ArgumentNullException.ThrowIfNull(argument: user, paramName: nameof(user));

        var securityKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(s: _configuration.Value.Jwt.Key));

        var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);

        Claim[] claims = new[]
        {
            new Claim(type: ClaimTypes.NameIdentifier, value: user.Username),
            new Claim(type: ClaimTypes.Role, value: user.UserRole?.Name ?? "None")
        };

        var token = new JwtSecurityToken(
            issuer: _configuration.Value.Jwt.Issuer,
            audience: _configuration.Value.Jwt.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<User?> Authenticate(AuthorizationRequest authRequest)
    {
        var currentUser = await _userService.GetAsync(
            username: authRequest.Username,
            password: authRequest.Password);

        return currentUser is not null ? currentUser : default;
    }
}