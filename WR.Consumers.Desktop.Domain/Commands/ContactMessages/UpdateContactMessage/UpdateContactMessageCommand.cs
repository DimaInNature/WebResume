namespace WR.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class UpdateContactMessageCommand : IRequest
{
    public ContactMessage? ContactMessage { get; }

    public UpdateContactMessageCommand(ContactMessage entity) =>
        ContactMessage = entity;

    public UpdateContactMessageCommand() { }
}