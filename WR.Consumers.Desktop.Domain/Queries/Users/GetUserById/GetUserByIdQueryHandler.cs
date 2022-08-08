namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly IConfiguration _configuration;

    public GetUserByIdQueryHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<User?> Handle(
        GetUserByIdQuery request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<User>(
            routePath: string.Format(
                format: _configuration[key: "Routes:Users:GetUserById"],
                arg0: request.Id),
            cancellationToken: token);

        return result;
    }
}