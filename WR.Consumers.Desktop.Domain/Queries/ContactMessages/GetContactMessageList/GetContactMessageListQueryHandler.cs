namespace WR.Consumers.Desktop.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageListQueryHandler
    : IRequestHandler<GetContactMessageListQuery, IEnumerable<ContactMessage>>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetContactMessageListQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<IEnumerable<ContactMessage>> Handle(
        GetContactMessageListQuery request,
        CancellationToken token)
    {
        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<IEnumerable<ContactMessage>>(
            routePath: _configuration.Value.Routes.ContactMessages.GetContactMessagesListRoute,
            cancellationToken: token);

        return result ?? new List<ContactMessage>();
    }
}