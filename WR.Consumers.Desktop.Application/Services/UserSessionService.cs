namespace WR.Consumers.Desktop.Application.Services;

public class UserSessionService
{
    public string? JwtToken { get; private set; } = default;

    public bool IsActive { get; private set; } = false;

    private readonly IUserAppService _userService;

    private readonly IAuthenticationAppService _authorizationService;

    public UserSessionService(
        IUserAppService userService,
        IAuthenticationAppService authorizationService) =>
        (_userService, _authorizationService) = (userService, authorizationService);

    public User? ActiveUser
    {
        get => _activeUser;
        private set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(ActiveUser));

            _activeUser = value;
        }
    }

    private User? _activeUser;

    public async Task StartSession(User activeUser)
    {
        if (IsActive) return;

        var user = await _userService.GetAsync(
            username: activeUser.Username,
            password: activeUser.Password);

        ArgumentNullException.ThrowIfNull(user, nameof(user));

        ActiveUser = user;

        JwtToken = await _authorizationService.Authorize(
            username: activeUser.Username,
            password: activeUser.Password);

        ArgumentNullException.ThrowIfNull(argument: JwtToken, paramName: nameof(JwtToken));

        IsActive = true;
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = default;

        JwtToken = default;

        IsActive = false;
    }
}