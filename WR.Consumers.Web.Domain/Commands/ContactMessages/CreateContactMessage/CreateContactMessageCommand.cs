namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class CreateContactMessageCommand : IRequest<ContactMessage>
{
    public ContactMessage? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessage entity) => ContactMessage = entity;

    public CreateContactMessageCommand() { }
}