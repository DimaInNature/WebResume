namespace WR.Microservices.UserService.Domain.Queries.Users;

public sealed record class GetUsersListQueryHandler
    : IRequestHandler<GetUsersListQuery, IEnumerable<UserEntity>>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public GetUsersListQueryHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<UserEntity>> Handle(
        GetUsersListQuery request,
        CancellationToken token) =>
        _repository.GetAllWithInclude(
            includeProperties: prop => prop.UserRole) ?? new List<UserEntity>();
}