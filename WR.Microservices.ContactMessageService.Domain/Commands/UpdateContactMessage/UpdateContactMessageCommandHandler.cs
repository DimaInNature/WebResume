namespace WR.Microservices.ContactMessageService.Domain.Commands;
public sealed record class UpdateContactMessageCommandHandler
    : IRequestHandler<UpdateContactMessageCommand>
{
    private readonly IGenericRepository<ContactMessageEntity> _repository;

    public UpdateContactMessageCommandHandler(
        IGenericRepository<ContactMessageEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(UpdateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        await _repository.UpdateAsync(entity: request.ContactMessage, token);

        return Unit.Value;
    }
}