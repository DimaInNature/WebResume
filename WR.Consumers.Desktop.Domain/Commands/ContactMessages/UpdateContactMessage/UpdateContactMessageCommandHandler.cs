namespace WR.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    private readonly IConfiguration _configuration;

    public UpdateContactMessageCommandHandler(
        IConfiguration configuration) =>
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

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.PutAsync(
            routePath: _configuration[key: "Routes:ContactMessages:UpdateContactMessage"],
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return default;
    }
}