namespace WR.Consumers.Web.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageListQueryHandler
    : IRequestHandler<GetContactMessageListQuery, IEnumerable<ContactMessage>>
{
    private readonly IConfiguration _configuration;

    public GetContactMessageListQueryHandler(IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<ContactMessage>> Handle(GetContactMessageListQuery request, CancellationToken token)
    {
        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<IEnumerable<ContactMessage>>(
            routePath: _configuration[key: "Routes:ContactMessages:GetContactMessagesList"],
            cancellationToken: token);

        return result ?? new List<ContactMessage>();
    }
}