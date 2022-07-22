namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand, ContactMessage?>
{
    public async Task<ContactMessage?> Handle(CreateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return null;

        HttpSender httpSender = new(hostUri: "https://localhost:5021");

        var result = await httpSender.PostAndReturnAsync(
            routePath: "ContactMessages",
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return result;
    }
}