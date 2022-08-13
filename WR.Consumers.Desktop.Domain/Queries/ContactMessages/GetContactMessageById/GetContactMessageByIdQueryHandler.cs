namespace WR.Consumers.Desktop.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public GetContactMessageByIdQueryHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<ContactMessage?> Handle(
        GetContactMessageByIdQuery request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.GetAsync<ContactMessage>(
            routePath: _configuration.Value.Routes.ContactMessages.GetContactMessageById(id: request.Id),
            cancellationToken: token);

        return result;
    }
}