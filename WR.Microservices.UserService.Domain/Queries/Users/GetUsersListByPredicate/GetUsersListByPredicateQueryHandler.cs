namespace WR.Microservices.UserService.Domain.Queries.Users;

public sealed record class GetUsersListByPredicateQueryHandler
    : IRequestHandler<GetUsersListByPredicateQuery, IEnumerable<UserEntity>>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public GetUsersListByPredicateQueryHandler(
        IGenericRepository<UserEntity> repository) => _repository = repository;

    public async Task<IEnumerable<UserEntity>> Handle(
        GetUsersListByPredicateQuery request,
        CancellationToken token)
    {
        if (request.Predicate is null) return new List<UserEntity>();

        return _repository.GetAllWithInclude(
            user => request.Predicate(user),
            prop => prop.UserRole) ?? new List<UserEntity>();
    }
}