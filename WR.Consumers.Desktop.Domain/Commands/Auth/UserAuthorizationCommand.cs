namespace WR.Consumers.Desktop.Domain.Commands.Auth;

public sealed record class UserAuthorizationCommand
    : BaseAnonymousFeature, IRequest<string?>
{
    public AuthorizationRequest? AuthRequest { get; }

    public UserAuthorizationCommand(AuthorizationRequest entity) => AuthRequest = entity;

    public UserAuthorizationCommand() { }
}