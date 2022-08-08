namespace WR.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    private readonly IConfiguration _configuration;

    public DeleteContactMessageCommandHandler(
        IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<Unit> Handle(
        DeleteContactMessageCommand request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return default;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        await sender.DeleteAsync(
            routePath: string.Format(
                format: _configuration[key: "Routes:ContactMessages:DeleteContactMessage"],
                arg0: request.Id),
            cancellationToken: token);

        return default;
    }
}