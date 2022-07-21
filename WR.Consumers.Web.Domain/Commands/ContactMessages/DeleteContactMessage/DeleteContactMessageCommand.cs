namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class DeleteContactMessageCommand : IRequest
{
    public Guid Id { get; }

	public DeleteContactMessageCommand(Guid id) => Id = id;

	public DeleteContactMessageCommand() { }
}