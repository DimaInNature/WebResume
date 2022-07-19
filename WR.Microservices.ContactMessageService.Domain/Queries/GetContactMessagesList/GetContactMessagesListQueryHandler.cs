namespace WR.Microservices.ContactMessageService.Domain.Queries;

public sealed record class GetContactMessagesListQueryHandler
    : IRequestHandler<GetContactMessagesListQuery, IEnumerable<ContactMessageEntity>>
{
    private readonly IGenericRepository<ContactMessageEntity> _repository;

    public GetContactMessagesListQueryHandler(
        IGenericRepository<ContactMessageEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<ContactMessageEntity>> Handle(
        GetContactMessagesListQuery request,
        CancellationToken token) =>
        _repository.GetAll();
}
