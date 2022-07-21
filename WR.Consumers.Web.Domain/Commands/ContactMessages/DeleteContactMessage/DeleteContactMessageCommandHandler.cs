namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    public async Task<Unit> Handle(DeleteContactMessageCommand request, CancellationToken token)
    {
        if (Guid.Empty == request.Id) return Unit.Value;

        HttpSender httpSender = new(hostUri: "https://localhost:7040");

        await httpSender.DeleteAsync($"ContactMessages/{request.Id}", token);

        return Unit.Value;
    }
}