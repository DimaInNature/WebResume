namespace WR.Microservices.ContactMessageService.Domain.Commands;

public sealed record class UpdateContactMessageCommand : IRequest
{
    public ContactMessageEntity? ContactMessage { get; }

    public UpdateContactMessageCommand(ContactMessageEntity entity) => ContactMessage = entity;

    public UpdateContactMessageCommand() { }
}
