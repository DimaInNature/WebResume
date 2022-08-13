namespace WR.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public UpdateContactMessageCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        UpdateContactMessageCommand request,
        CancellationToken token)
    {
        if (request.ContactMessage is null
            or { Message: "" }
            or { SenderEmail: "" }
            or { SenderName: "" })
            return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.PutAsync(
            routePath: _configuration.Value.Routes.ContactMessages.UpdateContactMessageRoute,
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return default;
    }
}