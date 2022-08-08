namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly IConfiguration _configuration;

    public UpdateUserCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null) return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.PutAsync(
            routePath: _configuration[key: "Routes:Users:UpdateUser"],
            serializableObj: request.User,
            cancellationToken: token);

        return default;
    }
}