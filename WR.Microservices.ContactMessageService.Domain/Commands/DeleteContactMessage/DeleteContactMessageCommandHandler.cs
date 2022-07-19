namespace WR.Microservices.ContactMessageService.Domain.Commands;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    private readonly IGenericRepository<ContactMessageEntity> _repository;

    public DeleteContactMessageCommandHandler(
        IGenericRepository<ContactMessageEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(DeleteContactMessageCommand request, CancellationToken token)
    {
        if (request.Key == Guid.Empty) return Unit.Value;

        await _repository.DeleteAsync(key: request.Key, token);

        return Unit.Value;
    }
}