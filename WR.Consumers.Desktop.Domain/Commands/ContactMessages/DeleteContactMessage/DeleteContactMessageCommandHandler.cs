namespace WR.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    private readonly IOptions<ApplicationSettingsModel> _configuration;

    public DeleteContactMessageCommandHandler(
        IOptions<ApplicationSettingsModel> configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        DeleteContactMessageCommand request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration.Value.Routes.GatewayRoute);

        await sender.DeleteAsync(
            routePath: _configuration.Value.Routes.ContactMessages.DeleteContactMessage(id: request.Id),
            cancellationToken: token);

        return default;
    }
}