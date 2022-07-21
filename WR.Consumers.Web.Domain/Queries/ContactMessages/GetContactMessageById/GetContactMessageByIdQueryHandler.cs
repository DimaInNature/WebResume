namespace WR.Consumers.Web.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>
{
    public async Task<ContactMessage?> Handle(GetContactMessageByIdQuery request, CancellationToken token)
    {
        if (Guid.Empty == request.Id) return null;

        HttpSender sender = new(hostUri: "https://localhost:7040");

        var result = await sender.GetAsync<ContactMessage>(
            routePath: $"ContactMessages/{request.Id}",
            cancellationToken: token);

        return result;
    }
}