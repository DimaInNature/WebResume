namespace WR.Microservices.ContactMessageService.Domain.Queries;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessageEntity?>
{
    private readonly IGenericRepository<ContactMessageEntity> _repository;

    public GetContactMessageByIdQueryHandler(
        IGenericRepository<ContactMessageEntity> repository) =>
        _repository = repository;

    public async Task<ContactMessageEntity?> Handle(
        GetContactMessageByIdQuery request, CancellationToken token) =>
        request.Key == Guid.Empty 
        ? default 
        : await _repository.GetFirstOrDefaultAsync(key: request.Key, token);
}