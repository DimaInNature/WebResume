namespace WR.Consumers.Web.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageListQueryHandler
    : IRequestHandler<GetContactMessageListQuery, IEnumerable<ContactMessage>>
{
    public async Task<IEnumerable<ContactMessage>> Handle(GetContactMessageListQuery request, CancellationToken token)
    {
        HttpSender sender = new(hostUri: "https://localhost:7040");

        var result = await sender.GetAsync<IEnumerable<ContactMessage>>(routePath: $"ContactMessages",
            cancellationToken: token);

        return result ?? new List<ContactMessage>();
    }
}