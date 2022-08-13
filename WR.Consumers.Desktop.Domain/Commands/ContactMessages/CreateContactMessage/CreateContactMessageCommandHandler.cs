namespace WR.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand, ContactMessage?>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public CreateContactMessageCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<ContactMessage?> Handle(
        CreateContactMessageCommand request,
        CancellationToken token)
    {
        if (request.ContactMessage is null
            or { Message: "" }
            or { SenderEmail: "" }
            or { SenderName: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        var result = await sender.PostAndReturnAsync(
            routePath: _configuration.Value.Routes.ContactMessages.CreateContactMessageRoute,
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return result;
    }
}