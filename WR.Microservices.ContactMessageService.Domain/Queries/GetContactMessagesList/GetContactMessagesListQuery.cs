namespace WR.Microservices.ContactMessageService.Domain.Queries;

public sealed record class GetContactMessagesListQuery : IRequest<IEnumerable<ContactMessageEntity>>;