namespace WR.Microservices.ContactMessageService.Domain.Commands;

public sealed record class DeleteContactMessageCommand : IRequest
{
    public Guid Key { get; }

    public DeleteContactMessageCommand(Guid key) => Key = key;

    public DeleteContactMessageCommand() { }
}