namespace WR.Consumers.Web.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<IEnumerable<ContactMessage>>;