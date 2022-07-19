namespace WR.Microservices.ContactMessageService.Domain.Commands;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand>
{
    private readonly IGenericRepository<ContactMessageEntity> _repository;

    public CreateContactMessageCommandHandler(
        IGenericRepository<ContactMessageEntity> repository) => 
        _repository = repository;

    public async Task<Unit> Handle(CreateContactMessageCommand request, CancellationToken token)
    {
        if (request.ContactMessage is null) return Unit.Value;

        await _repository.CreateAsync(entity: request.ContactMessage, token);

        return Unit.Value;
    }
}