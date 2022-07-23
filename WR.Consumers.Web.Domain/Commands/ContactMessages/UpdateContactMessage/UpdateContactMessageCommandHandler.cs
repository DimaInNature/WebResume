namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    private readonly IConfiguration _configuration;

    public UpdateContactMessageCommandHandler(IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(UpdateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.PutAsync(
            routePath: _configuration[key: "Routes:ContactMessages:UpdateContactMessage"],
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return Unit.Value;
    }
}