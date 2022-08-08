namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IConfiguration _configuration;

    public DeleteUserCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.DeleteAsync(
            routePath: string.Format(
                format: _configuration[key: "Routes:Users:DeleteUser"],
                arg0: request.Id),
            cancellationToken: token);

        return default;
    }
}