namespace WR.Consumers.Desktop.Domain.Queries.ContactMessages;

public sealed record class GetContactMessageListQuery : IRequest<IEnumerable<ContactMessage>>;