namespace WR.Consumers.Web.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageByIdQuery : IRequest<ContactMessage?>
{
    public Guid Id { get; }

    public GetContactMessageByIdQuery(Guid id) => Id = id;

    public GetContactMessageByIdQuery() { }
}