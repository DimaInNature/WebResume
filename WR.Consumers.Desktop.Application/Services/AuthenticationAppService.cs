namespace WR.Consumers.Desktop.Application.Services;

public sealed class AuthenticationAppService : IAuthenticationAppService
{
    private readonly IMediator _mediator;

    public AuthenticationAppService(IMediator mediator) => _mediator = mediator;

    public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}