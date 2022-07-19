namespace WR.Microservices.ContactMessageService.Domain.Queries;

public sealed record class GetContactMessageByIdQuery
    : IRequest<ContactMessageEntity?>
{
	public Guid Key { get; }

	public GetContactMessageByIdQuery(Guid key) => Key = key;

	public GetContactMessageByIdQuery() { }
}
