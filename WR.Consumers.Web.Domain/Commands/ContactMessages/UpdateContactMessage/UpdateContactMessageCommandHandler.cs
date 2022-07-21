namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    public async Task<Unit> Handle(UpdateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        HttpSender httpSender = new(hostUri: "https://localhost:7040");

        await httpSender.PutAsync(routePath: "ContactMessages",
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return Unit.Value;
    }
}