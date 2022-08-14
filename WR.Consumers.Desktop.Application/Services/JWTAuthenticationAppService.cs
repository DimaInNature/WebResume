namespace WR.Consumers.Desktop.Application.Services;

public sealed class JWTAuthenticationAppService : IAuthenticationAppService
{
    private readonly IMediator _mediator;

    public JWTAuthenticationAppService(IMediator mediator) => _mediator = mediator;

    public async Task<string?> Authorize(string username, string password)
    {
        AuthorizationRequest requestBody = new(username, password);

        string? token = await _mediator.Send(request: new UserAuthorizationCommand(entity: requestBody));

        return token;
    }
}