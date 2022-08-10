namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand>
{
    private readonly IConfiguration _configuration;

    public CreateUserCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        CreateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null 
            or { Username: "" }
            or { Password: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.PostAsync(
            routePath: _configuration[key: "Routes:Users:CreateUser"],
            serializableObj: request.User,
            cancellationToken: token);

        return default;
    }
}