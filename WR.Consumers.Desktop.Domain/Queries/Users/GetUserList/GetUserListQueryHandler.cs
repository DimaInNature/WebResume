namespace WR.Consumers.Desktop.Domain.Queries.Users;

public sealed record class GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, IEnumerable<User>>
{
    private readonly IConfiguration _configuration;

    public GetUserListQueryHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<User>> Handle(
        GetUserListQuery request,
        CancellationToken token)
    {
        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<IEnumerable<User>>(
            routePath: _configuration[key: "Routes:Users:GetUsersList"],
            cancellationToken: token);

        return result ?? new List<User>();
    }
}