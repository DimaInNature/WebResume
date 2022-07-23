namespace WR.Consumers.Web.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>
{
    private readonly IConfiguration _configuration;

    public GetContactMessageByIdQueryHandler(IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<ContactMessage?> Handle(
        GetContactMessageByIdQuery request,
        CancellationToken token)
    {
        if (Guid.Empty == request.Id) return null;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.GetAsync<ContactMessage>(
            routePath: string.Format(
                format: _configuration[key: "Routes:ContactMessages:GetContactMessageById"],
                arg0: request.Id),
            cancellationToken: token);

        return result;
    }
}