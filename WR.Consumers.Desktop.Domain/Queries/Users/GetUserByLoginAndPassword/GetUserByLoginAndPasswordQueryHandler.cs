namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, User?>
{
    private readonly IConfiguration _configuration;

    public GetUserByLoginAndPasswordQueryHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<User?> Handle(
        GetUserByLoginAndPasswordQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Username) ||
            string.IsNullOrWhiteSpace(value: request.Password))
            return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<User>(
            routePath: string.Format(
                format: _configuration[key: "Routes:Users:GetUserByLoginAndPassword"],
                arg0: request.Username,
                arg1: request.Password),
            cancellationToken: token);

        return result;
    }
}